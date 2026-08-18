using Xunit;
using FluentAssertions;
using CommonModels;
using System.Collections.Generic;

namespace CommonModels.Tests
{
    public class StatusJsonModelsTests
    {
        [Fact]
        public void HasNoneStatus_ShouldBeTrue_WhenListIsEmpty()
        {
            var models = new StatusJsonModels();
            models.HasNoneStatus.Should().BeTrue();
        }

        [Fact]
        public void IsAllSuccess_ShouldBeTrue_WhenAllItemsSucceed()
        {
            // Arrange
            var models = new StatusJsonModels();
            models.StatusList.Add(new StatusJsonModel { IsSuccess = true });
            models.StatusList.Add(new StatusJsonModel { IsSuccess = true });

            // Assert
            models.IsAllSuccess.Should().BeTrue();
            models.IsAllFailure.Should().BeFalse();
        }

        [Fact]
        public void IsAllFailure_ShouldBeTrue_WhenAllItemsFail()
        {
            // Arrange
            var models = new StatusJsonModels();
            models.StatusList.Add(new StatusJsonModel { IsSuccess = false });
            models.StatusList.Add(new StatusJsonModel { IsSuccess = false });

            // Assert
            models.IsAllFailure.Should().BeTrue();
            models.IsAllSuccess.Should().BeFalse();
        }

        [Fact]
        public void MixedResults_ShouldReturnFalseForBothAllFlags()
        {
            // Arrange
            var models = new StatusJsonModels();
            models.StatusList.Add(new StatusJsonModel { IsSuccess = true });
            models.StatusList.Add(new StatusJsonModel { IsSuccess = false });

            // Assert
            models.IsAllSuccess.Should().BeFalse();
            models.IsAllFailure.Should().BeFalse();
        }
    }
}
