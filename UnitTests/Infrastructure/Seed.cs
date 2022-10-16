using MindBetter.Core.Entities;
using MindBetter.Core.Entities.NPMHOAggregate;
using MindBetter.Infrastructure.Data;
using Xunit;

namespace UnitTests.Infrastructure
{
    public class Seed
    {
        [Fact]
        public void Generate_EnumLookupTable_ReturnListOfEnum()
        {
            var expected = new List<UserType>
            {
                new UserType(UserTypeEnum.Admin),
                new UserType(UserTypeEnum.Editor),
                new UserType(UserTypeEnum.Member)
            };

            var actual = AppDbContextSeed.GetEnumLookupTable<UserType, UserTypeEnum>().ToList();

            Assert.Equal(expected, actual);
        }

    }
}
