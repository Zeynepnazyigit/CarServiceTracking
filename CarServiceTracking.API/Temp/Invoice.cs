using System;
using System.Collections.Generic;

namespace CarServiceTracking.API.Temp;

public partial class Invoice
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public int ServiceRequestId { get; set; }

    public int CustomerId { get; set; }

    public decimal PartsTotal { get; set; }

    public decimal LaborCost { get; set; }

    public decimal SubTotal { get; set; }

    public decimal TaxRate { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal GrandTotal { get; set; }

    public int PaymentStatus { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal RemainingAmount { get; set; }

    public DateTime? DueDate { get; set; }

    public string? Notes { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ServiceRequest ServiceRequest { get; set; } = null!;
}
