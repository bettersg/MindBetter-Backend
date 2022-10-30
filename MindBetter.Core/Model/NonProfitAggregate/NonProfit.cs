namespace MindBetter.Core.Model.NonProfitAggregate
{
    public class NonProfit
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string WebsiteURL { get; set; }

        public ICollection<Member> Members { get; set; } = new List<Member>();

        public ICollection<Service> Services { get; set; } = new List<Service>();

        public NonProfit(string email, string name, string websiteURL)
        {
            Email = email;
            Name = name;
            WebsiteURL = websiteURL;
        }

    }
}
