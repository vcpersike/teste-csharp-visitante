using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Domain;

namespace Visitante.BLL
{
    public interface IHistoricoVisitasBLL
    {
        Task<IEnumerable<HistoricoVisitasModal>> ObterTodos();
        Task<HistoricoVisitasModal> ObterPorId(int id);
        Task Criar(HistoricoVisitasModal departamento);
        Task Atualizar(HistoricoVisitasModal departamento, int id);
        Task Deletar(int id);
    }
}
