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
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Role")]
        public int ApplicationRoleId { get; set; }
        public IEnumerable<RoleViewModel> AllAppRoles { get; set; }

        //[Display(Name = "UsersGroup")]
        //public int UsersGroupId { get; set; }

        /// <summary>
        /// The users groups the user belong to
        /// </summary>
        public IEnumerable<int> UsersGroupsIds { get; set; }

        /// <summary>
        /// All users groups
        /// </summary>
        public IEnumerable<UsersGroupModel> AllUsersGroups { get; set; }

    }
}
