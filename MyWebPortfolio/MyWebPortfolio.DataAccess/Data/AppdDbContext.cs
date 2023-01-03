using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyWebPortfolio.Models;

namespace MyWebPortfolio.DataAccess.Data
{
    public class AppdDbContext : IdentityDbContext
    {
        public AppdDbContext(DbContextOptions<AppdDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cover> Covers { get; set; }


    }
}
