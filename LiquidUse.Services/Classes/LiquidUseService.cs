using LiquidUse.Database;
using LiquidUse.Database.Model;
using LiquidUse.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LiquidUse.Services.Classes
{
    public class LiquidUseService : ILiquidService
    {
        private readonly LiquidUseQueryDbContext _context;

        public LiquidUseService(LiquidUseQueryDbContext context)
        {
            _context = context;
        }
        public IList<LiquidData> GetLiquidDataItems()
        {
            var result = _context.LiquidDatas
                .ToList();
            return result;
        }
    }
}
