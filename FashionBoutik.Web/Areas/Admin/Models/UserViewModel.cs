using FashionBoutik.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<Role> ApplicationRoles { get; set; }

        [Display(Name = "Role")]
        public int? ApplicationRoleId { get; set; }


        [Display(Name = "Users Groups")]
        public IEnumerable<int> UsersGroupsIds { get; set; }

        /// <summary>
        /// All users groups (to be selected)
        /// TODO:  several groups can be assigned to user
        /// </summary>
        public IEnumerable<UsersGroupModel> AllUsersGroups { get; set; }
    }
}
