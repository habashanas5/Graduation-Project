﻿using GraduationProject.Models.Contracts;
using GraduationProject.Models.Entity;
using GraduationProject.Models.Enums;

namespace GraduationProject.Models.Entities
{
    public class Scrapping : _Base
    {
        public Scrapping() { }
        public string? Number { get; set; }
        public DateTime? ScrappingDate { get; set; }
        public ScrappingStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
