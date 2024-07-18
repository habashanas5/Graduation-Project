using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum ManufacturingReturnStatus
    {
        [Description("Draft")]
        Draft = 0,
        [Description("Cancelled")]
        Cancelled = 1,
        [Description("Completed")]
        Completed = 2,
        [Description("Archived")]
        Archived = 3
    }
}
