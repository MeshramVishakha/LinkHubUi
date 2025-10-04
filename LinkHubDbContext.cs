
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LinkHubDbContext : IdentityDbContext

    {
        
        public LinkHubDbContext(DbContextOptions<LinkHubDbContext> options):base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
            Database.EnsureCreated();
        }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LinkHubDB;Integrated Security=True");
        //}

        public DbSet<BOL.User> Users { get; set; }
        public DbSet<BOL.Category> Categories { get; set; }
        public DbSet<BOL.LHUrl> LHUrls
        {
            get; set;
        }
    }
}
