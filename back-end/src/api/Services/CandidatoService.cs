using Cbyk.ATS.API.Data.Interface;
using Cbyk.ATS.API.Extension;
using Cbyk.ATS.API.Models;
using Cbyk.ATS.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cbyk.ATS.API.Services
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public async Task<ApiResponse<CandidatoModel>> Find(Guid id)
        {
            CandidatoModel find = await _candidatoRepository.GetById(id);

            if (find != null) return find.ResultSuccess();

            return new CandidatoModel().ResultError(string.Empty);
        }

        public async Task<ApiResponse<IEnumerable<CandidatoModel>>> GetAll()
        {
            IEnumerable<CandidatoModel> candidatos = await _candidatoRepository.GetAll();
            return candidatos.ResultSuccess();
        }

        public async Task<ApiResponse<IEnumerable<CandidatoModel>>> GetFilterName(string name)
        {
            IEnumerable<CandidatoModel> candidatos = await _candidatoRepository.GetFilterName(name);
            return candidatos.ResultSuccess();
        }

        public async Task<ApiResponse<CandidatoModel>> Save(CandidatoModel candidato)
        {
            var findByEmail = await _candidatoRepository.FindByEmail(candidato.Email);

            if(findByEmail != null) return findByEmail.ResultError($"Já existe um candidato com o E-mail: {candidato.Email}");

            await _candidatoRepository.Add(candidato);
            return candidato.ResultSuccess();
        }

        public async Task<ApiResponse<CandidatoModel>> Update(Guid id, CandidatoModel candidato)
        {
            CandidatoModel findDb = await _candidatoRepository.GetById(id);

            if (findDb == null) return candidato.ResultError($"Não foi encontrado nenhum candidato para o ID: {candidato.Id}");

            var findByEmail = await _candidatoRepository.FindByEmail(candidato.Email);

            if (findByEmail != null && findByEmail.Id != id) return findByEmail.ResultError($"Já existe um candidato com o E-mail: {candidato.Email}");

            findDb.Nome = candidato.Nome;
            findDb.Cpf = candidato.Cpf;
            findDb.Email = candidato.Email;
            findDb.Idade = candidato.Idade;
            findDb.AtualizaDataUpdate();

            await _candidatoRepository.Update(id, findDb);

            return findDb.ResultSuccess();
        }

        public async Task<ApiResponse<CandidatoModel>> Delete(Guid id)
        {
            CandidatoModel findDb = await _candidatoRepository.GetById(id);

            if (findDb == null) return new CandidatoModel().ResultError($"Não foi encontrado nenhum candidato para o ID: {id}");

            await _candidatoRepository.Remove(id);

            return findDb.ResultSuccess();
        }
    }
}
