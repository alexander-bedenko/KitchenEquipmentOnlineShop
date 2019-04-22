using KitchenEquipmentOnlineShop.BusinessLogic.Enums;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Dtos
{
    public class SinkDto : BaseDto
    {
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public SinkMaterial Material { get; set; }
        public SinkType Type { get; set; }
        public SinkForm Form { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}
