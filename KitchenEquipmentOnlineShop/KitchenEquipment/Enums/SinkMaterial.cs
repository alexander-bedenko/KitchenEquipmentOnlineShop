using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Enums
{
    public enum SinkMaterial
    {
        [Display(Name = "Нержавеющая сталь")]
        StainlessSteel,

        [Display(Name = "Гранит")]
        Granite
    }
}