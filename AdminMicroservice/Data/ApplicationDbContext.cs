using AdminMicroservice.Model;
using Microsoft.EntityFrameworkCore;

namespace AdminMicroservice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Vaccination> Vaccinationstock { get; set; }
    }
}
