using System;

namespace Universalx.Fipple.Identity.DTO.Configuration
{
    public class JwtTokenSettings
    {
        public string Secret { get; set; }
        public int AccessTokenExpireAtInHours { get; set; }
        public int RefreshTokenExpireAtInDays { get; set; }
    }
}
