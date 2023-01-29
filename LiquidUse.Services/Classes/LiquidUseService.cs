using LiquidUse.Common.Enums;
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
        public IList<LiquidData> GetItems(DateTime? from, DateTime? to)
        {
            var result = _context.LiquidDatas
                .ToList();
            return result;
        }

        public LiquidData GetItemById(int id)
        {
            var result = _context.LiquidDatas
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return result;
        }

        public IList<LiquidData> GetItemsByKind(KindEnum kindEnum)
        {
            var result = _context.LiquidDatas
                .Where(x => x.Kind == kindEnum)
                .ToList();
            return result;
        }

    }
}
