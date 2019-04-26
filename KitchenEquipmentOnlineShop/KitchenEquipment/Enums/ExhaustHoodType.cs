using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Enums
{
    public enum ExhaustHoodType
    {
        [Display(Name = "Все модели")]
        All,

        [Display(Name = "Слайдер")]
        Slider,

        [Display(Name = "Классическая")]
        Classic,

        [Display(Name = "Модерн")]
        Modern,

        [Display(Name = "Ретро")]
        Retro,

        [Display(Name = "Встраиваемая")]
        BuiltIn
    }
}