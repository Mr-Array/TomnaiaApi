namespace Tomnaia.Services.Authentication
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public LoginErrorType ErrorType { get; set; }
    }

    public enum LoginErrorType
    {
        InvalidPassword,
        UserNotFound,
        EmailNotComfirmed
    }
}
