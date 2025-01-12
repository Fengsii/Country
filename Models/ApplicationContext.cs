using Country.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Country.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public virtual DbSet<CountryGloble> GetCountryGlobles { get; set; }
    }
}
