using LiquidUse.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace LiquidUse.Database
{
    public class LiquidUseDBContext : DbContext
    {
        public DbSet<LiquidData> LiquidDatas { get; set; }
        public DbSet<LiquidKind> LiquidKinds { get; set; }
    }
}
