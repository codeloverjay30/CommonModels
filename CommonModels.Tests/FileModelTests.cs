using CommonModels;
using FluentAssertions;
using Moq;
using Xunit;

namespace CommonModels.Tests
{
    public class FileModelTests
    {
        [Theory]
        [InlineData(@"C:\temp\report.pdf" , "report.pdf" , ".pdf" , "PDF")]
        [InlineData(@"D:\data\sheet.xlsx" , "sheet.xlsx" , ".xlsx" , "Excel")]
        [InlineData(@"D:\data\" , "" , "" , "")]
        [InlineData(@"/home/user/notes.txt" , "notes.txt" , ".txt" , "")] // 測試未定義的副檔名
        [InlineData(@"" , "" , "" , "")] // 測試空字串
        public void FileModel_Properties_ShouldReturnCorrectValues(
            string path ,
            string expectedName ,
            string expectedExt ,
            string expectedType
        )
        {
            // Arrange & Act
            var fileModel = new FileModel(path);

            // Assert
            fileModel.FileName.Should().Be(expectedName);
            fileModel.FileExtension.Should().Be(expectedExt);
            fileModel.FileExtensionType.Should().Be(expectedType);
        }

        [Theory]
        [InlineData(@"C:\temp\report.pdf" , "report.pdf" , ".pdf" , "PDF")]
        [InlineData(@"D:\data\sheet.xlsx" , "sheet.xlsx" , ".xlsx" , "Excel")]
        [InlineData(@"/home/user/notes.txt" , "notes.txt" , ".txt" , "")] // 測試未定義的副檔名
        [InlineData(@"" , "" , "" , "")] // 測試空字串
        public void FileModel_ShouldUseMockedMapper(
            string path ,
            string expectedName ,
            string expectedExt ,
            string expectedType
        )
        {
            // Arrange
            // 建立一個假的 Mapper，不管傳入什麼都回傳 "FakeType"
            var mockMapper = new Mock<IFileExtensionMapper>(MockBehavior.Strict);
            mockMapper.Setup(m => m.GetTypeName(
                It.IsAny<string>()
            )).Returns(expectedType);

            var fileModel = new FileModel(path , mockMapper.Object);

            // Act & Assert
            // 即使 .xyz 不在原本的字典裡，因為 Mock 的關係，它會回傳 FakeType
            fileModel.FileExtensionType.Should().Be(expectedType);
        }
    }
}
