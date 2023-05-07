using Departamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Visitante;
using Visitante.BLL;
using Visitante.Domain;

[ApiController]
[Route("api/[controller]")]
public class VisitanteController : ControllerBase
{
    private readonly IVisitanteBLL _visitanteBll;
    public VisitanteController(IVisitanteBLL visitante)
    {
        _visitanteBll = visitante;
    }
    [HttpGet]
    public async Task<ActionResult> ObterTodos(int departamentoId)
    {
        var visitante = await _visitanteBll.ObterTodos(departamentoId);
        return Ok(visitante);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<VisitanteModal>> ObterPorId(int id)
    {
        return await _visitanteBll.ObterPorId(id);

    }
    [HttpPost]
    public async Task<ActionResult> Criar([FromBody] VisitanteModal visitante)
    {
        await _visitanteBll.Criar(visitante);
        return Ok("Departamento Criado com Sucesso");
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, [FromBody] VisitanteModal visitante)
    {
        await _visitanteBll.Atualizar(visitante, id);
        return Ok("Departamento Atualizado com Sucesso");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        await _visitanteBll.Deletar(id);
        return Ok("Deletado");
    }

}
