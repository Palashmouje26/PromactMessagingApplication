using PromactMessagingApp.DomainModel.ApplicationClasses.ActiveUserAC;
using PromactMessagingApp.DomainModel.ApplicationClasses.LoginAC;
using PromactMessagingApp.DomainModel.ApplicationClasses.UserAC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromactMessagingApp.Repository.Login
{
    public interface ILoginRepository
    {
        /// <summary>
        /// Adding user by login method.
        /// </summary>
        /// <param name="emailId">emailid is used for checking particular user email.</param>
        /// <param name="password"> passcode is used for checking particular user password</param>
        /// <returns> return user login </returns>
        Task<LoginAC> AddLoginUserAsync (string emailId, string password);

        /// <summary>
        /// List Of Active User.
        /// </summary>
        /// <returns>List of active user show.</returns>
        Task<List<ActiveUserAC>> GetActiveUserAsync();
    }
}
