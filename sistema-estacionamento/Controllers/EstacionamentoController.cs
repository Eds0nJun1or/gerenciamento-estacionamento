using Microsoft.AspNetCore.Mvc;
using sistema_estacionamento.Controllers.Request.EstacionamentoAPI.Controllers.Requests;
using SistemaEstacionamento.Services;

namespace SistemaEstacionamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly EstacionamentoService _estacionamentoService;

        public EstacionamentoController(EstacionamentoService estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }

        [HttpPost("Adicionar")]
        public IActionResult AdicionarVeiculo([FromBody] AdicionarVeiculo request)
        {
            try
            {
                _estacionamentoService.AdicionarVeiculo(request.Placa, request.Modelo, request.Cor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public IActionResult ListarVeiculos()
        {
            var veiculos = _estacionamentoService.ListarVeiculos();
            return Ok(veiculos);
        }

        [HttpGet("VagasDisponiveis")]
        public IActionResult VagasDisponiveis()
        {
            int vagasDisponiveis = _estacionamentoService.VagasDisponiveis();
            return Ok(new { vagasDisponiveis });
        }

        [HttpDelete("Remover")]
        public IActionResult RemoverVeiculo([FromBody] RemoverVeiculo request)
        {
            if (_estacionamentoService.RemoverVeiculo(request.Placa, out decimal valorTotal))
            {
                string valorTotalFormatado = $"R$ {valorTotal:F2}";
                return Ok(new { valorTotal = valorTotalFormatado });
            }

            return NotFound("Veículo não encontrado.");
        }
    }
}