using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model.NPMHOAggregate
{
    public class Service : BaseEntity
    {
        public string Description { get; set; }
        public NPMHO NPMHO { get;  set; }

        public ServiceCategoryEnum Category { get; set; }

        public Service(int id, string name, string description) : base(id, name)
        {
            Description = description;
        }

    }
}
