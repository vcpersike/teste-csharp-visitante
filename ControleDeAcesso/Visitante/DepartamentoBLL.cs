using Visitante.BLL;
using Visitante.DAL;
using Visitante.Domain;

namespace Departamento
{
    public class DepartamentoBLL : IDepartamentoBLL
    {
        private readonly IDepartamentoDAL _departamentoDAL;
        public DepartamentoBLL(IDepartamentoDAL departamentoDAL)
        {
                _departamentoDAL = departamentoDAL;
        }
        public async Task Atualizar(DepartamentoModal departamento, int id)
        {
            var departamentoExistente = await ObterPorId(id);

            if (departamentoExistente == null)
            {
                return;
            }

            departamentoExistente.Empresa = departamento.Empresa;
            departamentoExistente.Nome = departamento.Nome;
            await _departamentoDAL.Atualizar(departamentoExistente);

            return;
        }
        public async Task Criar(DepartamentoModal departamento)
        {
            await _departamentoDAL.Criar(departamento); 
        }
        public async Task<DepartamentoModal> ObterPorId(int id)
        {
            return await _departamentoDAL.ObterPorId(id);
        }
        public async Task<IEnumerable<DepartamentoModal>> ObterTodos()
        {
            return await _departamentoDAL.ObterTodos();
        }
        public async Task Deletar(int id)
        {
            await _departamentoDAL.Deletar(id);
        }

    }
}