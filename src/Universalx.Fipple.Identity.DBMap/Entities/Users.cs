using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
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
            set => base.SecurityStamp = RandomBuilder.GetRandomNumber(100000, 999999);
        }
    }
}
