using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionBoutik.Entities
{
    /// <summary>
    /// Product category entity. For example: shoes, skirts, hats
    /// TODO: also can be created CategoryEnum {shoes = 1, skirts=2, ... }
    /// </summary>
    public sealed class Category : BaseEntity<int>
    {
        [NotMapped]
        public Dictionary<string, string> Info { get; set; }

        public int? ParentId { get; set; } = null;

        public string Description { get; set; }

        public string Image { get; set; }

        //public int ExploreColorModuleRatio { get; set; }

        //public int ExploreMotifModuleRatio { get; set; }

        //public int ExplorePatternModuleRatio { get; set; }

        //public int MatchColorModuleRatio { get; set; }

        //public IDictionary<string, int> MatchParams { get; set; }

        //public int MatchPatternModuleRatio { get; set; }

        //public int MatchShapeModuleRatio { get; set; }
    }
}
