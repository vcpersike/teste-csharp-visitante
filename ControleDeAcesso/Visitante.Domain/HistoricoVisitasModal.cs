using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitante.Domain
{
    public class HistoricoVisitasModal
    {
        public int Id { get; set; }
        public string DepartamentoId { get; set; }
        public string VisitanteId { get; set; }
        public  DateTime Date { get; set; }
        public  string? Descricao { get; set; }
    }
}
