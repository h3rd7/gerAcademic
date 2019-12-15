using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerAcademic.Models;

namespace gerAcademic.Data
{
    public class SeedingService
    {
        private DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Turma.Any() || _context.Aluno.Any() ||
               _context.Prova.Any() || _context.Evento.Any())
            {
                return;
            }

            Turma t1 = new Turma(1, "Turma C010");
            Turma t2 = new Turma(2, "Turma C020");
            Turma t3 = new Turma(3, "Turma C030");

            Aluno a1 = new Aluno(1, "João Pedro", new DateTime(2000 ,01 ,20), "joao@test.com", Models.Enums.StatusAluno.Processo, t1);
            Aluno a2 = new Aluno(2, "Ana Clara", new DateTime(2000, 03, 08), "ana@test.com", Models.Enums.StatusAluno.Processo, t1);
            Aluno a3 = new Aluno(3, "Marta Antunes", new DateTime(1990, 03, 10), "marta@test.com", Models.Enums.StatusAluno.Processo, t2);
            Aluno a4 = new Aluno(4, "Carlos Toredo", new DateTime(1996, 08, 06), "carlos@test.com", Models.Enums.StatusAluno.Processo, t2);

            Prova p1 = new Prova(1, 6, Models.Enums.TipoProva.Primeira, a1);
            Prova p2 = new Prova(2, 8.4, Models.Enums.TipoProva.Primeira, a2);
            Prova p3 = new Prova(3, 5.8, Models.Enums.TipoProva.Primeira, a3);
            Prova p4 = new Prova(4, 7.2, Models.Enums.TipoProva.Primeira, a4);
            Prova p5 = new Prova(5, 6.5, Models.Enums.TipoProva.Segunda, a1);
            Prova p6 = new Prova(6, 9, Models.Enums.TipoProva.Segunda, a2);
            Prova p7 = new Prova(7, 10, Models.Enums.TipoProva.Segunda, a3);
            Prova p8 = new Prova(8, 4.5, Models.Enums.TipoProva.Segunda, a4);
            Prova p9 = new Prova(9, 3.2, Models.Enums.TipoProva.Terceira, a1);
            Prova p10 = new Prova(10, 8, Models.Enums.TipoProva.Terceira, a2);
            Prova p11 = new Prova(11, 2.9, Models.Enums.TipoProva.Terceira, a3);
            Prova p12 = new Prova(12, 6.3, Models.Enums.TipoProva.Terceira, a4);

            Evento e1 = new Evento(1, "Competição");

            _context.Turma.AddRange(t1, t2, t3);

            _context.Aluno.AddRange(a1, a2, a3, a4);

            _context.Prova.AddRange(p1, p2, p3, p4, 
                p5, p6, p7, p8, p9, p10, p11, p12);

            _context.Evento.AddRange(e1);

            _context.SaveChanges();
        }
    }
}
