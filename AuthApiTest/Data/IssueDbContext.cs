using AuthApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApiTest.Data
{
    public class IssueDbContext : DbContext
    {

        public IssueDbContext(DbContextOptions<IssueDbContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
    }
}
