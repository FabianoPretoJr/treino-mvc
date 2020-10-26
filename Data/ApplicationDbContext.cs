using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using treino_mvc.Models;

namespace treino_mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Video> Video { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
