namespace Device_management_software.Models.Dtos.Responses.User
{
    public class LoginResponse
    {
        public UserResponse User { get; set; }

        public LoginResponse(UserResponse User)
        {
            this.User = User;
        }
    }
}
