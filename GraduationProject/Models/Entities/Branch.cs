using GraduationProject.Models.Contracts;
using GraduationProject.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models.Entities
{
    public class Branch : _Base
    {
        public Branch()
        {
            Warehouses = new HashSet<Warehouse>();
        }
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string BranchName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }
    }
}