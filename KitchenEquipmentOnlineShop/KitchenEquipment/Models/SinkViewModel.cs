using KitchenEquipment.Enums;

namespace KitchenEquipment.Models
{
    public class SinkViewModel : BaseViewModel
    {
        public CompanyViewModel Companies { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public SinkMaterial Material { get; set; }
        public SinkType Type { get; set; }
        public SinkForm Form { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }
        public float BowlDepth { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}
