using LiquidUse.Database.Model;
using System.Collections.Generic;

namespace LiquidUse.Services.Interfaces
{
    public interface ILiquidService
    {
        IList<LiquidData> GetLiquidDataItems();
    }
}
