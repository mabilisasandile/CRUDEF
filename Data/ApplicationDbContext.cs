using Microsoft.EntityFrameworkCore;

namespace CRUDEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CRUDEF.Entities.Student> Students
        {
            get; set;
        }

        public DbSet<CRUDEF.Entities.Staff> StaffMembers
        {
            get; set;
        }
    }
}
