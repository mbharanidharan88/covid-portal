using System;

namespace CovidPortal.Domain.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
