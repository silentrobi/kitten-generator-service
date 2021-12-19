using System;
using System.ComponentModel.DataAnnotations;

namespace KittenGeneratorService.Domain.SeedWork
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
