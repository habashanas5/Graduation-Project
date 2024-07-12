using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum InventoryTransType
    {
        [Description("In")]
        In = 1,
        [Description("Out")]
        Out = -1,
    }
}
