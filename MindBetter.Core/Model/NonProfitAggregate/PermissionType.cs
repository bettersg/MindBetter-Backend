using System.ComponentModel;

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
