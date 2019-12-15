using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerAcademic.Data;
using gerAcademic.Models;

namespace gerAcademic.Services
{
    public class TurmaService
    {
        private readonly DataContext _context;

        public TurmaService(DataContext context)
        {
            _context = context;
        }

        public List<Turma> FindAll()
        {
            return _context.Turma.ToList();
        }

    }
}
