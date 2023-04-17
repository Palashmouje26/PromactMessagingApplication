using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromactMessagingApp.DomainModel.ApplicationClasses.ActiveUserAC;
using PromactMessagingApp.DomainModel.ApplicationClasses.LoginAC;
using PromactMessagingApp.DomainModel.ApplicationClasses.UserAC;
using PromactMessagingApp.DomainModel.Models.Login;
using PromactMessagingApp.DomainModel.Models.User;
using PromactMessagingApp.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromactMessagingApp.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {

        #region Private Methods
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public LoginRepository(IDataRepository dataRepository, IMapper mapper)
        {
            _mapper = mapper;
            _dataRepository = dataRepository;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Adding and checking user validate Or not If valid then login and store in data.
        /// </summary>
        /// <param name="emailId">Current User emailID.</param>
        /// <param name="password">Current user Password.</param>
        /// <returns>User Valid or not retrun.</returns>
        public async Task<LoginAC> AddLoginUserAsync (string emailId, string password)
        {
            UserLogin loginDetail = new UserLogin();
            loginDetail.LoginDate = DateTime.Now;

            var userDetail = await _dataRepository.FirstOrDefaultAsync<UserInformation>(x => x.Email.Equals(emailId) && x.Password.Equals(password));

            if (userDetail != null)
            {
                loginDetail.UserId = userDetail.Id;
                loginDetail.IsValidate = true;
            }
            else
            {
                var response = await _dataRepository.FirstOrDefaultAsync<UserInformation>(x => x.Email == emailId);
                loginDetail.UserId = response.Id;
                loginDetail.IsValidate = false;
            }
            await _dataRepository.AddAsync(loginDetail);
            return _mapper.Map<LoginAC>(loginDetail);
        }
        /// <summary>
        /// Showing active user in list.
        /// </summary>
        /// <returns>List of user.</returns>
        public async Task<List<ActiveUserAC>> GetActiveUserAsync()
        {
            var loginDetail = await _dataRepository.Where<UserInformation>(x => x.Status).AsNoTracking().ToListAsync();
            var activeuserdata = loginDetail.Select(a => new ActiveUserAC
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                ProfilePhoto = a.ProfilePhoto,
                Status = a.Status,

            }).ToList();
            return activeuserdata;
        }
        #endregion
    }
}
