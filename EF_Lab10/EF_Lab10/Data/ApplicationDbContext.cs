using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EF_Lab10.Models;
using EF_Lab10.Controllers;

namespace EF_Lab10.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EBook> EBooks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<EF_Lab10.Controllers.LoginViewModel> LoginViewModel { get; set; }
      
    }
}
