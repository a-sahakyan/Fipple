using Android.Widget;
using System.Text.RegularExpressions;
using Universalx.Fipple.Mobile.Shared.Constants;

namespace Universalx.Fipple.Android.Validations
{
    public class SignUpValidator : TextViewValidator
    {
        public SignUpValidator(SignUpActivity activity) : base(activity)
        {
        }

        public bool IsFirstNameValid()
        {
            EditText inpFirstName = Activity.FindViewById<EditText>(Resource.Id.inpFirstName);

            if (string.IsNullOrWhiteSpace(inpFirstName.Text))
            {
                Validate(inpFirstName, "First Name is required");
                return false;
            }

            if (inpFirstName.Text.Length < AppResource.Validation.MinNameLenght)
            {
                Validate(inpFirstName, "First Name is too short");
                return false;
            }

            if (inpFirstName.Text.Length > AppResource.Validation.MaxNameLenght)
            {
                Validate(inpFirstName, "First Name is too long");
                return false;
            }

            return true;
        }

        public bool IsLastNameValid()
        {
            EditText inpLastName = Activity.FindViewById<EditText>(Resource.Id.inpLastName);

            if (string.IsNullOrWhiteSpace(inpLastName.Text))
            {
                Validate(inpLastName, "Last Name is required");
                return false;
            }

            if (inpLastName.Text.Length < AppResource.Validation.MinNameLenght)
            {
                Validate(inpLastName, "Last Name is too short");
                return false;
            }

            if (inpLastName.Text.Length > AppResource.Validation.MaxNameLenght)
            {
                Validate(inpLastName, "Last Name is too long");
                return false;
            }

            return true;
        }

        public bool IsEmailValid()
        {
            EditText inpEmail = Activity.FindViewById<EditText>(Resource.Id.inpEmail);

            if (string.IsNullOrWhiteSpace(inpEmail.Text))
            {
                Validate(inpEmail, "Email is required");
                return false;
            }

            if (!Regex.IsMatch(inpEmail.Text, AppResource.Validation.EmailRegexPattern))
            {
                Validate(inpEmail, "Email is not valid");
                return false;
            }

            return true;
        }

        public bool IsPasswordValid()
        {
            EditText inpPassword = Activity.FindViewById<EditText>(Resource.Id.inpPassword);

            if (string.IsNullOrWhiteSpace(inpPassword.Text))
            {
                Validate(inpPassword, "Password is required");
                return false;
            }

            if (inpPassword.Text.Length < AppResource.Validation.MinPasswordLength)
            {
                Validate(inpPassword, "Password is too short");
                return false;
            }

            return true;
        }
    }
}