using LiquidUse.Common.Enums;
using LiquidUse.Database.Model;
using System.Collections.Generic;

namespace LiquidUse.Services.Interfaces
{
    public interface ILiquidUseService
    {
        IList<LiquidData> GetItems(DateTime? from, DateTime? to);
        LiquidData GetItemById(int id);
        IList<LiquidData> GetItemsByKind(KindEnum kindEnum);
    }
}
