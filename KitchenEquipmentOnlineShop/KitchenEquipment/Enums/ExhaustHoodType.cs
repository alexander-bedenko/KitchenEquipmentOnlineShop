using System.ComponentModel;

namespace KitchenEquipment.Enums
{
    public enum ExhaustHoodType
    {
        [DisplayName("Встраиваемая")]
        BuiltIn,

        [DisplayName("Классическая")]
        Classic,

        [DisplayName("Ретро")]
        Retro,

        [DisplayName("Модерн")]
        Modern,

        [DisplayName("Слайдер")]
        Slider
    }
}
