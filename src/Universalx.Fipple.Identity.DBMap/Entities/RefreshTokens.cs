using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universalx.Fipple.Identity.DBMap.Entities
{
    public class RefreshTokens
    {
        public long Id { get; set; }
        public long UserId { get; set; } 
        public string Token { get; set; }
        public string JwtId { get; set; } 
        public bool IsUsed { get; set; } 
        public bool IsRevoked { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime ExpireDateUtc { get; set; }

        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
    }
}
