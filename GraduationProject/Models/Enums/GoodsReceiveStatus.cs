using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum GoodsReceiveStatus
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Received")]
        Received = 1,
        [Description("Partially Received")]
        PartiallyReceived = 2,
        [Description("Rejected")]
        Rejected = 3,
        [Description("Completed")]
        Completed = 4,
        [Description("Archived")]
        Archived = 5
    }
}