using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model.NPMHOAggregate
{
    public class ServiceCategory : EnumBaseEntity<ServiceCategoryEnum>
    {
        public ServiceCategory(ServiceCategoryEnum enumVal) : base(enumVal)
        {
        }
    }

    public enum ServiceCategoryEnum
    {
        Cat1=1,
        Cat2,
        Cat3
    }
}
