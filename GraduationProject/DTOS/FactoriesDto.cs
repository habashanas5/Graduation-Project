﻿namespace GraduationProject.DTOS
{
    public class FactoriesDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Description { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Website { get; set; }
        public string? FactoryType { get; set; }
        public string? FactoryClassification { get; set; }
        public Guid? RowGuid { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
        public int? Ranking { get; set; }

    }
}
