using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum ManufacturingReturnStatus
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Approved")]
        Approved = 1,
        [Description("Rejected")]
        Rejected = 2,
        [Description("Shipped")]
        Shipped = 3,
        [Description("Partially Shipped")]
        PartiallyShipped = 4,
        [Description("Completed")]
        Completed = 5,
        [Description("Archived")]
        Archived = 6
    }
}
