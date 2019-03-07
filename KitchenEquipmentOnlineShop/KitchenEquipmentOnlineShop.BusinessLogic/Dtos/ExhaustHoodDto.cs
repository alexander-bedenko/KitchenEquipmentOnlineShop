
using KitchenEquipmentOnlineShop.BusinessLogic.Enums;

namespace KitchenEquipmentOnlineShop.BusinessLogic.Dtos
{
    public class ExhaustHoodDto : BaseDto
    {
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public ExhaustHoodType Type { get; set; }
        public int Width { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}
