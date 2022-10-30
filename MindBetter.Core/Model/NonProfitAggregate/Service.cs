namespace MindBetter.Core.Model.NonProfitAggregate
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public NonProfit? NonProfit { get; set; }
        public int NonProfitId { get; set; }
        public ServiceCategoryEnum Category { get; set; }

        public Service(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
