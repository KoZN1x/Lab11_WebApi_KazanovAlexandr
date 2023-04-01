using Lab11_KazanovAlexandr.Controllers;
using Lab11_KazanovAlexandr.Data;
using Lab11_KazanovAlexandr.Models;
using Lab11_KazanovAlexandr.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Protected;

namespace UserTest
{
    public class Tests
    {
        private UserController _userController;
        private Mock<IUserService> _serviceMoq;

        [SetUp]
        public void Setup()
        {
            _serviceMoq = new Mock<IUserService>();
            _userController = new UserController(_serviceMoq.Object);
        }

        [Test]
        public void Read_PositiveTesting_ShouldReturnNotEmptyList()
        {
            //Arrange
            User user = new User();
            _serviceMoq.Setup(x => x.GetAllUsers()).Returns(new List<User> { new User() });
            //Act
            var res = _userController.Read();
            //Assert
            Assert.IsNotEmpty(res);
        }

        [Test]
        public void Create_PositiveTesting_ReturnsOk()
        {
            //Arrange
            var addUser = new AddUserViewModel()
            {
                Email = "Test@mail.ru",
                Name = "Test Name",
                Password = "Test Password"
            };
            //Act
            var res = _userController.Create(addUser);
            var okResult = res as OkObjectResult;
            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Update_PositiveTesting_ReturnsOk()
        {
            //Arrange
            var id = 0;
            var updateUser = new AddUserViewModel()
            {
                Email = "Test@mail.ru",
                Name = "Test Name",
                Password = "Test Password"
            };
            _serviceMoq.Setup(x => x.GetUser(id)).Returns(new User());
            //Act
            var res = _userController.Update(id, updateUser);
            var okResult = res as OkObjectResult;
            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Update_PositiveTesting_Returns404()
        {
            //Arrange
            var id = 0;
            var updateUser = new AddUserViewModel()
            {
                Email = "Test@mail.ru",
                Name = "Test Name",
                Password = "Test Password"
            };
            _serviceMoq.Setup(x => x.GetUser(id)).Returns((User)null);
            //Act
            var res = _userController.Update(id, updateUser);
            var notFoundResult = res as NotFoundResult;
            //Assert
            Assert.IsNotNull(notFoundResult);
            Assert.That(notFoundResult.StatusCode, Is.EqualTo(404));
        }

        [Test]
        public void Delete_PositiveTesting_ReturnsOk()
        {
            //Arrange
            var id = 0;
            _serviceMoq.Setup(x => x.GetUser(id)).Returns(new User());
            //Act
            var res = _userController.Delete(id);
            var okResult = res as OkObjectResult;
            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Delete_PositiveTesting_Returns404()
        {
            //Arrange
            var id = 0;
            _serviceMoq.Setup(x => x.GetUser(id)).Returns((User)null);
            //Act
            var res = _userController.Delete(id);
            var notFoundResult = res as NotFoundResult;
            //Assert
            Assert.IsNotNull(notFoundResult);
            Assert.That(notFoundResult.StatusCode, Is.EqualTo(404));
        }
    }
}