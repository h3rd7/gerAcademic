using gerAcademic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerAcademic.Models
{
    public class Prova
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public TipoProva Tipo { get; set; }
        public Aluno Aluno { get; set; }

        public Prova()
        {
        }

        public Prova(int id, double nota, TipoProva tipo, Aluno aluno)
        {
            Id = id;
            Nota = nota;
            Tipo = tipo;
            Aluno = aluno;
        }
    }
}
