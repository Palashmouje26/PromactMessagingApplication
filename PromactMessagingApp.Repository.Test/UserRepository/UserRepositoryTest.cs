using Microsoft.AspNetCore.Mvc;
using Moq;
using Promact_Messaging_Application.Controllers;
using PromactMessagingApp.DomainModel.ApplicationClasses.UserAC;
using PromactMessagingApp.DomainModel.Enum;
using PromactMessagingApp.Repository.Data;
using PromactMessagingApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PromactMessagingApp.Repository.Test.UserRepository
{
    public class UserRepositoryTest
    {
        #region Private Variables
        #region Dependencies
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private readonly UserController _userController;
        private readonly Mock<IDataRepository> _dataRepository;
        #endregion
        #endregion

        #region Constructor
        public UserRepositoryTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _dataRepository = new Mock<IDataRepository>();
            _userController = new UserController(_userRepository.Object);

        }
        #endregion

        #region Testing Methods
        /// <summary>
        /// This test case used to show all user detail in list view.
        /// </summary>
        [Fact]
        public async Task GetAllOrganizationDetailTest()
        {
            //Arrange
            _userRepository.Setup(x => x.GetAllUserDetailAsync()).ReturnsAsync(new List<UserAC>() { new UserAC(), new UserAC() });
            //Art
            var result = await _userController.GetUserDetailAsync();
            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var organization = Assert.IsType<List<UserAC>>(viewResult.Value);
            Assert.Equal(2, organization.Count);
        }

        private UserAC GetUserAC()
        {
            var user = new UserAC();

            user.Id = "0D03127A-C1A4-4336-8D25-E6AC92F0B246";
            user.FirstName = "palash";
            user.LastName = "mouje";
            user.Email = "rahaul@gmail.com";
            user.Password = "Rahul@123";
            user.SubscriptionLevel = SubscriptionLevel.Gold;
            user.Status = true;
            user.CreatedAt = DateTime.Now;            
            user.Notes = "dfghjkl";

            return user;
        }

        #endregion
    }
}
