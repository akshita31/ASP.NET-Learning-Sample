using Microsoft.EntityFrameworkCore;
using SampleApplication.Models;

namespace SampleApplication.Data
{
    public class SampleApplicationDbContext: DbContext
    {
        public SampleApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Restaraunt> Restaurants {get;set;}
    }
}