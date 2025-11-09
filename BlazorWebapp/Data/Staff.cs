namespace BlazorWebapp.Data;

public class Staff
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime StartingDate { get; set; }
    public string PhotoUrl { get; set; }

    public Staff()
    {
        Id = string.Empty;
        Name = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        StartingDate = DateTime.Now;
        PhotoUrl = string.Empty;
    }
}