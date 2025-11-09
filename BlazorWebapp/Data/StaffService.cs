using System.Text.RegularExpressions;

namespace BlazorWebapp.Data;

public class StaffService
{
    private readonly List<Staff> staffList = new List<Staff>();

    private Regex EmailRegex = new Regex(@"^[^\s@]+@[^\s@.]+(\.[^\s@.]+)+$");
    private Regex PhoneRegex = new Regex(@"^(\+?[1-9]\d{0,3}[-\s]?)?\d{3}[-\s]?\d{3}[-\s]?\d{4}$");

    public StaffService()
    {
        staffList.Add(new Staff
        {
            Id = "S001",
            Name = "John Wick",
            Email = "SparklingDaisy@gmail.com",
            Phone = "679-116-9420",
            StartingDate = new DateTime(2009, 10, 25),
            PhotoUrl = "https://thumbs.dreamstime.com/b/default-avatar-profile-icon-vector-social-media-user-portrait-176256935.jpg"
        });
    }


    public List<Staff> GetStaffList()
    {
        return staffList;
    }

    public Staff GetStaffById(string Id)
    {
        var staff = staffList.FirstOrDefault(x => x.Id == Id);
        return staff;
    }

    public void AddNewStaff(Staff staff)
    {
        staffList.Add(staff);
    }

    public bool ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;
        return EmailRegex.IsMatch(email);
    }

    public bool ValidatePhone(string phone)
    {
        if (string.IsNullOrEmpty(phone))
            return false;
        return PhoneRegex.IsMatch(phone);
    }
    
    public bool IsIdUnique(string id)
    {
        return !staffList.Any(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
    }

    public bool IsEmailUnique(string email)
    {
        return !staffList.Any(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public bool IsPhoneUnique(string phone)
    {
        return !staffList.Any(s => s.Phone.Equals(phone, StringComparison.OrdinalIgnoreCase));
    }

}