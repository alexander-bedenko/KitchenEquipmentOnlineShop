using KitchenEquipment.Enums;

namespace KitchenEquipment.Models
{
    public class ExhaustHoodViewModel : BaseViewModel
    {
        public CompanyViewModel Companies { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public ExhaustHoodType Type { get; set; }
        public int Width { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}
