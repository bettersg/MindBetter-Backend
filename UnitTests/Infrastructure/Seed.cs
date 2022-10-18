using MindBetter.Core.Model;
using MindBetter.Core.Model.NPMHOAggregate;
using MindBetter.Infrastructure.Data;
using Xunit;

namespace UnitTests.Infrastructure
{
    public class Seed
    {
        [Fact]
        public void Generate_EnumLookupTable_ReturnListOfEnum()
        {
            var expected = new List<PermissionType>
            {
                new PermissionType(PermissionTypeEnum.Admin),
                new PermissionType(PermissionTypeEnum.Editor),
                new PermissionType(PermissionTypeEnum.Member)
            };

            var actual = AppDbContextSeed.GetEnumLookupTable<PermissionType, PermissionTypeEnum>().ToList();

            Assert.Equal(expected, actual);
        }

    }
}
