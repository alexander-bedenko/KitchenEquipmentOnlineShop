
using System.ComponentModel.DataAnnotations;

namespace KitchenEquipment.Enums
{
    public enum SinkType
    {
        [Display(Name = "1 чаша")]
        OneBowl,

        [Display(Name = "1.5 чаши")]
        OneAndAHalfBowl,

        [Display(Name = "2 чаши")]
        TwoBowls
    }
}
