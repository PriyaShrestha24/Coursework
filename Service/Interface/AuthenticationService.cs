

namespace Service
{
    public class AuthenticationService
    {
        public async Task<bool> Authenticate(string username, string password)
        {
            // Replace this logic with actual authentication
            return username == "admin" && password == "password";
        }
    }
}
