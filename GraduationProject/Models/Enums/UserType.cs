using System.ComponentModel;

namespace GraduationProject.Models.Enums
{
    public enum UserType
    {
        [Description("Customer")]
        Customer = 0,
        [Description("factories")]
        Factories = 1,
        [Description("Admin")]
        Admin = 2,
        [Description("WarehouseManager")]
        WarehouseManager = 2,
    }
}
