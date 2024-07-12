using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum ScrappingStatus
    {
        [Description("Pending")]
        Pending = 0,
        [Description("In Progress")]
        InProgress = 1,
        [Description("Confirmed")]
        Confirmed = 2,
        [Description("Archived")]
        Archived = 3
    }
}
