using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Models;
using FashionBoutik.Core.Mappers;
using FashionBoutik.Entities;

namespace FashionBoutik.DomainServices
{
    /// <summary>
    /// Domain service to manage UsersGroup logic
    /// </summary>
    public class UsersGroupManager : DomainService, IUsersGroupManager
    {
        private readonly IUsersGroupRepository _repository;
        private readonly IUserToUsersGroupRepository _userToGroupRepository;
        private readonly UserManager<User> _userManager;

        #region ctor

        public UsersGroupManager(
            UserManager<User> userManager, 
            IUserToUsersGroupRepository userToGroupRepository,
            IUsersGroupRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
            _userToGroupRepository = userToGroupRepository;
        }

        public async Task<IList<UsersGroupModel>> GetAllUsersGroups()
        {
            var groupsWithUsers = (await _repository.GetAllIncluding("Users")).ToList();
            var list = groupsWithUsers?.MapTo<UsersGroupModel>();
            return list;
        }

        //public async Task<IList<UsersGroupModel>> GetAllUsersInGroups()
        //{
        //    var list = (await _repository.GetAll())?.MapTo<UserInGroupModel>();
        //    return list.ToList();
        //}

        public async Task<UsersGroupModel> GetUsersGroupById(int id)
        {
            var entity = await _repository.GetById(id);
            return entity?.MapTo<UsersGroupModel>();
        }

        //public async Task<IList<UsersGroupModel>> GetUserInGroups(int userId)
        //{
        //    var userGroups = await _userToGroupRepository.GetGroupsByUserId(userId);
        //    return userGroups.Select(uTg => uTg.UsersGroup) .MapTo<UsersGroupModel>();
        //}

        public async Task<IList<int>> GetUserInGroups(int userId)
        {
            var userGroups = await _userToGroupRepository.GetGroupsByUserId(userId);
            return userGroups.Select(uTg => uTg.UsersGroupId).ToList();
        }

        public async Task<bool> DeleteUsersGroup(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<bool> SaveUsersGroup(UsersGroupModel model)
        {
            var entity = model?.MapTo<UsersGroup>();
            if (model.Id < 1)
                //TODO: check if exist such name of users group
                await _repository.Insert(entity);
            else
                await _repository.Update(entity);

            return true;
        }

        /// <summary>
        /// Update the user memberships in groups
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newGroupsIds"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserGroups(int userId, IEnumerable<int> groupsIds)
        {
            var oldUserGroups = await _userToGroupRepository.GetGroupsByUserId(userId);

            //Remove old groups
            var groupsToBeRemoved = oldUserGroups.Where(g => !groupsIds.Contains(g.UsersGroupId));
            foreach (var remGroup in groupsToBeRemoved)
            {
                await _userToGroupRepository.Delete(remGroup);
            }

            //Add only a new membership User=>UserGroup
            var newGroupsIds = groupsIds.Except(oldUserGroups.Select(uGrp => uGrp.UsersGroupId));

            foreach (var groupsId in newGroupsIds)
            {
                //Create user group membership
                var userToGrp = new UserToUsersGroup { UserId = userId, UsersGroupId = groupsId };
                await _userToGroupRepository.Insert(userToGrp);
            };

            await _repository.SaveChanges();

            return true;
        }

        #endregion
    }
}