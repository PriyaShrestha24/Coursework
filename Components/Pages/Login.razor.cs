using Coursework.Model;
using Coursework.Service;
namespace Coursework.Components.Pages;

public partial class Login
{
    private string? ErrorMessage;

    public User Users { get; set; } = new();
    private List<User> users;

    protected override void OnInitialized()
    {
        users = UserService.GetUsers(); // Get all tags when the component is initialized
    }

    public async Task HandleDelete(Guid userId)
    {
        try
        {
            UserService.DeleteUser(userId); // Call the service to delete the tag
            users = UserService.GetUsers(); // Refresh the list of tags
            ErrorMessage = null;
        }
        catch (Exception ex)
        {
            ErrorMessage = "An error occurred while deleting the tag.";
            Console.WriteLine(ex);
        }
    }


    private async void HandleLogin()
    {
        if (UserService.Login(Users))
        {
            Nav.NavigateTo("/dashboard");
        }
        else
        {
            ErrorMessage = "Invalid username or password.";
        }
    }
}