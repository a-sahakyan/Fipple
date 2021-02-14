namespace Universalx.Fipple.Identity.Constants
{
    public static class ResponseError
    {
        public const string UserNotFound = "User cannot be found";
        public const string UserAlreadyExists = "User with same email already exists";
        public const string FailedToCreate = "Failed to create";
        public const string FailedToUpdate = "Failed to update";
        public const string WrongCode = "Wrong verification code was specified";
    }
}
