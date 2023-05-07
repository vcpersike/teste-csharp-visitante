using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Domain;

namespace Visitante.BLL
{
    public interface IVisitanteBLL
    {
        Task<IEnumerable<VisitanteModal>> ObterTodos(int depertamentoId);
        Task Criar(VisitanteModal visitante);
        Task<VisitanteModal> ObterPorId(int id);
        Task Atualizar(VisitanteModal visitante, int id);
        Task Deletar(int id);
    }
}
