using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class CustomerCar
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string BrandModel { get; set; } = null!;

    public string PlateNumber { get; set; } = null!;

    public int Year { get; set; }

    public int Mileage { get; set; }

    public string? Color { get; set; }

    public bool IsInService { get; set; }

    public int? CarId { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
