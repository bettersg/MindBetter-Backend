namespace MindBetter.Core.Model.NonProfitAggregate
{
    public class ServiceCategoryLookup : LookupBase<ServiceCategoryEnum>
    {
        public ServiceCategoryLookup(ServiceCategoryEnum enumVal) : base(enumVal)
        {
        }
    }

    public enum ServiceCategoryEnum
    {
        Cat1 = 1,
        Cat2,
        Cat3
    }
}
