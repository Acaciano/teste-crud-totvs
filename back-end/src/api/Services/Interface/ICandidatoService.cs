using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cbyk.ATS.API.Extension;
using Cbyk.ATS.API.Models;

namespace Cbyk.ATS.API.Services.Interface
{
    public interface ICandidatoService
    {
        Task<ApiResponse<CandidatoModel>> Find(Guid id);
        Task<ApiResponse<IEnumerable<CandidatoModel>>> GetAll();
        Task<ApiResponse<IEnumerable<CandidatoModel>>> GetFilterName(string name);
        Task<ApiResponse<CandidatoModel>> Save(CandidatoModel usuario);
        Task<ApiResponse<CandidatoModel>> Update(Guid id, CandidatoModel usuario);
        Task<ApiResponse<CandidatoModel>> Delete(Guid id);
    }
}
