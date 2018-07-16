using FashionBoutik.Entities;
using System;

namespace FashionBoutik.Models
{
    public class BinaryObjectModel 
    {
      public long Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[] Bytes { get; set; }

        public string ContentType { get; set; }

        public int? ProductId { get; set; }

        public ProductModel Product { get; set; }

        public  User CreatorUser { get; set; }
    }
}
