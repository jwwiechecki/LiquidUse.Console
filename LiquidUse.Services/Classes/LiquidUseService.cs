using LiquidUse.Database;
using LiquidUse.Database.Model;
using LiquidUse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiquidUse.Services.Classes
{
    public class LiquidUseService : ILiquidUseService
    {
        private readonly LiquidUseQueryDbContext _context;

        public LiquidUseService(LiquidUseQueryDbContext context)
        {
            _context = context;
        }
        public IList<LiquidData> GetItems()
        {
            var result = _context.LiquidDatas
                .ToList();
            return result;
        }

        public LiquidData GetItemById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
