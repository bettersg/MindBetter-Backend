using MindBetter.Core.Model.NonProfitAggregate;
using MindBetter.Infrastructure.Data.Config;
using Xunit;

namespace UnitTests.Infrastructure
{
    public class SeedTests
    {
        [Fact]
        public void Generate_EnumLookupTable_ReturnListOfEnum()
        {
            var expected = new List<PermissionTypeLookup>
            {
                new PermissionTypeLookup(PermissionTypeEnum.Admin),
                new PermissionTypeLookup(PermissionTypeEnum.Editor),
                new PermissionTypeLookup(PermissionTypeEnum.Member)
            };

            var actual = Seed.GetEnumLookupTable<PermissionTypeLookup, PermissionTypeEnum>().ToList();

            Assert.Equal(expected, actual);
        }

    }
}
