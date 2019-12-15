using gerAcademic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerAcademic.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public StatusAluno Status { get; set; }
        public Turma Turma { get; set; }
        public ICollection<Prova> Provas { get; set; } = new List<Prova>();

        public Aluno()
        {
        }

        public Aluno(int id, string nome, DateTime dataNascimento, string email, StatusAluno status, Turma turma)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Status = status;
            Turma = turma;
        }

        public void FazerProva(Prova rt)
        {
            Provas.Add(rt);
        }
    }
}
