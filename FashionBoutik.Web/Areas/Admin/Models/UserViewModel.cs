using FashionBoutik.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Role> ApplicationRoles { get; set; }

        [Display(Name = "Role")]
        public int? ApplicationRoleId { get; set; }


        [Display(Name = "Users Group")]
        public int? UsersGroupId { get; set; }
        /// <summary>
        /// All users groups (to be selected)
        /// TODO:  several groups can be assigned to user
        /// </summary>
        public IList<UsersGroupModel> UsersGroups { get; set; }
    }
}
