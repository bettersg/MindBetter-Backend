using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model.NPMHOAggregate
{
    public class Service : BaseEntity
    {
        public string Description { get; private set; }
        public NPMHO ServiceProvider { get; private set; }

        public ServiceCategory Category { get; private set; }

        public Service(int id, string name, string description, NPMHO serviceProvider, ServiceCategory serviceCategory) : base(id, name)
        {
            Description = description;

            ServiceProvider = serviceProvider;
            Category = serviceCategory;
        }

    }
}
