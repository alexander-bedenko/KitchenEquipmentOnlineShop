using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Enums
{
    public enum SinkForm
    {
        [Display(Name = "Все модели")]
        All,

        [Display(Name = "Круглая - овальная")]
        CircleOval,

        [Display(Name = "Кадратная - прямоугольная")]
        SquareRectangle,

        [Display(Name = "Трапециевидная")]
        Trapezium
    }
}
