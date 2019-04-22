using System.ComponentModel.DataAnnotations;
using KitchenEquipmentOnlineShop.DataAccess.Enums;

namespace KitchenEquipmentOnlineShop.DataAccess.Entities
{
    public class ExhaustHood : BaseEntity
    {
        public int? CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public byte[] Image { get; set; }

        public ExhaustHoodType Type { get; set; }

        public int Width { get; set; }

        public string Color { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }
    }
}
