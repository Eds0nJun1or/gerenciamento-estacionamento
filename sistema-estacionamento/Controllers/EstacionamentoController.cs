using Microsoft.AspNetCore.Mvc;
using EstacionamentoAPI.Models;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private static Estacionamento _estacionamento = new Estacionamento();

        [HttpPost("Adicionar")]
        public IActionResult AdicionarVeiculo([FromBody] PlacaRequest request)
        {
            try
            {
                _estacionamento.AdicionarVeiculo(request.Placa);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public IActionResult ListarVeiculos()
        {
            var veiculos = _estacionamento.ListarVeiculos();
            return Ok(veiculos);
        }

        [HttpDelete("Remover")]
        public IActionResult RemoverVeiculo([FromBody] RemoverRequest request)
        {
            if (_estacionamento.RemoverVeiculo(request.Placa, request.Horas, out decimal valorTotal))
            {
                string valorTotalFormatado = $"R$ {valorTotal:F2}";
                return Ok(new { valorTotal = valorTotalFormatado });
            }

            return NotFound("Veículo não encontrado.");
        }
    }

    public class PlacaRequest
    {
        public string Placa { get; set; }
    }

    public class RemoverRequest
    {
        public string Placa { get; set; }
        public int Horas { get; set; }
    }
}
