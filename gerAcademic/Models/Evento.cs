using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerAcademic.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Evento()
        {
        }

        public Evento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
