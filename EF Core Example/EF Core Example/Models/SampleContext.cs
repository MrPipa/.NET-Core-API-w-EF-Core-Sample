using Microsoft.EntityFrameworkCore;

namespace EF_Core_Example.Models
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        { }

        public DbSet<SampleModel> SampleModels { get; set; }
    }
}