using Departamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Visitante;
using Visitante.BLL;
using Visitante.Domain;

[ApiController]
[Route("api/[controller]")]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoBLL _departamentoBll;
    public DepartamentoController(IDepartamentoBLL departamento)
    {
        _departamentoBll = departamento;
    }
    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var departamentos = await _departamentoBll.ObterTodos();
        return Ok(departamentos);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartamentoModal>> ObterPorId(int id)
    {
        return await _departamentoBll.ObterPorId(id);

    }
    [HttpPost]
    public async Task<ActionResult> Criar([FromBody] DepartamentoModal departamento)
    {
        await _departamentoBll.Criar(departamento);
        return Ok("Departamento Criado com Sucesso");
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, [FromBody] DepartamentoModal departamento)
    {
        await _departamentoBll.Atualizar(departamento, id);
        return Ok("Departamento Atualizado com Sucesso");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
            await _departamentoBll.Deletar(id);
            return Ok("Deletado");
    }

}
