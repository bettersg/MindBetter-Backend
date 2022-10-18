using MindBetter.Core.Model;
using MindBetter.Core.Model.NPMHOAggregate;
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
            Assert.Equal(new PermissionType(PermissionTypeEnum.Admin), new PermissionType(PermissionTypeEnum.Admin));
        }

        [Fact]
        public void CompareSameClasses_ReturnFalse()
        {
            Assert.NotEqual(new PermissionType(PermissionTypeEnum.Admin), new PermissionType(PermissionTypeEnum.Member));
        }

        [Fact]
        public void CompareDifferentDerivedClasses_ReturnFalse()
        {
            EnumBaseEntity<PermissionTypeEnum> ut = new PermissionType(PermissionTypeEnum.Admin);
            EnumBaseEntity<ServiceCategoryEnum> sc = new ServiceCategory(ServiceCategoryEnum.Cat1);

            var result = ut.Equals(sc);
            
            Assert.False(result);
        }
    }
}
