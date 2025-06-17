using APITODO.Model;
using DAL.Model.UserMangment;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {



        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // إزالة Cascade Delete من علاقة Todo مع User
            modelBuilder.Entity<Todo>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); // أو DeleteBehavior.NoAction


            modelBuilder.Entity<Category>()
    .HasOne(c => c.User)
    .WithMany()
    .HasForeignKey(c => c.UserId)
    .OnDelete(DeleteBehavior.Cascade); // يظل فقط واحد كـ Cascade
        }

        //DbSet 

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }


    }

}

