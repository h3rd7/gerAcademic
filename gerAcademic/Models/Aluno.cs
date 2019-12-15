using gerAcademic.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gerAcademic.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatorio.")]
        [StringLength(30, MinimumLength =3, ErrorMessage = "{0} tamanho deve estar entre {2} e {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatorio.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        
        [Required(ErrorMessage = "Campo {0} obrigatorio.")]
        [EmailAddress(ErrorMessage = "Entre com um e-mail valido.")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Status do Aluno")]

        [Required(ErrorMessage = "Campo {0} obrigatorio.")]
        public StatusAluno Status { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatorio.")]
        public Turma Turma { get; set; }
        
        public int TurmaId { get; set; }
        
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
