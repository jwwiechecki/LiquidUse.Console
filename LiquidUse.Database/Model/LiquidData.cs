using LiquidUse.Common.Enums;
using System;

namespace LiquidUse.Database.Model
{
    public class LiquidData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Use { get; set; }
        public KindEnum Kind { get; set; }
    }
}
