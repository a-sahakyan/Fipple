namespace Universalx.Fipple.Mobile.Shared.Constants
{
    public class AppResource
    {
        public class Validation
        {
            public const int MinNameLenght = 2;
            public const int MaxNameLenght = 50;
            public const string EmailRegexPattern = ".+\\@.+\\..+";
            public const string PasswordRegexPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
        }
    }
}
