namespace Visitante.Domain
{
    public class VisitanteModal
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Rg { get; set; }
        public string Departamento { get; set; }
        public string Pessoa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}