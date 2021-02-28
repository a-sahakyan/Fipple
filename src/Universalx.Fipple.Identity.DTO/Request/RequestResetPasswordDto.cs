namespace Universalx.Fipple.Identity.DTO.Request
{
    public class RequestResetPasswordDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
