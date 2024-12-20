﻿using GraduationProject.Models.Enums;

namespace GraduationProject.DTOS
{
    public class ManufacturingReturnDto
    {
        public int? Id { get; set; }
        public string? Number { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ManufacturingReturnStatus? Status { get; set; }
        public string? GoodsReceive { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? Factory { get; set; }
        public Guid? RowGuid { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
    }
}
