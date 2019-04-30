using System.ComponentModel.DataAnnotations;
using KitchenEquipmentOnlineShop.DataAccess.Enums;

namespace KitchenEquipmentOnlineShop.DataAccess.Entities
{
    public class Sink : BaseEntity
    {
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public SinkMaterial Material { get; set; }
        public SinkType Type { get; set; }
        public SinkForm Form { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }
        public float BowlDepth { get; set; }
        public string Color { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }
    }
}
