using Microsoft.EntityFrameworkCore;

namespace TonnyTest.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<Tb_PersonasFisicas> Tb_PersonasFisicas { get; set; }
    }
}
