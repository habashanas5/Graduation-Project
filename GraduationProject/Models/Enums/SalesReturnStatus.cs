using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum SalesReturnStatus
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Approved")]
        Approved = 1,
        [Description("Rejected")]
        Rejected = 2,
        [Description("Processed")]
        Processed = 3,
        [Description("Completed")]
        Completed = 4,
        [Description("Archived")]
        Archived = 5

    }
}
