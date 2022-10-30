using MindBetter.Core.Model;
using MindBetter.Core.Model.NonProfitAggregate;
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
            Assert.Equal(new PermissionTypeLookup(PermissionTypeEnum.Admin), new PermissionTypeLookup(PermissionTypeEnum.Admin));
        }

        [Fact]
        public void CompareSameClasses_ReturnFalse()
        {
            Assert.NotEqual(new PermissionTypeLookup(PermissionTypeEnum.Admin), new PermissionTypeLookup(PermissionTypeEnum.Member));
        }

        [Fact]
        public void CompareDifferentDerivedClasses_ReturnFalse()
        {
            LookupBase<PermissionTypeEnum> ut = new PermissionTypeLookup(PermissionTypeEnum.Admin);
            LookupBase<ServiceCategoryEnum> sc = new ServiceCategoryLookup(ServiceCategoryEnum.Cat1);

            var result = ut.Equals(sc);
            
            Assert.False(result);
        }
    }
}
