using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Talento.Models;

namespace Talento.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Talento.Models.Users> Users { get; set; }
        public DbSet<Talento.Models.CandidatoViewModel> CandidatoViewModel { get; set; }

    }
}
