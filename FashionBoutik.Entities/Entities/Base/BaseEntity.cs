using System;
using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Entities
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}