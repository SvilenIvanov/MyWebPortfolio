using Microsoft.EntityFrameworkCore;
using MyWebPortfolio.Models;

namespace MyWebPortfolio.DataAccess.Data
{
    public class AppdDbContext : DbContext
    {
        public AppdDbContext(DbContextOptions<AppdDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cover> Covers { get; set; }

    }
}
