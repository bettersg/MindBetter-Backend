using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MindBetter.Core.Model;
using MindBetter.Core.Extensions;
using Newtonsoft.Json;
using System.Reflection;
using MindBetter.Core.Model.NPMHOAggregate;
using System.Runtime.CompilerServices;

namespace MindBetter.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        private int SEED = 1;
        public static async Task SeedAsync(AppDbContext appDbContext, ILogger logger, int retry = 0)
        {
            var rand = new Random();

            var retryForAvailability = retry;
            try
            {
                if (appDbContext.Database.IsSqlServer())
                {
                    appDbContext.Database.Migrate();
                }

                // generate enum lookup tables
                if (!await appDbContext.PermissionTypes.AnyAsync())
                {
                    await appDbContext.PermissionTypes.AddRangeAsync(GetEnumLookupTable<PermissionType, PermissionTypeEnum>());
                    await appDbContext.SaveChangesAsync();

                }

                if (!await appDbContext.ServiceCategories.AnyAsync())
                {
                    await appDbContext.ServiceCategories.AddRangeAsync(GetEnumLookupTable<ServiceCategory, ServiceCategoryEnum>());
                    await appDbContext.SaveChangesAsync();

                }

                //  generate test data
                if (appDbContext.Database.IsInMemory())
                {
                    var parentDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    await appDbContext.Users.AddRangeAsync(GetTestEntities<User>(parentDir + @"/Data/TestData/Users.json"));
                    await appDbContext.SaveChangesAsync();


                    var NPMHOs = GetTestEntities<NPMHO>(parentDir + @"/Data/TestData/NPMHOs.json");
                    var services = GetTestEntities<Service>(parentDir + @"/Data/TestData/Services.json");
                    var npmhoMembers = GetTestEntities<NPMHOMember>(parentDir + @"/Data/TestData/NPMHOMembers.json");

                    var serviceCategories = appDbContext.ServiceCategories.ToList();
                    var permissions = appDbContext.PermissionTypes.ToList();

                    foreach (var service in services)
                    {
                        var npmho = NPMHOs.ElementAt(rand.Next(NPMHOs.Count()));
                        service.NPMHO = npmho;
                        //npmho.Services.Add(service);

                        var serviceCategory = serviceCategories.ElementAt(rand.Next(serviceCategories.Count()));
                        service.Category = serviceCategory.EnumVal;
                    }

                    foreach(var npmhoMember in npmhoMembers)
                    {
                        var npmho = NPMHOs.ElementAt(rand.Next(NPMHOs.Count()));
                        npmhoMember.Organisation = npmho;
                        //npmho.Members.Add(npmhoMember);

                        var permission = permissions.ElementAt(rand.Next(permissions.Count()));
                        npmhoMember.Type = permission.EnumVal;
                    }

                    await appDbContext.AddRangeAsync(NPMHOs);
                    await appDbContext.SaveChangesAsync();


                }

            }
            catch (Exception ex)
            {
                // TODO: make rety limit a setting.
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                await SeedAsync(appDbContext, logger, retryForAvailability);
                throw;
            }
        }

        private static IEnumerable<T> GetTestEntities<T>(string testDataFilePath)
        {
            var jsonText = System.IO.File.ReadAllText(testDataFilePath);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonText);
        }

        public static IEnumerable<T> GetEnumLookupTable<T,E>() 
            where E : Enum
            where T : EnumBaseEntity<E>
        {
            var type = typeof(T);
            var x = EnumExtensions.GetValues<E>().Select(ev => (T)Activator.CreateInstance(type, ev));
            return x;
        }
    }
}
