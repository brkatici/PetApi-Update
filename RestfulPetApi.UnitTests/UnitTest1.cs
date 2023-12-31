using AutoMapper;
using Moq;
using RestfulPetApi.Controllers;
using RestfulPetApi.Repositories;
using RestfulPetApi.MapperProfile;
using RestfulPetApi.Services;
using RestfulPetApi.Validators;
using RestfulPetApi.Models;
using RestfulPetApi.DTOs;
using Assert = Xunit.Assert;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestfulPetApi.UnitTests
{
    public class UnitTest1
    {
        private UsersController _controller;
        private Mock<UserClassRepo> _userRepoMock;
        private IMapper _mapper;
        private Validators.UserClassValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile.MapperProfile()); // Your AutoMapper profile
            });
            _mapper = config.CreateMapper();

            _userRepoMock = new Mock<UserClassRepo>();
            _controller = new UsersController(
                userValidator: null, // Burada gereken nesneleri ge�melisiniz
                mapper: _mapper,
                userService: new UserService(_userRepoMock.Object, _mapper,_validator)
            );
        }

        [TestMethod]
        public async Task GetUserById_Returns_OkResult()
        {
            // Arrange
            int userId = 1;
            var user = new User { UserId = userId, /* Di�er �zellikler */ };
            var userDto = new UserDTO { UserId = userId, /* Di�er �zellikler DTO'ya d�n��t�r�lmeli */ };

            _userRepoMock.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserById(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UserDTO>(okResult.Value);
            Assert.Equal(userDto.UserId, returnedUser.UserId);
            // Di�er �zelliklerin kontrol� i�in gerekli assert'ler eklenebilir
        }

        // Di�er testler buraya eklenebilir...
    }
}