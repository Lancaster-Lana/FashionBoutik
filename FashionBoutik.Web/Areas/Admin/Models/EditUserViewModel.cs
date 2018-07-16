using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FashionBoutik.Entities;

namespace FashionBoutik.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Role")]
        public int ApplicationRoleId { get; set; }
        public List<Role> ApplicationRoles { get; set; }

        [Display(Name = "UsersGroup")]
        public int UsersGroupId { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public IList<UsersGroupModel> UsersGroups { get; set; }    
    }
}
