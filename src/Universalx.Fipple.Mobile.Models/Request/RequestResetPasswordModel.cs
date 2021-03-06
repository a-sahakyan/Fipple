namespace Universalx.Fipple.Mobile.Models.Request
{
    public class RequestResetPasswordModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
