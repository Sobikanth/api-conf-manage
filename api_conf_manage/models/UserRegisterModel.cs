namespace api_conf_manage.models;

public class UserRegisterModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    //create a json object with the following properties

    // {
    //     "Username": "abc@gmail.com",
    //     "Password": "Abcd@1234",
    //     "FirstName": "Abc",
    //     "LastName": "Xyz",
    //     "ContactNumber": "1234456789",
    //     "Gender": "Male",
    //     "Email": "abc@gmail.com"
    // }
}