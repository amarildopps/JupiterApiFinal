using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APIJupiterCandidatura.Model
{
    public class DbCandidaturaContext : DbContext
    {

        public DbCandidaturaContext(DbContextOptions<DbCandidaturaContext> options)
            : base(options)
        { }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Candidatura> Candidaturas { get; set; }
        public DbSet<Vaga> Vagas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Candidatura>()
                .HasOne(a => a.Candidato)
                .WithMany(b => b.Candidaturas)
                .HasForeignKey(a => a.IDCandidato)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Entity<Candidatura>()
                .HasOne(a => a.Vaga)
                .WithMany(b => b.Candidaturas)
                .HasForeignKey(a => a.IDVaga)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

        }
    }
}
