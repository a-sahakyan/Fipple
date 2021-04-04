using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universalx.Fipple.Identity.DBMap.Entities
{
    [Index(nameof(Token))]
    public class RefreshTokens
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Column(TypeName = "char")]
        [StringLength(44)]
        public string Token { get; set; }
        public Guid JwtId { get; set; } 
        public bool IsUsed { get; set; } 
        public bool IsRevoked { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime ExpireDateUtc { get; set; }

        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }
    }
}
