using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Domain;

namespace Visitante.DAL
{
    public interface IVisitanteDAL
    {
        Task<IEnumerable<DepartamentoModal>> ObterTodos();
        Task Criar(VisitanteModal visitante);
        Task<VisitanteModal> ObterPorId(int id);
        Task Atualizar(VisitanteModal visitante);
        Task Deletar(int id);
    }
}
