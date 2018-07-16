
using System;

namespace FashionBoutik.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }

        public string CategoryName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        //public EntityPublishStatus PublishStatus { get; set; }

        public string Image { get; set; }

        public string Status { get; set; }

        //public int CortexicaCategoryId { get; set; }

        //public int ExploreColorModuleRatio { get; set; }

        //public int ExploreMotifModuleRatio { get; set; }

        //public int ExplorePatternModuleRatio { get; set; }

        //public int ExploreShapeModuleRatio { get; set; }

        //public string FullCategoryHierarchicalId { get; set; }

        //public string FullCategoryHierarchicalIdEnd { get; set; }

        //public uint HierarchicalId { get; set; }

        //public uint HierarchicalLevel { get; set; }

        //public int MatchColorModuleRatio { get; set; }

        //public int MatchMotifModuleRatio { get; set; }

        //public int MatchPatternModuleRatio { get; set; }

        //public int MatchShapeModuleRatio { get; set; }
    }
}