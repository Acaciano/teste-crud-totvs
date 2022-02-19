using Cbyk.ATS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cbyk.ATS.API.Data.Interface
{
    public interface ICandidatoRepository : IRepository<CandidatoModel>
    {
        Task<CandidatoModel> FindByEmail(string email);
        Task<IEnumerable<CandidatoModel>> GetFilterName(string nome);
    }
}
