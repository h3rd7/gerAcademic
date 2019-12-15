using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerAcademic.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Turma()
        {
        }

        public Turma(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }

        public void RemoverAluno(Aluno aluno)
        {
            Alunos.Remove(aluno);
        }

    }
}
