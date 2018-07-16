
using System;
using System.Collections.Generic;

namespace FashionBoutik.Models
{
    public class BrandModel {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

        //public Dictionary<string, string> Info { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public ICollection<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}