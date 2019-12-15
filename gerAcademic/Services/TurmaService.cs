using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerAcademic.Data;
using gerAcademic.Models;
using Microsoft.EntityFrameworkCore;

namespace gerAcademic.Services
{
    public class TurmaService
    {
        private readonly DataContext _context;

        public TurmaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Turma>> FindAllAsync()
        {
            return await _context.Turma.OrderBy(x => x.Nome).ToListAsync();
        }

    }
}
