using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitchenEquipmentOnlineShop.DataAccess.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            ExhaustHoods = new List<ExhaustHood>();
            Sinks = new List<Sink>();
        }

        [Required]
        public string CompanyName { get; set; }

        public string Country { get; set; }

        public ICollection<ExhaustHood> ExhaustHoods { get; set; }
        public ICollection<Sink> Sinks { get; set; }
    }
}
