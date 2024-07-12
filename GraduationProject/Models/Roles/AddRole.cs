using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models.Roles
{
    public class AddRole
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}