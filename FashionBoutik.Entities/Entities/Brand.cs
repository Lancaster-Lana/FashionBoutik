using System.Collections.Generic;

namespace FashionBoutik.Entities
{
    public class Brand : BaseEntity<int>
    {
        //public Dictionary<string, string> Info { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}