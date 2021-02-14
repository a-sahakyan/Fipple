namespace Universalx.Fipple.Identity.DTO.Configuration
{
    public class EmailSettings
    {
        public int MailPort { get; set; }
        public string MailHost { get; set; }
        public string Sender { get; set; }
        public string SenderPassword { get; set; }
        public bool IsTest { get; set; }
        public string Receiver { get; set; }
    }
}
