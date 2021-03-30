namespace Universalx.Fipple.Identity.Constants
{
    public static class ResponseError
    {
        public const string Unknown = "Unknown error accured. Please Try again";
        public const string UserNotFound = "User {0} cannot be found";
        public const string UserAlreadyExists = "User with {0} already exists";
        public const string WrongCode = "Wrong verification code was specified";
        public const string PasswordsNotMatch = "Password and Confirm Password does not match";
        public const string WrongCredentials = "Wrong email or password";
        public const string Unauthorized = "Error while attempting to get resouce for refresh token {0}";
        public const string RefreshTokenExpired = "Refresh token was expired for {0}";
        public const string RefreshTokenUsed = "Refresh token {0} was already used";
        public const string RefreshTokenRevoked = "Refrsh token {0} revoked";
    }
}
