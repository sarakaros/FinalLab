🧪 CheckerApp – HR Web Application Tester
📘 Overview

CheckerApp is a companion test project for the main Webapp (Human Resource Management System).
It verifies both Intermediary Layer (Services) and Interface Layer (Controllers + Views)
to ensure correct data handling, validation, and rendering in the HR management system.

🏗️ Project Setup
1️⃣ Add the test project to your solution
dotnet sln add CheckerApp/CheckerApp.csproj

2️⃣ Add reference to the Webapp project
dotnet add CheckerApp reference Webapp/Webapp.csproj

3️⃣ Required packages (if not already installed)
dotnet add CheckerApp package Microsoft.NET.Test.Sdk
dotnet add CheckerApp package xunit
dotnet add CheckerApp package xunit.runner.visualstudio
dotnet add CheckerApp package Microsoft.AspNetCore.Mvc.Testing
dotnet add CheckerApp package FluentAssertions

🧱 Intermediary Layer (Service)

The service layer represents the intermediary between data and presentation.
In this project, we test the logic implemented inside:

File	Description
IStaffService.cs	Defines the contract for staff operations
StaffService.cs	Implements logic for managing staff data, regex validation, and uniqueness checking
Methods to Test
Method	Description
GetStaffList()	Returns all staff entries
GetStaffById(string id)	Finds staff by ID
AddNewStaff(Staff staff)	Adds new staff and saves to file
ValidateEmail(string email)	Validates email format using regex
ValidatePhone(string phone)	Validates phone format using regex
IsIdUnique(string id)	Ensures staff ID is unique
IsEmailUnique(string email)	Ensures email is unique
IsPhoneUnique(string phone)	Ensures phone is unique
🖥️ Interface Layer (Controller + Views)

This layer includes user-facing pages (Views) and routing logic (Controller).

File	Description
Controllers/StaffController.cs	Handles page routing, input validation, and form processing
Views/Staff/Index.cshtml	Displays all staff members
Views/Staff/Details.cshtml	Displays details of a selected staff
Views/Staff/Add.cshtml	Form for adding a new staff member
🧩 Test Selectors (data-testid attributes)

These attributes are used for UI testing in integration tests:

Index.cshtml (/)
Element	Selector
Staff card	data-testid="staff-card-{id}"
Details button	data-testid="view-details-button-{id}"
Details.cshtml (/StaffDetail/{id})
Element	Selector
Card container	data-testid="staff-details-card"
Photo	data-testid="staff-photo"
Staff ID	data-testid="staff-id-display"
Name	data-testid="staff-name-display"
Email	data-testid="staff-email-display"
Phone	data-testid="staff-phone-display"
Start Date	data-testid="staff-startdate-display"
Back button	data-testid="back-to-list-button"
Add.cshtml (/AddStaff)
Element	Selector
Staff ID input	data-testid="staff-id-input"
Name input	data-testid="staff-name-input"
Email input	data-testid="email-input"
Phone input	data-testid="phone-input"
Start date	data-testid="start-date-input"
Photo URL input	data-testid="photo-url-input"
Submit button	data-testid="submit-button"
🔍 Regex Validation Test Cases
✅ ValidateEmail

Pattern:

^[^\s@]+@[^\s@.]+(\.[^\s@.]+)+$


Good Cases

test@example.com
john.doe@company.co.uk
user123@my-server.net
test@subdomain.domain.com


Bad Cases

test@gmail
test@.com
test@@gmail.com
test @gmail.com

✅ ValidatePhone

Pattern:

^(\+?[1-9]\d{0,3}[-\s]?)?\d{3}[-\s]?\d{3}[-\s]?\d{4}$


Good Cases

123-456-7890
123 456 7890
1234567890
+1 123 456 7890
+1-123-456-7890
+44 123 456 7890


Bad Cases

(123) 456-7890
1-800-ACBDEF
123-456-789
123 456 78901
+01 123 456 7890

🧪 How to Run the Tests

From the project root:

dotnet test


Visual Studio:

Open Test Explorer

Select Run All Tests

📂 Project Structure Example
MCFinalLab.sln
│
├── Webapp/
│   ├── Controllers/
│   │   └── StaffController.cs
│   ├── Models/
│   ├── Services/
│   └── Views/
│
└── CheckerApp/
    ├── Tests/
    │   ├── ServiceLayerTests.cs
    │   └── InterfaceLayerTests.cs
    ├── CheckerApp.csproj
    └── README.md

💬 Notes

The CheckerApp ensures that the HR Webapp behaves as expected:

Validates all business logic inside the StaffService

Confirms UI elements render correctly in the Views

Tests both correct and incorrect input cases

⚡ Credits

Developed by: [Your Name / Team Name]

“May the (AI) slop be with you.” 🤖✨
