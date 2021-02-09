using BugBlaze.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugBlaze.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        //public DbSet<IdentityUser> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<ApplicationUser>()
        //        .HasDiscriminator<int>("Type")
        //        .HasValue<IdentityUser>(0)
        //        .HasValue<ApplicationUser>(1);
        //}
    }

    
}
