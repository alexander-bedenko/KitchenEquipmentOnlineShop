using System.ComponentModel.DataAnnotations;

namespace KitchenEquipmentOnlineShop.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
