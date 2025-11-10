using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CheckerApp;

public class InterfaceLayerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public InterfaceLayerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false   // Quan trọng: không tự redirect, giữ nguyên response
        });
    }

    [Fact]
    public async Task Index_ShouldDisplayStaffListTitle()
    {
        var response = await _client.GetAsync("/");
        response.EnsureSuccessStatusCode();

        var html = await response.Content.ReadAsStringAsync();
        Assert.Contains("Staff List", html);
    }

    [Fact]
    public async Task AddStaffPage_ShouldHaveAllInputFields()
    {
        var response = await _client.GetAsync("/AddStaff");
        response.EnsureSuccessStatusCode();

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("data-testid=\"staff-id-input\"", html);
        Assert.Contains("data-testid=\"staff-name-input\"", html);
        Assert.Contains("data-testid=\"email-input\"", html);
        Assert.Contains("data-testid=\"phone-input\"", html);
        Assert.Contains("data-testid=\"start-date-input\"", html);
        Assert.Contains("data-testid=\"photo-file-input\"", html);
    }

    [Fact]
    public async Task AddStaff_WithInvalidEmail_ShouldShowValidationError()
    {
        // Arrange
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent("C002"), "Id");
        formData.Add(new StringContent("Checker User"), "Name");
        formData.Add(new StringContent("invalid-email"), "Email"); // Sai format
        formData.Add(new StringContent("123-456-7890"), "Phone");
        formData.Add(new StringContent("2025-01-01"), "StartingDate");

        // Act
        var response = await _client.PostAsync("/AddStaff", formData);
        var html = await response.Content.ReadAsStringAsync();

        // Debug mạnh tay nếu còn lỗi
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Assert
        Assert.Contains("Invalid email format.", html);
    }
}
