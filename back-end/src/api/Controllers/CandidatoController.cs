using Cbyk.ATS.API.Controllers.Base;
using Cbyk.ATS.API.Models;
using Cbyk.ATS.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cbyk.ATS.API.Controllers
{
    [Route("api/v1/candidatos")]
    [ApiController]
    public class CandidatoController : ApiBaseController
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatoController(ICandidatoService usuarioService)
        {
            _candidatoService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Response(await _candidatoService.GetAll());
        }

        [HttpGet("filtroPorNome")]
        public async Task<IActionResult> GetFilterNome(string nome = "")
        {
            return Response(await _candidatoService.GetFilterName(nome));
        }

        [HttpGet()]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Response(await _candidatoService.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CandidatoModel candidado)
        {
            if (ModelState.IsValid)
                return Response(await _candidatoService.Save(candidado));

            return ResponseError(ModelState);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CandidatoModel candidado)
        {
            if (ModelState.IsValid)
            {
                candidado.Id = id;
                return Response(await _candidatoService.Update(id, candidado));
            }

            return ResponseError(ModelState);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Response(await _candidatoService.Delete(id));
        }
    }
}
