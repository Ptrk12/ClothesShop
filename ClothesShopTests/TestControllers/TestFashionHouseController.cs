using ClothesShop.Controllers;
using ClothesShop.Data.Services;
using ClothesShop.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShopTests.TestControllers
{
    public class TestFashionHouseController
    {
        private readonly FashionHousesApiController _controller;
        private readonly Mock<IFashionHouseService> _mockService;

        public TestFashionHouseController()
        {
            _mockService = new Mock<IFashionHouseService>();
            _controller = new FashionHousesApiController(_mockService.Object);
        }

        [Fact]
        public async Task Get_WhenCalled_ShouldRetursOk()
        {
            var result = await _controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Get_WhenCalled_ShouldReturnsNumberOfFashionHouses()
        {
            _mockService.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<FashionHouse>() { new FashionHouse(), new FashionHouse(), new FashionHouse() });

            var result = await _controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var fashionHouses = Assert.IsType<List<FashionHouse>>(okResult.Value);

            Assert.Equal(3, fashionHouses.Count);
        }
        [Fact]
        public async Task Get_WhenCalled_ShouldReturnOk()
        {
            var fashionHouseId = 10;
            var fashionHouse = new FashionHouse()
            {
                Id = fashionHouseId,
                ProfilePictureUrl = "TestTestTest",
                FullName = "Test Full Name",
                Bio = "Test Bio"
            };

            _mockService.Setup(x => x.GetByIdAsync(fashionHouseId))
                .ReturnsAsync(fashionHouse);

            var result = await _controller.Get(10) as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Get_WhenCalled_ShouldReturnsSpecificFashionHouse()
        {
            var fashionHouseId = 10;
            var fashionHouse = new FashionHouse()
            {
                Id = fashionHouseId,
                ProfilePictureUrl = "TestTestTest",
                FullName = "Test Full Name",
                Bio = "Test Bio"
            };

            _mockService.Setup(x => x.GetByIdAsync(fashionHouseId))
                .ReturnsAsync(fashionHouse);

            var house = await _controller.Get(fashionHouseId) as OkObjectResult;

            Assert.Equal(fashionHouseId, (house.Value as FashionHouse).Id);
        }

        [Fact]
        public async Task Get_WhenCalled_ShouldReturnsNotFound()
        {
            var fashionHouseId = 1;

            _mockService.Setup(x => x.GetByIdAsync(fashionHouseId))
                .Returns(Task.FromResult<FashionHouse>(null));

            var result = await _controller.Get(fashionHouseId) as NotFoundResult;

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_InvalidModelState_AddAsyncCalledNever()
        {
            _controller.ModelState.AddModelError("FullName", "FullName field is required");

            var fashionHouse = new FashionHouse()
            {
                ProfilePictureUrl = "TestUrl",
                Bio = "TestBio"
            };

            _mockService.Verify(x => x.AddAsync(It.IsAny<FashionHouse>()), Times.Never);
        }

        [Fact]
        public async Task Post_ValidModelState_AddSyncCalledOnce()
        {
            FashionHouse? house = null;

            _mockService.Setup(x => x.AddAsync(It.IsAny<FashionHouse>()))
                .Callback<FashionHouse>(x => house = x);

            var fashionHouse = new FashionHouse()
            {
                FullName = "TestName",
                Bio = "TestBio",
                ProfilePictureUrl = "TestUrl"
            };

            await _controller.Create(fashionHouse);
            _mockService.Verify(x => x.AddAsync(It.IsAny<FashionHouse>()), Times.Once);

            Assert.Equal(house.FullName, fashionHouse.FullName);
            Assert.Equal(house.Bio, fashionHouse.Bio);
            Assert.Equal(house.ProfilePictureUrl, fashionHouse.ProfilePictureUrl);
        }

        [Fact]
        public async Task Delete_WhenCalled_DeleteAsyncCalledOnce()
        {
            _mockService.Setup(x => x.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<bool>(true));

            await _controller.Delete(It.IsAny<int>());

            _mockService.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Delete_WhenCalled_ShouldReturnsOk()
        {
            _mockService.Setup(x => x.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<bool>(true));

            var result = await _controller.Delete(It.IsAny<int>());

            _mockService.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_WhenCalled_ShouldReturnsNotFound()
        {
            _mockService.Setup(x => x.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<bool>(false));

            var result = await _controller.Delete(It.IsAny<int>());

            Assert.IsType<NotFoundResult>(result);
        }
    }

}
