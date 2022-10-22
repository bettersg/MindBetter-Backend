using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model.NPMHOAggregate
{
    public class NPMHOMember : User
    {
        public string Designation { get; set; }
        public NPMHO Organisation { get; set; }
        public PermissionTypeEnum Type { get; set; }

        public NPMHOMember(int id, string name, string email, string loginName, string designation) 
            : base(id, name, email, loginName)
        {
            Designation = designation;
        }

    }
}
