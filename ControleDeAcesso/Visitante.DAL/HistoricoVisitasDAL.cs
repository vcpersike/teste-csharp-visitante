using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitante.Domain;

namespace Visitante.DAL
{
    public class HistoricoVisitasDAL : IHistoricoVisitasDAL
    {
        public Task Atualizar(HistoricoVisitasModal historico)
        {
            throw new NotImplementedException();
        }

        public Task Criar(HistoricoVisitasModal historico)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HistoricoVisitasModal> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HistoricoVisitasModal>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
