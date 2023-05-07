using Departamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Visitante;
using Visitante.BLL;
using Visitante.Domain;

[ApiController]
[Route("api/[controller]")]
public class HistoricoVisitasController : ControllerBase
{
    private readonly IHistoricoVisitasBLL _historicoVisitasBll;
    public HistoricoVisitasController(IHistoricoVisitasBLL historico)
    {
        _historicoVisitasBll = historico;
    }
    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var historico = await _historicoVisitasBll.ObterTodos();
        return Ok(historico);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<HistoricoVisitasModal>> ObterPorId(int id)
    {
        return await _historicoVisitasBll.ObterPorId(id);

    }
    [HttpPost]
    public async Task<ActionResult> Criar([FromBody] HistoricoVisitasModal historico)
    {
        await _historicoVisitasBll.Criar(historico);
        return Ok("Departamento Criado com Sucesso");
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, [FromBody] HistoricoVisitasModal historico)
    {
        await _historicoVisitasBll.Atualizar(historico, id);
        return Ok("Departamento Atualizado com Sucesso");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        await _historicoVisitasBll.Deletar(id);
        return Ok("Deletado");
    }

}
