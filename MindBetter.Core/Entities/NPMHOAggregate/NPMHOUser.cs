using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Entities.NPMHOAggregate
{
    public class NPMHOMember
    {
        public string Designation { get; set; }
        public NPMHO NPMHO { get; set; }
        public UserType UserType { get; set; }

    }
}
