using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Role Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
