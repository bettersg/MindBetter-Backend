using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model.NPMHOAggregate
{
    public class NPMHOMember
    {
        public string Designation { get; set; }
        public NPMHO NPMHO { get; set; }
        public PermissionType Type { get; set; }

    }
}
