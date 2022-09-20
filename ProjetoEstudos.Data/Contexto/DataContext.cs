using Microsoft.EntityFrameworkCore;
using ProjetoEstudos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudos.Data.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        public DbSet<Cursos> Cursos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cursos>().HasKey(i => i.Id);
            builder.Entity<Cursos>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Cursos>().Property(t => t.Titulo)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Entity<Cursos>().Property(t => t.Descricao)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Entity<Cursos>().Property(t => t.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }


    }
}
