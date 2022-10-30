using MindBetter.Core.Model.NonProfitAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Core.Interfaces
{
    public interface INPMHOService
    {
        Task<List<NonProfit>> GetAllNPMHOs();
        Task<List<Member>> GetAllNPMHOMembersById(int npmhoId);
        Task<List<Service>> GetNPMHOServicesById(int nmphoId);
    }
}
