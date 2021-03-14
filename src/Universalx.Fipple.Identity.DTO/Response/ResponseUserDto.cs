using System;

namespace Universalx.Fipple.Identity.DTO.Response
{
    public class ResponseUserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
    }
}
