using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudos.Domain.Models
{
    public class Cursos
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
