using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum StockCountStatus
    {
        [Description("Scheduled")]
        Scheduled = 0,
        [Description("In Progress")]
        InProgress = 1,
        [Description("Completed")]
        Completed = 2,
        [Description("Reviewed")]
        Reviewed = 3,

    }
}
