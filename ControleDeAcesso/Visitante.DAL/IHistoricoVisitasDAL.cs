using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Domain;

namespace Visitante.DAL
{
    public interface IHistoricoVisitasDAL
    {
        Task<IEnumerable<HistoricoVisitasModal>> ObterTodos();
        Task Criar(HistoricoVisitasModal historico);
        Task<HistoricoVisitasModal> ObterPorId(int id);
        Task Atualizar(HistoricoVisitasModal historico);
        Task Deletar(int id);
    }
}
