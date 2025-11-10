using Webapp.Models;
using Webapp.Services;
using Xunit;

namespace CheckerApp;

public class IntermediaryLayerTests
{
    [Fact]
    public void AddNewStaff_ShouldAddStaff_AndSetDefaultPhoto_WhenNoPhoto()
    {
        // Arrange
        var service = new StaffService();
        var staff = new Staff
        {
            Id = "T001",
            Name = "Test User",
            Email = "test.user@example.com",
            Phone = "123-456-7890",
            StartingDate = new DateTime(2024, 1, 1),
            PhotoUrl = "" // Không upload -> dùng default
        };

        // Act
        service.AddNewStaff(staff);
        var result = service.GetStaffById("T001");

        // Assert
        Assert.NotNull(result);
        Assert.False(string.IsNullOrEmpty(result.PhotoUrl));
    }

    [Theory]
    [InlineData("valid.email@example.com", true)]
    [InlineData("invalid-email", false)]
    public void ValidateEmail_ShouldWork(string email, bool expected)
    {
        var service = new StaffService();
        var actual = service.ValidateEmail(email);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("123-456-7890", true)]
    [InlineData("0000", false)]
    public void ValidatePhone_ShouldWork(string phone, bool expected)
    {
        var service = new StaffService();
        var actual = service.ValidatePhone(phone);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsIdUnique_ShouldDetectDuplicate()
    {
        var service = new StaffService();

        var staff = new Staff
        {
            Id = "DUP001",
            Name = "User 1",
            Email = "u1@example.com",
            Phone = "123-456-7890",
            StartingDate = DateTime.Now
        };

        service.AddNewStaff(staff);

        var isUnique = service.IsIdUnique("DUP001");

        Assert.False(isUnique);
    }
}
