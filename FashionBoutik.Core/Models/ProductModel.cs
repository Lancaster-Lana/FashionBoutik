using System;
using System.Collections.Generic;
using FashionBoutik.Entities;

namespace FashionBoutik.Models
{
    public class ProductModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get;  set; }

        public CategoryModel Category { get; set; }

        //public int BrandId { get; set; }

        public BrandModel Brand { get; set; }

        public ColorModel Color { get; set; }

        //public ColorPallet Color { get; set; }

        //[typeof(StatusEnum)]
        public string Status { get; set; }

        public PriceModel PricePerUnit { get; set; }

        public Dictionary<DateTime, PriceModel> PriceHistory { get; set; } = new Dictionary<DateTime, PriceModel>();

        public ICollection<BinaryObjectModel> Attachments { get; set; } = new List<BinaryObjectModel>();

        /// <summary>
        /// TODO: list of available sizes
        /// </summary>
        public ICollection<SizeModel> Sizes { get; set; } = new List<SizeModel>();
    }
}