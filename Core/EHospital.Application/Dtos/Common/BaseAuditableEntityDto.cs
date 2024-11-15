﻿namespace EHospital.Application.Dtos.Common;

public abstract class BaseAuditableEntityDto
{
    public int? Id { get; set; }
    public DateTime? CreatedAt { get; set; }= DateTime.Now;
    public DateTime? UpdatedAt { get; set; }=DateTime.Now;
}
