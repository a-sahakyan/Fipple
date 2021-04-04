using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Universalx.Fipple.Identity.Abstraction;
using Universalx.Fipple.Identity.Constants;
using Universalx.Fipple.Identity.DBMap.Entities;
using Universalx.Fipple.Identity.DTO.Configuration;
using Universalx.Fipple.Identity.DTO.Request;
using Universalx.Fipple.Identity.DTO.Response;
using Universalx.Fipple.Identity.Helpers;
using Universalx.Fipple.Identity.Repository.Abstraction;

namespace Universalx.Fipple.Identity.BusinessLogic.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtTokenSettings _jwtTokenSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<Users> _userManager;

        public JwtTokenService(IOptionsSnapshot<JwtTokenSettings> jwtTokenSettings,
                               IRefreshTokenRepository refreshTokenRepository,
                               UserManager<Users> userManager)
        {
            _jwtTokenSettings = jwtTokenSettings.Value;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
        }

        public async Task<ResponseJwtTokenDto> GenerateJwtTokenAsync(Claim[] claims)
        {
            string accessToken = GenerateAccessToken(claims, out Guid tokenId);
            string refreshToken = await CreateRefreshTokenAsync(claims, tokenId);

            return new ResponseJwtTokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private string GenerateAccessToken(Claim[] claims, out Guid tokenId)
        {
            byte[] key = Encoding.ASCII.GetBytes(_jwtTokenSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_jwtTokenSettings.AccessTokenExpireAtInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);

            tokenId = Guid.Parse(token.Id);
            string accessToken = jwtTokenHandler.WriteToken(token);

            return accessToken;
        }

        private async Task<string> CreateRefreshTokenAsync(Claim[] claims, Guid tokenId)
        {
            var refreshToken = new RefreshTokens
            {
                JwtId = tokenId,
                IsUsed = false,
                UserId = long.Parse(claims.SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub.ToString()).Value),
                Token = RandomBuilder.GenerateRefreshToken(),
                IsRevoked = false,
                ExpireDateUtc = DateTime.UtcNow.AddDays(_jwtTokenSettings.RefreshTokenExpireAtInDays),
                CreatedDateUtc = DateTime.UtcNow
            };

            await _refreshTokenRepository.CreateAsync(refreshToken);
            return refreshToken.Token;
        }

        public async Task<ResponseUserDto> UpdateRefreshTokenAsUsedAsync(RequestTokenDto tokenDto)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(tokenDto.RefreshToken);

            if (refreshToken == null)
            {
                throw new Exception(string.Format(ResponseError.Unauthorized, tokenDto.RefreshToken));
            }

            if (DateTime.UtcNow > refreshToken.ExpireDateUtc)
            {
                throw new Exception(string.Format(ResponseError.RefreshTokenExpired, refreshToken.Id));
            }

            if (refreshToken.IsUsed)
            {
                throw new Exception(string.Format(ResponseError.RefreshTokenUsed, refreshToken.Id));
            }

            if (refreshToken.IsRevoked)
            {
                throw new Exception(string.Format(ResponseError.RefreshTokenRevoked, refreshToken.Id));
            }

            refreshToken.IsUsed = true;
            await _refreshTokenRepository.UpdateAsync(refreshToken);

            var user = await _userManager.FindByIdAsync(refreshToken.UserId.ToString());
            var userDto = new ResponseUserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return userDto;
        }

        public async Task DeleteRefreshTokenAsync(string token)
        {
            await _refreshTokenRepository.DeleteAsync(token);
        }
    }
}
