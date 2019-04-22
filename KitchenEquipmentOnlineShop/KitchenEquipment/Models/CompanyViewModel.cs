using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Models
{
    public class CompanyViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Введите название фирмы производителя")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Введите страну фирмы производителя")]
        public string Country { get; set; }
    }
}
