using LiquidUse.Common.Enums;

namespace LiquidUse.Database.Model
{
    public class LiquidKind
    {
        public int Id { get; set; }
        public KindEnum Kind { get; set; }
        public string Description { get; set; }
    }
}
