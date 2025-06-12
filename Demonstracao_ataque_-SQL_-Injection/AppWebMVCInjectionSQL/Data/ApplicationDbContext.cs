using AppWebMVCInjectionSQL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppWebMVCInjectionSQL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
    }
}
