using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests.Services
{
    public class UserServiceTests 
    {
        private  Mock<IUserRepository> _userRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private UserService _userServiceMock;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _userServiceMock = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task RegisterAsync_Should_Call_AddAsync_Minimum_Once()
        {
            
            await _userServiceMock.RegisterAsync("user@email.com", "user", "secret");

            _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task RegisterAsync_Should_Throw_An_Exception_If_User_Exists()
        { 
            string testMail = "user1000@gmail.com";
            _userRepositoryMock.Setup(x => x.GetAsync(testMail)).
            ReturnsAsync(It.Is<User>(x => x.Email == testMail));

            await Task.FromResult(Assert.ThrowsAsync<Exception>(() =>  _userServiceMock.RegisterAsync(testMail ,"user","secret")));
            
        }
    }
}