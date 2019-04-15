using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Enums
{
    public enum SinkType
    {
        [Display(Name = "Нержавеющая сталь")]
        StainlessSteel,

        [Display(Name = "Гранит")]
        Granite
    }
}