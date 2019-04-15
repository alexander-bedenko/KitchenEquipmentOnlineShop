using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Enums
{
    public enum ExhaustHoodType
    {
        [Display(Name = "Встраиваемая")]
        BuiltIn,

        [Display(Name = "Классическая")]
        Classic,

        [Display(Name = "Ретро")]
        Retro,

        [Display(Name = "Модерн")]
        Modern,

        [Display(Name = "Слайдер")]
        Slider
    }
}
