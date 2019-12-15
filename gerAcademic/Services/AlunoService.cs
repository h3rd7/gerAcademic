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

        public List<Aluno> FindAll()
        {
            return _context.Aluno.Include(x => x.Turma).ToList();
        }

        public void Insert(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
        }

        public Aluno FindById(int id)
        {
            return _context.Aluno.Include(x => x.Turma).FirstOrDefault(aluno => aluno.Id == id);
        }

        public void Remove(int id)
        {
            var aluno = _context.Aluno.Find(id);
            _context.Aluno.Remove(aluno);
            _context.SaveChanges();
        }

        public void Update(Aluno aluno)
        {
            if (!_context.Aluno.Any(x => x.Id == aluno.Id))
            {
                throw new NotFoundException("Id não encontrado.");
            }
            try
            {
                _context.Update(aluno);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        }
}
