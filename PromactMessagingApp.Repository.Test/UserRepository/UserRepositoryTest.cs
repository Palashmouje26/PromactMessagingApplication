using Microsoft.AspNetCore.Mvc;
using Moq;
using Promact_Messaging_Application.Controllers;
using PromactMessagingApp.DomainModel.ApplicationClasses.UserAC;
using PromactMessagingApp.Repository.Data;
using PromactMessagingApp.Repository.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PromactMessagingApp.Repository.Test.UserRepository
{
    public class UserRepositoryTest
    {
        #region Private Variables
        #region Dependencies
        private readonly Mock<IUserRepository> _userRepository;
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

        [Fact]

        #endregion
    }
}
