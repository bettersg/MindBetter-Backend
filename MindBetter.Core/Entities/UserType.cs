using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Entities
{
    public class UserType : EnumBaseEntity<UserTypeEnum>
    {
       public UserType(UserTypeEnum userTypeEnumVal) : base(userTypeEnumVal)
        {
        }
    }

    public enum UserTypeEnum
    {
        [Description("Administrator")]
        Admin=1,
        [Description("Editor")]
        Editor,
        [Description("Member")]
        Member
    }
}
