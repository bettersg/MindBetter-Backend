namespace MindBetter.Core.Model.NPMHOAggregate
{
    public class NPMHO : BaseEntity
    {
        public string? Email { get; protected set; }

        public string? Website { get; protected set; }

        public List<NPMHOMember> Members { get; set; } = new List<NPMHOMember>();

        public List<Service> Services { get; set; } = new List<Service>();

        public NPMHO(int id, string name, string? email, string? website) : base(id, name)
        {
            Email = email;
            Website = website;
        }
    }
}
