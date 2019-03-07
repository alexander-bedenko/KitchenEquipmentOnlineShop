using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Models
{
    public class UserViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Введите Ваше имя")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Разные пароли")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }
    }
}
