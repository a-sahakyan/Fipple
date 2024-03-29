﻿namespace Universalx.Fipple.Identity.Constants
{
    public static class ResponseError
    {
        public const string UnknownError = "Unknown error accured. Please Try again";
        public const string UserNotFound = "User {0} cannot be found";
        public const string UserAlreadyExists = "User with {0} already exists";
        public const string WrongCode = "Wrong verification code was specified";
        public const string PasswordsNotMatch = "Password and Confirm Password does not match";
    }
}
