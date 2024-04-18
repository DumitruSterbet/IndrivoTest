using IndrivoTest.Bussines.Interfaces;
using IndrivoTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Type = IndrivoTest.Models.Type;
namespace TestProject.Tests
{


    public class TypeControllerTests
    {
        [Fact]
        public void Get_ReturnsListOfTypes()
        {
            // Arrange
            var mockTypeService = new Mock<ITypeService>();
            mockTypeService.Setup(service => service.GetEntities()).Returns(new List<Type>
            {
                new Type { Guid = Guid.NewGuid(), Title = "Type1" },
                new Type { Guid = Guid.NewGuid(), Title = "Type2" }
            });
            var controller = new TypeController(mockTypeService.Object);

            // Act
            var result = controller.Get();

            // Assert
   ;
            Assert.Equal(new List<Type>
            {
                new Type { Guid = Guid.NewGuid(), Title = "Type1" },
                new Type { Guid = Guid.NewGuid(), Title = "Type2" }
            }, result);
        }

        // Similar tests for other controller actions (Get by id, Post, Put, Delete) can be added here
    }


}



