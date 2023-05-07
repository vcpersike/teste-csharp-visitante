using ControleDeAcesso;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Visitante.DAL;
using Visitante.Domain;

namespace Departamento.DAL
{
    public class VisitanteDAL : IVisitanteDAL
    {
        private readonly Config _options;
        public VisitanteDAL(IOptions<Config> options)
        {
            _options = options.Value;
        }
        public Task Atualizar(VisitanteModal visitante)
        {
            throw new NotImplementedException();
        }

        public async Task Criar(VisitanteModal visitante)
        {
            using (var connection = new SqlConnection(_options.joit))
            {
                connection.Open();
                using (var command = new SqlCommand("CriarVisitante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", visitante.Id);
                    command.Parameters.AddWithValue("@Rg", visitante.Rg);
                    command.Parameters.AddWithValue("@Cargo", visitante.Cargo);
                    command.Parameters.AddWithValue("@Contato", visitante.Contato);
                    command.Parameters.AddWithValue("@Pessoa", visitante.Pessoa);
                    command.Parameters.AddWithValue("@Cpf", visitante.Cpf);
                    command.Parameters.AddWithValue("@Data_nascimento", visitante.DataNascimento);
                    command.Parameters.AddWithValue("@Departamento", visitante.Departamento);
                    command.Parameters.AddWithValue("@Nome", visitante.Nome);

                    int rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return;
        }

        public Task Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VisitanteModal> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DepartamentoModal>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}