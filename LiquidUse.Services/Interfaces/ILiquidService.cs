using LiquidUse.Database;
using LiquidUse.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidUse.Services.Interfaces
{
    public interface ILiquidService
    {
        IList<LiquidData> GetLiquidDataItems();
    }
}
