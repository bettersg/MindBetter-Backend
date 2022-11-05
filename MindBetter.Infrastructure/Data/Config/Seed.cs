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
        public static async Task SeedAsync(AppDbContext appDbContext, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                //  generate test data
#if DEBUG
                var parentDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Delete pre-existing data
                //appDbContext.DeleteAll<User>();
                //appDbContext.DeleteAll<Member>();
                //appDbContext.DeleteAll<Service>();
                //appDbContext.DeleteAll<NonProfit>();

                await appDbContext.Users.AddRangeAsync(GetTestEntities<User>(parentDir + @"/Data/Config/TestData/Users.json"));
                await appDbContext.SaveChangesAsync();

                await appDbContext.NonProfits.AddRangeAsync(GetTestEntities<NonProfit>(parentDir + @"/Data/Config/TestData/NonProfits.json"));
                await appDbContext.SaveChangesAsync();

                await appDbContext.NonProfitMembers.AddRangeAsync(GetTestEntities<Member>(parentDir + @"/Data/Config/TestData/Members.json"));
                await appDbContext.SaveChangesAsync();

                await appDbContext.Services.AddRangeAsync(GetTestEntities<Service>(parentDir + @"/Data/Config/TestData/Services.json"));
                await appDbContext.SaveChangesAsync();
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
