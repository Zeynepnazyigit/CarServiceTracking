using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class Payment
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public int PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public string? Reference { get; set; }

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
}
