using LiquidUse.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace LiquidUse.Database
{
    public class LiquidUseDBContext : DbContext
    {
        public virtual DbSet<LiquidData> LiquidDatas { get; set; }
        public virtual DbSet<LiquidKind> LiquidKinds { get; set; }
    }
}
