using Microsoft.EntityFrameworkCore;

namespace WebApplication9Municipal_Billing_System.Models
{
    public class DBContextClassReg : DbContext
    {
        public DBContextClassReg(DbContextOptions<DBContextClassReg> options)
            : base(options)
        {
        }

        // Use non-nullable DbSet with suppression operator
        public DbSet<Reg> Regs { get; set; } = null!;
    }
}
