using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public BaseEntity(int id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
 