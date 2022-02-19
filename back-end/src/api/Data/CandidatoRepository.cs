using Cbyk.ATS.API.Data.Interface;
using Cbyk.ATS.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cbyk.ATS.API.Data
{
    public class CandidatoRepository : BaseRepository<CandidatoModel>, ICandidatoRepository
    {
        public CandidatoRepository(IConfiguration configuration) : base(configuration, "candidatos")
        {
        }

        public async Task<CandidatoModel> FindByEmail(string email)
        {
            var cursor = await DbSet.FindAsync(x => x.Email == email);

            return cursor.FirstOrDefault();
        }

        public async Task<IEnumerable<CandidatoModel>> GetFilterName(string nome)
        {
            var all = await DbSet.FindAsync(Builders<CandidatoModel>.Filter.Where(p => p.Nome.ToLower().Contains(nome.ToLower()) || nome == null));
            return all.ToList();
        }
    }
}
