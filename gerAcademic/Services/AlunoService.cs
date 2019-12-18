using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerAcademic.Data;
using gerAcademic.Models;
using gerAcademic.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace gerAcademic.Services
{
    public class AlunoService
    {
        private readonly DataContext _context;

        public AlunoService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> FindAllAsync()
        {
            return await _context.Aluno.Include(x => x.Turma).ToListAsync();
        }

        public async Task InsertAsync(Aluno aluno)
        {
            _context.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<Aluno> FindByIdAsync(int id)
        {
            return await _context.Aluno.Include(x => x.Turma).FirstOrDefaultAsync(aluno => aluno.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var aluno = await _context.Aluno.FindAsync(id);
                _context.Aluno.Remove(aluno);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                // throw new IntegrityException(e.Message);
                throw new IntegrityException("Não posso excluir Aluno porque ele possui avaliações / provas, " 
                    + "para excluir o mesmo entre em detalhes e exclua suas avaliações");
            }
        }

        public async Task UpdateAsync(Aluno aluno)
        {
            bool hasAny = await _context.Aluno.AnyAsync(x => x.Id == aluno.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
            try
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        }
}
