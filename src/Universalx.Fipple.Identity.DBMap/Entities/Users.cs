using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Universalx.Fipple.Identity.Helpers;

namespace Universalx.Fipple.Identity.DBMap.Entities
{
    public class Users : IdentityUser<Guid>
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public override string SecurityStamp
        {
            get => base.SecurityStamp; 
            set => base.SecurityStamp = Generator.RandomizeNumber(100000, 999999);
        }
    }
}
