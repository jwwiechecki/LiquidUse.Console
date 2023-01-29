using LiquidUse.Database;
using LiquidUse.Database.Model;
using LiquidUse.Services.Interfaces;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }
    }
}
