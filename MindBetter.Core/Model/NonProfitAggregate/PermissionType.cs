using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Model.NonProfitAggregate
{
    public class PermissionTypeLookup : LookupBase<PermissionTypeEnum>
    {
        public PermissionTypeLookup(PermissionTypeEnum enumVal) : base(enumVal)
        {
        }
    }

    public enum PermissionTypeEnum
    {
        [Description("Administrator")]
        Admin = 1,
        [Description("Editor")]
        Editor,
        [Description("Member")]
        Member
    }
}
