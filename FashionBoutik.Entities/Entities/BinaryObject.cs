using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    public class BinaryObject : BaseEntity<long>
    {
        /// <summary>
        /// Maximum length of the <see cref="ContentType"/> property.
        /// </summary>
        public const int MaxContentTypeLength = 256;

        public const int MaxFileNameLength = 256;

        public virtual int? TenantId { get; set; }

        [Required]
        public virtual byte[] Bytes { get; set; }

        [StringLength(MaxContentTypeLength)]
        public string ContentType { get; set; }

        //public int? ProductId { get; set; }
        //[ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        
        /// <summary>
        /// Get\set file name
        /// </summary>
        //[MaxLength(MaxFileNameLength)]
        //public string Name { get; set; }

        /// <summary>
        /// User who attached file. 
        /// </summary>
        //[ForeignKey("CreatorUserId")]  /// Note: Will be retrieved automatically by CreatorUserId from base FullAuditedEntity
        public virtual User CreatorUser { get; set; }

        //public BinaryObject()
        //{
        //    Id = Guid.NewGuid();
        //}
        //public BinaryObject(int? tenantId, byte[] bytes)
        //    : this()
        //{
        //    TenantId = tenantId;
        //    Bytes = bytes;
        //}
    }
}
