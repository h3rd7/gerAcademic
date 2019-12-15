using gerAcademic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerAcademic.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options) {}
        
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Prova> Prova { get; set; }
        public DbSet<Evento> Evento { get; set; }
    }
}
