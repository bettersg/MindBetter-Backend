using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MindBetter.Core.Extensions;
using MindBetter.Core.Model;
using MindBetter.Core.Model.NonProfitAggregate;
using Newtonsoft.Json;
using System.Reflection;

namespace MindBetter.Infrastructure.Data.Config
{
    public static class Seed
    {
        private static int _seed = 1;
        public static async Task SeedAsync(AppDbContext appDbContext, ILogger logger, int retry = 0)
        {
            var rand = new Random(_seed);

            var retryForAvailability = retry;
            try
            {
                //  generate test data
#if DEBUG
                var parentDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Delete pre-existing data
                //appDbContext.DeleteAll<User>();
                //appDbContext.DeleteAll<Member>();
                //appDbContext.DeleteAll<NonProfit>();

                await appDbContext.Users.AddRangeAsync(GetTestEntities<User>(parentDir + @"/Data/Config/TestData/Users.json"));
                await appDbContext.SaveChangesAsync();

                await appDbContext.NonProfits.AddRangeAsync(GetTestEntities<NonProfit>(parentDir + @"/Data/Config/TestData/NonProfits.json"));
                await appDbContext.SaveChangesAsync();

                await appDbContext.NonProfitMembers.AddRangeAsync(GetTestEntities<Member>(parentDir + @"/Data/Config/TestData/Members.json"));
                await appDbContext.SaveChangesAsync();

                //var NPMHOs = GetTestEntities<NPMHO>(parentDir + @"/Data/TestData/NPMHOs.json");
                //NonProfit n = new("NP1","test@test.com","www.test.com");

                //Member nm = new("nptestUser@test.com", "nptestUser","fname1","lname1", "Main",PermissionTypeEnum.Admin);
                
                //nm.NonProfitId = n.Id;

                /*
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
                */
#endif

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

        public static IEnumerable<T> GetEnumLookupTable<T, E>()
          where E : Enum
          where T : LookupBase<E>
        {
            var type = typeof(T);
            var x = EnumExtensions.GetValues<E>().Select(ev => (T)Activator.CreateInstance(type, ev));
            return x;
        }

        public static IEnumerable<T> GetTestEntities<T>(string testDataFilePath)
        {
            var jsonText = System.IO.File.ReadAllText(testDataFilePath);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonText);
        }

        public static void DeleteAll<T>(this DbContext context)
      where T : class
        {
            foreach (var p in context.Set<T>())
            {
                context.Entry(p).State = EntityState.Deleted;
            }
        }
    }
}
