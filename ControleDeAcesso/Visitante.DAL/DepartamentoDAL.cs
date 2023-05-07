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
    public class DepartamentoDAL : IDepartamentoDAL
    {
        private readonly Config _options;
        public DepartamentoDAL(IOptions<Config> options)
        {
           _options = options.Value;
        }
        public async Task Atualizar(DepartamentoModal departamento)
        {
            using (var connection = new SqlConnection(_options.joit))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("AtualizarDepartamento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", departamento.Id);
                    command.Parameters.AddWithValue("@Empresa", departamento.Empresa);
                    command.Parameters.AddWithValue("@Nome", departamento.Nome);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                }
                connection.Close();
            }
        }

        public async Task Criar(DepartamentoModal departamento)
        {
            using (var connection = new SqlConnection(_options.joit))
            {
                connection.Open();
                using (var command = new SqlCommand("CriarDepartamento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Empresa", departamento.Empresa);
                    command.Parameters.AddWithValue("@Nome", departamento.Nome);
                    int rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return;
        }

        public async Task<IEnumerable<DepartamentoModal>> ObterTodos()
        {
            using (var connection = new SqlConnection(_options.joit))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ObterTodosDepartamentos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var departamentos = new List<DepartamentoModal>();
                        while (await reader.ReadAsync())
                        {
                            departamentos.Add(new DepartamentoModal
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome"))
                            });
                        }
                        return departamentos;
                    }
                }
            }
        }
        public async Task<DepartamentoModal> ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_options.joit))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ObterDepartamentoPorId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new DepartamentoModal
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Empresa = reader.GetString(reader.GetOrdinal("Empresa")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome"))
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public async Task Deletar(int id)
        {
            using (var connection = new SqlConnection(_options.joit))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DeletarDepartamento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                }
                connection.Close();
            }
        }
    }
}