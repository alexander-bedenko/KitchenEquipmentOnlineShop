using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Enums
{
    public enum SinkForm
    {
        [Display(Name = "Круглая - овальная")]
        CircleOval,

        [Display(Name = "Кадратная - прямоугольная")]
        SquareRectangle,

        [Display(Name = "Трапециевидная")]
        Trapezium
    }
}
