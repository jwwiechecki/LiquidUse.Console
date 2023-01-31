using LiquidUse.Common.Enums;
using LiquidUse.Database;
using LiquidUse.Database.Model;
using LiquidUse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            DateTime dateFrom = from == null ? DateTime.MinValue : (DateTime) from;
            DateTime dateTo = to == null ? DateTime.MaxValue : (DateTime) to;

            return _context.LiquidDatas
                .Where(x => DateTime.Compare(x.Date, dateFrom) >= 0 && DateTime.Compare(x.Date, dateTo) <= 0)
                .ToList();
        }

        public LiquidData GetItemById(int id)
        {
            var result = _context.LiquidDatas
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return result;
        }

        public IList<LiquidData> GetItemsByKind(KindEnum kindEnum, DateTime? from, DateTime? to)
        {
            DateTime dateFrom = from == null ? DateTime.MinValue : (DateTime)from;
            DateTime dateTo = to == null ? DateTime.MaxValue : (DateTime)to;

            return _context.LiquidDatas
                .Where(x => x.Kind == kindEnum && DateTime.Compare(x.Date, dateFrom) >= 0 && DateTime.Compare(x.Date, dateTo) <= 0)
                .ToList();
        }

        public void DeleteItem(int id)
        {
            //LiquidData item = new LiquidData() { Id = id };
            //_context.LiquidDatas.Attach(item);
            var item = _context.LiquidDatas.Where(x => x.Id == id).FirstOrDefault();
            if (item == default) return;
            //_context.Entry(item).State = EntityState.Modified; //ToDo Dowiedzieć się dlaczego nie można zmockować Entry(item)
            _context.LiquidDatas.Remove(item);
            _context.SaveChanges();
        }
    }
}
