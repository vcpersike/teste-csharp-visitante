using Visitante.BLL;
using Visitante.DAL;
using Visitante.Domain;

namespace Visitante
{
    public class VisitanteBLL : IVisitanteBLL
    {
        private readonly IVisitanteDAL _visitanteDAL;
        public VisitanteBLL(IVisitanteDAL visitanteDAL)
        {
            _visitanteDAL = visitanteDAL;
        }

        public Task Atualizar(VisitanteModal visitante, int id)
        {
            throw new NotImplementedException();
        }
        public Task Criar(VisitanteModal visitante)
        {
            return _visitanteDAL.Criar(visitante);
        }

        public Task Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VisitanteModal> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VisitanteModal>> ObterTodos(int depertamentoId)
        {
            throw new NotImplementedException();
        }
    }
}