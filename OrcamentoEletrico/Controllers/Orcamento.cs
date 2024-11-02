using Microsoft.AspNetCore.Mvc;
using OrcamentoEletrico.DTOs;
using OrcamentoEletricoApp.Services;
using OrcamentoEletricoDomain.Entities;

namespace OrcamentoEletrico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly IImovelService _imovelService;

        public ImovelController(IImovelService imovelService)
        {
            _imovelService = imovelService;
        }

        [HttpPost]
        public IActionResult CreateImovel([FromBody] ImovelDto imovelDto)
        {
            if (imovelDto == null)
                return BadRequest("Dados inválidos.");

            var imovel = new Imovel(imovelDto.MetrosQuadrados, imovelDto.NumeroDePavimentos, imovelDto.ClassificacaoDePadrao);
            imovel.SetQuantidadeDeTomadas(imovelDto.QuantidadeDeTomadas);
            imovel.SetQuantidadeDePontosDeLuz(imovelDto.QuantidadeDePontosDeLuz);
            imovel.SetPrazo(imovelDto.Prazo);
            if (imovelDto.EquipamentosAdicionais != null)
            {
                foreach (var equipamento in imovelDto.EquipamentosAdicionais)
                {
                    imovel.AdicionarEquipamentoAdicional(equipamento);
                }
            }

            _imovelService.Save(imovel);

            return CreatedAtAction(nameof(CreateImovel), new { /* aqui você pode incluir o ID ou outro identificador */ }, imovel);
        }
    }
}
