using GraduationProject.DTOS;
using GraduationProject.Models.Contracts;
using GraduationProject.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models.Entity
{
    public class Warehouse : _Base
    {
        public Warehouse() { }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDefault { get; set; } = false;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public ICollection<WarehouseProduct>? WarehouseProducts { get; set; }
        public ICollection<SalesOrderItem>? SalesOrderItem { get; set; }


    }
}
