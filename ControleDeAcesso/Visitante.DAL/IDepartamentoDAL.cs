using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Domain;

namespace Visitante.DAL
{
    public interface IDepartamentoDAL
    {
        Task<IEnumerable<DepartamentoModal>> ObterTodos();
        Task<DepartamentoModal> ObterPorId(int id);
        Task Criar(DepartamentoModal departamento);
        Task Atualizar(DepartamentoModal departamento);
        Task Deletar(int id);
    }
}