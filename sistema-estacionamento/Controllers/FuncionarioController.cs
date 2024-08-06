using Microsoft.AspNetCore.Mvc;
using SistemaEstacionamento.Models;
using SistemaEstacionamento.Services;

namespace SistemaEstacionamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Funcionario funcionario)
        {
            var createdFuncionario = _funcionarioService.Create(funcionario);
            return CreatedAtAction(nameof(GetById), new { id = createdFuncionario.Id }, createdFuncionario);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_funcionarioService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var funcionario = _funcionarioService.GetById(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Funcionario funcionario)
        {
            if (!_funcionarioService.Update(id, funcionario))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_funcionarioService.Delete(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}