using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerAcademic.Models.ViewModels
{
    public class AlunoFormViewModel
    {
        public Aluno Aluno { get; set; }
        public ICollection<Turma> Turmas { get; set; }
    }
}
