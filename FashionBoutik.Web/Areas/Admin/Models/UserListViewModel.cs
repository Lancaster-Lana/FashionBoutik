namespace FashionBoutik.Models
{
    public class UserListViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }    
        public string RoleName { get; set; }

        /// <summary>
        /// Like Admins, Designers
        /// </summary>
        public string UsersGroupName { get; set; }    
    }
}
