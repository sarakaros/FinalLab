- Don't forget to add the unit test into the solution file with:
    dotnet sln add BlazorWebapp.<test project name>


- Also add the reference with:
    dotnet add BlazorWebapp.<test project name> reference BlazorWebapp


- 1.Methods to test:
    GetStaffList()
    GetStaffById(string Id)
    AddNewStaff(Staff staff)
    ValidateEmail(string email)
    ValidatePhone(string phone)
    IsIdUnique(string id)
    IsEmailUnique(string email)
    IsPhoneUnique(string phone)


- 2.Testing UI with pages and selectors:
    + StaffList.razor (/)
        data-testid="staff-card-{id}"
        data-testid="view-details-button-{id}"

    + StaffDetailModal.razor (StaffList's view detail popup)
        data-testid="modal-popup"
        data-testid="modal-close-button-x"
        data-testid="modal-close-button-footer"

    + StaffForm.razor (/addStaff)
        data-testid="error-message-display"
        data-testid="staff-id-input"
        data-testid="staff-name-input"
        data-testid="email-input"
        data-testid="phone-input"
        data-testid="start-date-input"
        data-testid="photo-url-input"
        data-testid="submit-button"

//Use those selectors to test, it's easier.


// Here's some examples for testing the regex:


- Email Regex       ^[^\s@]+@[^\s@.]+(\.[^\s@.]+)+$
    + Good Cases (Should Pass):
        test@example.com
        john.doe@company.co.uk
        user123@my-server.net
        test@subdomain.domain.com

    + Bad Cases (Should Fail):
        test@gmail
        test@.com
        test@@gmail.com
        test @gmail.com


- Phone Regex       ^(\+?[1-9]\d{0,3}[-\s]?)?\d{3}[-\s]?\d{3}[-\s]?\d{4}$
    + Good Cases (Should Pass):
        123-456-7890
        123 456 7890
        1234567890
        +1 123 456 7890
        +1-123-456-7890
        +44 123 456 7890

    + Bad Cases (Should Fail):
        (123) 456-7890
        1-800-ACBDEF
        123-456-789
        123 456 78901
        +01 123 456 7890


// That's all, may the (AI) slop be with you.