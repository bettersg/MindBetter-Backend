using MindBetter.Core.Entities;
using MindBetter.Core.Entities.NPMHOAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Core.Entities
{
    public class EnumBaseEntityTests
    {
        [Fact]
        public void CompareSameClasses_ReturnTrue()
        {
            Assert.Equal(new UserType(UserTypeEnum.Admin), new UserType(UserTypeEnum.Admin));
        }

        [Fact]
        public void CompareSameClasses_ReturnFalse()
        {
            Assert.NotEqual(new UserType(UserTypeEnum.Admin), new UserType(UserTypeEnum.Member));
        }

        [Fact]
        public void CompareDifferentDerivedClasses_ReturnFalse()
        {
            EnumBaseEntity<UserTypeEnum> ut = new UserType(UserTypeEnum.Admin);
            EnumBaseEntity<ServiceCategoryEnum> sc = new ServiceCategory(ServiceCategoryEnum.Cat1);

            var result = ut.Equals(sc);
            
            Assert.False(result);
        }
    }
}
