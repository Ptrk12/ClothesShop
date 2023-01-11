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
    public class TestDesignerController
    {
        private readonly Mock<IDesignerService> _mockService;
        private readonly DesignersApiController _controller;

        public TestDesignerController()
        {
            _mockService = new Mock<IDesignerService>();
            _controller = new DesignersApiController(_mockService.Object);
        }

        [Fact]
        public async Task Get_WhenCalled_ShouldReturnsOk()
        {
            var result = await _controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Get_WhenCalled_ShouldReturnsNumberOfDesigners()
        {
            _mockService.Setup(x => x.GetAllAsync())
               .ReturnsAsync(new List<Designer>() { new Designer(), new Designer(), new Designer() });

            var result = await _controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var designers = Assert.IsType<List<Designer>>(okResult.Value);

            Assert.Equal(3, designers.Count);
        }

        [Fact]
        public async Task Get_WhenCalled_ShouldReturnsSpecificDesigner()
        {
            var designerId = 10;
            var designer = new Designer()
            {
                Id=designerId,
                FullName = "Test",
                Bio = "Test",
                ProfilePictureUrl = "TestUrl",
            };

            _mockService.Setup(x => x.GetByIdAsync(designerId))
                .ReturnsAsync(designer);

            var result = await _controller.Get(designerId) as OkObjectResult;

            Assert.Equal(designerId, (result.Value as Designer).Id);
        }

        [Fact]
        public async Task Get_WhenCalled_ShouldReturnsNotFound()
        {
            var designerId = 10;

            _mockService.Setup(x => x.GetByIdAsync(designerId))
                .Returns(Task.FromResult<Designer>(null));

            var result = await _controller.Get(designerId) as NotFoundResult;

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_ValidModelState_AddNewDesignerCalledOnce()
        {
            Designer? design= null;

            _mockService.Setup(x => x.AddAsync(It.IsAny<Designer>()))
                .Callback<Designer>(x => design = x);

            var designerId = 10;
            var designer = new Designer()
            {
                Id = designerId,
                FullName = "Test",
                Bio = "Test",
                ProfilePictureUrl = "TestUrl",
            };

            await _controller.Create(designer);

            _mockService.Verify(x => x.AddAsync(It.IsAny<Designer>()), Times.Once);

            Assert.Equal(design.FullName, designer.FullName);
            Assert.Equal(design.Bio, designer.Bio);
            Assert.Equal(design.ProfilePictureUrl, designer.ProfilePictureUrl);
        }

        [Fact]
        public async Task Post_WhenCalled_ShouldReturnsCreated()
        {
            var designerId = 10;
            var designer = new Designer()
            {
                Id = designerId,
                FullName = "Test",
                Bio = "Test",
                ProfilePictureUrl = "TestUrl",
            };

            var result = await _controller.Create(designer);

            _mockService.Verify(x => x.AddAsync(It.IsAny<Designer>()), Times.Once);

            var createdResult = Assert.IsType<CreatedResult>(result);

            Assert.Equal($"/api/designer/{designerId}", createdResult.Location);
        }

        [Fact]
        public async Task Post_InvalidModelState_AddNewDesignerNeverCalled()
        {
            _controller.ModelState.AddModelError("FullName", "FullName field is required");

            var designer = new Designer()
            {
                Bio = "TestBio",
                ProfilePictureUrl = "TestUrl"
            };

            var result = await _controller.Create(designer);

            _mockService.Verify(x => x.AddAsync(designer), Times.Never);

            Assert.IsType<BadRequestResult>(result);
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
        public async Task Delete_WhenCalled_ShouldReturnsBadRequest()
        {
            _mockService.Setup(x => x.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<bool>(false));

            var result = await _controller.Delete(It.IsAny<int>());

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
