using Classes;
using DTOs;
using InterfacesDAL;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockDAL;

namespace UnitTests
{
    public class AlcoholTests
    {
        [Fact]
        public void CreateAlcohol_ValidAlcohol_ReturnsTrue()
        {
            // Arrange
            var newAlcohol = new AlcoholDTO(1, new byte[0] , "New Alcohol", 750, 20.0m, 40, 5);
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.CreateAlcohol(newAlcohol);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CreateAlcohol_InvalidAlcohol_ReturnsFalse()
        {
            // Arrange
            AlcoholDTO newAlcohol = null;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.CreateAlcohol(newAlcohol);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteAlcohol_ValidId_ReturnsTrue()
        {
            // Arrange
            int alcoholId = 1;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.DeleteAlcohol(alcoholId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteAlcohol_InvalidId_ReturnsFalse()
        {
            // Arrange
            int alcoholId = -1;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.DeleteAlcohol(alcoholId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAlcoholById_ValidId_ReturnsAlcohol()
        {
            // Arrange
            int alcoholId = 1;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.GetAlcoholById(alcoholId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(alcoholId, result.Id);
        }

        [Fact]
        public void GetAlcoholById_InvalidId_ThrowsException()
        {
            // Arrange
            int alcoholId = -1;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _alcoholService.GetAlcoholById(alcoholId));
        }

        [Fact]
        public void GetAllAlcohols_ReturnsListOfAlcohols()
        {
            // Arrange
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.GetAllAlcohols();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void UpdateAlcohol_ValidAlcohol_ReturnsTrue()
        {
            // Arrange
            var updateAlcohol = new AlcoholDTO(1, new byte[0], "Updated Alcohol", 750, 20.0m, 40, 5);
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.UpdateAlcohol(updateAlcohol);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateAlcohol_InvalidAlcohol_ReturnsFalse()
        {
            // Arrange
            AlcoholDTO updateAlcohol = null;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.UpdateAlcohol(updateAlcohol);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public void LikeAlcohol_ValidLikedBeverage_ReturnsTrue()
        {
            // Arrange
            var likedDrink = new LikedBeverage(3, 3);
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.LikeAlcohol(likedDrink);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void LikeAlcohol_NullLikedBeverage_ThrowsException()
        {
            // Arrange
            LikedBeverage likedDrink = null;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _alcoholService.LikeAlcohol(likedDrink));
        }

        [Fact]
        public void RemoveFromLikedAlcohols_ValidLikedBeverage_ReturnsTrue()
        {
            // Arrange
            var likedDrink = new LikedBeverage(1, 1);
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.RemoveFromLikedAlcohols(likedDrink);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveFromLikedAlcohols_NullLikedBeverage_ThrowsException()
        {
            // Arrange
            LikedBeverage likedDrink = null;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _alcoholService.RemoveFromLikedAlcohols(likedDrink));
        }

        [Fact]
        public void IsAlcoholLiked_ValidLikedBeverage_ReturnsTrue()
        {
            // Arrange
            var likedDrink = new LikedBeverage(1, 1);
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.IsAlcoholLiked(likedDrink);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAlcoholLiked_NullLikedBeverage_ThrowsException()
        {
            // Arrange
            LikedBeverage likedDrink = null;
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _alcoholService.IsAlcoholLiked(likedDrink));
        }

        [Fact]
        public void GetLikedBeverages_ReturnsListOfLikedBeverages()
        {
            // Arrange
            IAlcoholDAL _mockAlcoholDAL = new MockAlcoholDAL();
            AlcoholService _alcoholService = new AlcoholService(_mockAlcoholDAL);

            // Act
            var result = _alcoholService.GetLikedBeverages();

            // Assert
            Assert.Equal(3, result.Count);
        }
    }
}
