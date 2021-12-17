using System;

namespace KittenGeneratorService.Domain.SeedWork
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public int RecordStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserGuid { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUserGuid { get; set; }
    }
}
