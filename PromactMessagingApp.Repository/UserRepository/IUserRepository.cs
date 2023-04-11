using PromactMessagingApp.DomainModel.ApplicationClasses.UserAC;
using PromactMessagingApp.DomainModel.ApplicationClasses.UserDetailAC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromactMessagingApp.Repository.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// List the All User details.
        /// </summary>
        /// <returns>Showing list of user details from the database</returns>
        Task<List<UserAC>> GetAllUserDetailAsync();

        /// <summary>
        /// Fetching the user details of the perticular user.
        /// </summary>
        /// <param name="Id">Get perticlar user deatails in the stores</param>
        /// <returns>Showing the details from the database</returns>
        Task<UserAC> GetUserByIdAsync(Guid Id);

        /// <summary>
        /// Add  new user details in database.
        /// </summary>
        /// <param name="user">Add new user or ragesterd in storage</param>
        /// <returns>Add new user ragistration. </returns>
        Task<UserAC> AddUserAsync(UserAC user);
        /// <summary>
        /// Update  User Detail.
        /// </summary>
        /// <param name="user">Stores the name of the current user.</param>
        /// <returns>Update UserName ,EmailId and Password In database.</returns>
        Task<UserDetailAC> UpdateUserDetailAsync(UserDetailAC userDetail);

        /// <summary>
        /// Updating user status for soft removing.
        /// </summary>
        /// <param name="Id">Id is used for particular user.</param>
        /// <returns>return object</returns>
        Task RemoveUserByIdAsync(Guid Id);

    }
}
