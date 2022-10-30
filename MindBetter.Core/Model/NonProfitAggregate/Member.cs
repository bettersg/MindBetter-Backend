namespace MindBetter.Core.Model.NonProfitAggregate
{
    public class Member : User
    {
        public string Designation { get; set; }
        public NonProfit? NonProfit { get; set; }
        public int NonProfitId { get; set; }
        public PermissionTypeEnum PermissionType { get; set; }

        public Member(string email, string userName, string firstName, string lastName, string designation, PermissionTypeEnum permissionType)
            : base(email, userName, firstName, lastName)
        {
            Designation = designation;
            PermissionType = permissionType;
        }

    }
}
