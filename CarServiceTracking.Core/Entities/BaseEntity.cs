using System;

namespace CarServiceTracking.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
                public DateTime? ModifiedDate { get; set; }
    }
}