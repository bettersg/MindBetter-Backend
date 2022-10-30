using MindBetter.Core.Model.NonProfitAggregate;

namespace MindBetter.Core.Interfaces
{
    public interface INPMHOService
    {
        Task<List<NonProfit>> GetAllNPMHOs();
        Task<List<Member>> GetAllNPMHOMembersById(int npmhoId);
        Task<List<Service>> GetNPMHOServicesById(int nmphoId);
    }
}
