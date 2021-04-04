using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Universalx.Fipple.Identity.Helpers
{
    public static class ClaimExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal is null) throw new ArgumentNullException(nameof(claimsPrincipal));
            if (!claimsPrincipal.Identity.IsAuthenticated) throw new InvalidOperationException("User is not authenticated");

            return Guid.Parse(claimsPrincipal.Claims.GetValue(JwtRegisteredClaimNames.Sub));
        } 

        private static string GetValue(this IEnumerable<Claim> claims, string type)
        {
            return claims.First(c => c.Type == type).Value;
        }
    }
}
