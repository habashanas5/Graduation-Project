using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum UserType
    {
        [Description("Customer")]
        Customer = 0,
        [Description("Vendor")]
        Vendor = 1,
        [Description("Admin")]
        Admin = 2
    }
}
