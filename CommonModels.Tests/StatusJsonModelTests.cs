using Xunit;
using FluentAssertions;
using CommonModels;

namespace CommonModels.Tests
{
    public class StatusJsonModelTests
    {
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            // Act
            var status = new StatusJsonModel();

            // Assert
            status.IsSuccess.Should().BeFalse();
            status.Metadata.Should().NotBeNull();
            status.File.Should().NotBeNull();
            status.File.RealFullPath.Should().BeEmpty();
        }

        [Fact]
        public void Clear_ShouldResetPropertiesToEmpty()
        {
            // Arrange
            var status = new StatusJsonModel
            {
                CategoryName = "API" ,
                Description = "Test Task" ,
                IsSuccess = true ,
                Result = "Completed" ,
                ErrorMessage = "None"
            };

            // Act
            status.Clear();

            // Assert
            status.IsSuccess.Should().BeFalse();
            status.CategoryName.Should().BeEmpty();
            status.Description.Should().BeEmpty();
            status.Result.Should().BeEmpty();
            status.ErrorMessage.Should().BeEmpty();
            status.File.RealFullPath.Should().BeEmpty();
        }
    }
}
