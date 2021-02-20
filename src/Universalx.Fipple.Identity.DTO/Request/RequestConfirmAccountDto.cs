namespace Universalx.Fipple.Identity.DTO.Request
{
    public class RequestConfirmAccountDto
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}
