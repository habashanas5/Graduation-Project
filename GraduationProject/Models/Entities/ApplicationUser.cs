using GraduationProject.Models.Contracts;
using GraduationProject.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GraduationProject.Models.Entities
{
    public class ApplicationUser : IdentityUser, IHasAudit, IHasSoftDelete
    {
        public ApplicationUser()
        {
            CreatedAtUtc = DateTime.UtcNow;
        }

        //[Required, MaxLength(100)]
        public string? FirstName { get; set; }

        //[Required, MaxLength(100)]
        public string? LastName { get; set; }

        public byte[]? ProfilePicture { get; set; }
        public string? FullName { get; set; }
        public string? JobTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? Avatar { get; set; }
        public UserType UserType { get; set; } = UserType.Customer;
        public List<UserType> SelectedRoles { get; set; } = new List<UserType>();
        public bool IsDefaultAdmin { get; set; } = false;
        public bool IsOnline { get; set; } = false;
        public required int SelectedCompanyId { get; set; }
        public Company? SelectedCompany { get; set; }
        public required int CustomerGroupIdUser { get; set; }
        public CustomerGroup? CustomerGroup { get; set; }
        public required int CustomerCategoryIdUser { get; set; }
        public CustomerCategory? CustomerCategory { get; set; }
        //IHasAudit
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
        public string? UpdatedByUserId { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }

        [NotMapped]
        public string? CreatedByUserName { get; set; }
        [NotMapped]
        public string? UpdatedByUserName { get; set; }
        [NotMapped]
        public string? CreatedAtString { get; set; }
        [NotMapped]
        public string? UpdatedAtString { get; set; }


        //IHasSoftDelete
        public bool IsNotDeleted { get; set; } = true;

    }
}
