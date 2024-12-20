﻿using GraduationProject.Models.Contracts;
using GraduationProject.Models.Enums;

namespace GraduationProject.Models.Entities
{
    public class PurchaseReturn : _Base
    {
        public PurchaseReturn() { }
        public string? Number { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ManufacturingReturnStatus? Status { get; set; }
        public string? Description { get; set; }
        public required int GoodsReceiveId { get; set; }
        public GoodsReceive? GoodsReceive { get; set; }
    }
}
