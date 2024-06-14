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
    public class SoftTests
    {
        [Fact]
        public void CreateSoft_ValidSoft_ReturnsTrue()
        {
            // Arrange
            var newSoft = new SoftDTO(1, new byte[0], "New Soft", 500, 1.5m, "Yes");
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.CreateSoft(newSoft);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CreateSoft_InvalidSoft_ReturnsFalse()
        {
            // Arrange
            SoftDTO newSoft = null;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.CreateSoft(newSoft);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteSoft_ValidId_ReturnsTrue()
        {
            // Arrange
            int softId = 1;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.DeleteSoft(softId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteSoft_InvalidId_ReturnsFalse()
        {
            // Arrange
            int softId = -1;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.DeleteSoft(softId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetSoftById_ValidId_ReturnsSoft()
        {
            // Arrange
            int softId = 1;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.GetSoftById(softId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(softId, result.Id);
        }

        [Fact]
        public void GetSoftById_InvalidId_ThrowsException()
        {
            // Arrange
            int softId = -1;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _softService.GetSoftById(softId));
        }

        [Fact]
        public void GetAllSoft_ReturnsListOfSoft()
        {
            // Arrange
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.GetAllSoft();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void UpdateSoft_ValidSoft_ReturnsTrue()
        {
            // Arrange
            var updateSoft = new SoftDTO(1, new byte[0], "Updated Soft", 500, 1.5m, "Yes");
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.UpdateSoft(updateSoft);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateSoft_InvalidSoft_ReturnsFalse()
        {
            // Arrange
            SoftDTO updateSoft = null;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.UpdateSoft(updateSoft);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void LikeSoft_ValidLikedBeverage_ReturnsTrue()
        {
            // Arrange
            var likedDrink = new LikedBeverage(3, 3);
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.LikeSoft(likedDrink);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void LikeSoft_NullLikedBeverage_ThrowsException()
        {
            // Arrange
            LikedBeverage likedDrink = null;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _softService.LikeSoft(likedDrink));
        }

        [Fact]
        public void RemoveFromLikedSofts_ValidLikedBeverage_ReturnsTrue()
        {
            // Arrange
            var likedDrink = new LikedBeverage(1, 1);
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.RemoveFromLikedSofts(likedDrink);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveFromLikedSofts_NullLikedBeverage_ThrowsException()
        {
            // Arrange
            LikedBeverage likedDrink = null;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _softService.RemoveFromLikedSofts(likedDrink));
        }

        [Fact]
        public void IsSoftLiked_ValidLikedBeverage_ReturnsTrue()
        {
            // Arrange
            var likedDrink = new LikedBeverage(1, 1);
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act
            var result = _softService.IsSoftLiked(likedDrink);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSoftLiked_NullLikedBeverage_ThrowsException()
        {
            // Arrange
            LikedBeverage likedDrink = null;
            ISoftDAL _mockSoftDAL = new MockSoftDAL();
            SoftService _softService = new SoftService(_mockSoftDAL);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _softService.IsSoftLiked(likedDrink));
        }
    }
}
