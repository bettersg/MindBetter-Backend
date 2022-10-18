using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string LoginName { get; set; } 

        public User(int id, string name, string email, string loginName) : base(id, name)
        {
            Email = email;
            LoginName = loginName;
        }

    }
}
