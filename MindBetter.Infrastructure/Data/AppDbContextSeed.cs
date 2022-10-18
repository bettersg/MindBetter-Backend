using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MindBetter.Core.Model;
using MindBetter.Core.Extensions;
using Newtonsoft.Json;
using System.Reflection;

namespace MindBetter.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext appDbContext, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (appDbContext.Database.IsSqlServer())
                {
                    appDbContext.Database.Migrate();
                }

                // generate enum lookup tables
                if (!await appDbContext.UserTypes.AnyAsync())
                {
                    await appDbContext.UserTypes.AddRangeAsync(GetEnumLookupTable<PermissionType, PermissionTypeEnum>());
                    await appDbContext.SaveChangesAsync();
                }

                //  generate test data
                if (appDbContext.Database.IsInMemory())
                {
                    var parentDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    await appDbContext.Users.AddRangeAsync(GetTestEntities<User>(parentDir + @"/Data/TestData/Users.json"));
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
