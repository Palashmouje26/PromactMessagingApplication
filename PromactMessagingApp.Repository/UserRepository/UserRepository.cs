using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PromactMessagingApp.DomainModel.ApplicationClasses.UserAC;
using PromactMessagingApp.DomainModel.Models.User;
using PromactMessagingApp.Repository.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PromactMessagingApp.Repository.User
{
    public class UserRepository : IUserRepository
    {
        #region PrivetMember
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constructor
        public UserRepository(IDataRepository dataRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// This method is used for showing all list of user.
        /// </summary>
        /// <returns>returs to showing list </returns>
        public async Task<List<UserAC>> GetAllUserDetailAsync()
        {
            var userDetail = await _dataRepository.Where<UserInformation>(x => x.Status).AsNoTracking().ToListAsync();

            return _mapper.Map<List<UserInformation>, List<UserAC>>(userDetail);
        }

        /// <summary>
        /// This method is used for showing one user detail using Id.
        /// </summary>
        /// <param name="Id">Id is used for user details.</param>
        /// <returns>return show user details</returns>
        public async Task<UserAC> GetUserByIdAsync(string Id)
        {
            if (Guid.TryParse(Id, out Guid value))
            {
                var userDetail = await _dataRepository.FirstAsync<UserInformation>(a => a.Id == value);
                return _mapper.Map<UserAC>(userDetail);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///This method used for to add or store user to the database.
        /// </summary>
        /// <param name="user">It is current used for store the user</param>
        /// <returns>return object</returns>
        public async Task<UserAC> AddUserAsync(UserAC user)
        {
            var newUser = _mapper.Map<UserAC, UserInformation>(user);
            var response = await _dataRepository.FirstOrDefaultAsync<UserInformation>(x => x.Email == user.Email);
            if (response != null && response.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase))// Checking EmailId Is same or not 
            {
                throw new Exception("EmailId already exists");
            }
            else
            {
                var image = this.CheckImageValidationAsync(user);

                UserInformation addUser = new UserInformation()
                {
                    Id = newUser.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    SubscriptionLevel = user.SubscriptionLevel,
                    Status = user.Status,
                    Created = DateTime.Now,
                    ProfilePhoto = user.Image.FileName,
                    Notes = user.Notes
                };
                await _dataRepository.AddAsync(addUser);
                return _mapper.Map<UserAC>(addUser);
            }
        }

        /// <summary>
        /// This Method is updating user details.
        /// </summary>
        /// <param name="userDetail">This details update user details.</param>
        /// <returns>It retuns the result</returns>
        public async Task<UserAC> UpdateUserDetailAsync(UserAC userDetail)
        {
            if (userDetail.Id != null && Guid.TryParse(userDetail.Id, out Guid value))
            {
                var userData = await _dataRepository.FirstOrDefaultAsync<UserInformation>(x => x.Id == value);
                var response = _mapper.Map<UserAC, UserInformation>(userDetail, userData);
                response.ProfilePhoto = this.CheckImageValidationAsync(userDetail);
                await _dataRepository.UpdateAsync(response);
                return _mapper.Map<UserAC>(userData);
            }
            else
            {
                throw new Exception("Please Enter UserId");
            }
        }

        /// <summary>
        /// This Method is used for status change from active to inactive user.
        /// </summary>
        /// <param name="Id">Id is used for particuller user status change.</param>
        /// <returns>return status change.</returns>
        public async Task RemoveUserByIdAsync(string Id)
        {
            if (Guid.TryParse(Id, out Guid value))
            {
                var userDetail = await _dataRepository.FirstOrDefaultAsync<UserInformation>(a => a.Id == value);
                if (userDetail != null)
                {
                    userDetail.Status = false;
                }
                else
                {
                    throw new Exception("User Not Exits");
                }
                await _dataRepository.UpdateAsync(userDetail);
            }
            else
            {
                throw new Exception("User Not Exits");
            }                  
        }
        #endregion


        #region Private Methods
        /// <summary>
        /// This Method is checking the file formate of image.
        /// </summary>
        /// <param name="userProfilePhoto">Current images fromate checking.</param>
        /// <returns>When file is validate then return true else false.</returns>
        private bool UserProfileAsync(IFormFile userProfilePhoto)  // checking the file is jpg ,jpeg and png formate // 
        {
            var supportedtype = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(userProfilePhoto.FileName);
            if (!supportedtype.Contains(fileExtension))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This Methods is checking Images details like path and length.
        /// </summary>
        /// <param name="user"> It is current used for image details check.</param>
        /// <returns> return Object .</returns>
        private string CheckImageValidationAsync(UserAC user)
        {
            if (user.Image.Length >= 4194304)
            {
                throw new Exception("Image file is more than the 4MB");
            }
            else if (!UserProfileAsync(user.Image))
            {
                throw new Exception("File extension is not supported.");
            }
            else
            {
                var directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath +
                  "\\ProfileImages\\"); // receving the image path tho save.
                var filePath = Path.Combine(directoryPath, user.Image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    user.Image.CopyTo(stream);
                }
                return filePath;
            }
        }

        #endregion
    }
}
