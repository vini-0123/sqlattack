using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSegPiaget.Models;

namespace WebSegPiaget.Data
{
    public class WebSegPiagetContext : DbContext
    {
        public WebSegPiagetContext (DbContextOptions<WebSegPiagetContext> options)
            : base(options)
        {
        }

        public DbSet<WebSegPiaget.Models.Aluno> Aluno { get; set; } = default!;
    }
}
