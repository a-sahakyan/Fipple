using Android.Widget;
using System.Text.RegularExpressions;
using Universalx.Fipple.Mobile.Shared.Constants;

namespace Universalx.Fipple.Android.Infrastructure.Validations
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
                RaiseError(inpFirstName, "First Name is required");
                return false;
            }

            if (inpFirstName.Text.Length < AppResource.Validation.MinNameLenght)
            {
                RaiseError(inpFirstName, "First Name is too short");
                return false;
            }

            if (inpFirstName.Text.Length > AppResource.Validation.MaxNameLenght)
            {
                RaiseError(inpFirstName, "First Name is too long");
                return false;
            }

            return true;
        }

        public bool IsLastNameValid()
        {
            EditText inpLastName = Activity.FindViewById<EditText>(Resource.Id.inpLastName);

            if (string.IsNullOrWhiteSpace(inpLastName.Text))
            {
                RaiseError(inpLastName, "Last Name is required");
                return false;
            }

            if (inpLastName.Text.Length < AppResource.Validation.MinNameLenght)
            {
                RaiseError(inpLastName, "Last Name is too short");
                return false;
            }

            if (inpLastName.Text.Length > AppResource.Validation.MaxNameLenght)
            {
                RaiseError(inpLastName, "Last Name is too long");
                return false;
            }

            return true;
        }

        public bool IsEmailValid()
        {
            EditText inpEmail = Activity.FindViewById<EditText>(Resource.Id.inpEmail);

            if (string.IsNullOrWhiteSpace(inpEmail.Text))
            {
                RaiseError(inpEmail, "Email is required");
                return false;
            }

            if (!Regex.IsMatch(inpEmail.Text, AppResource.Validation.EmailRegexPattern))
            {
                RaiseError(inpEmail, "Email is not valid");
                return false;
            }

            return true;
        }

        public bool IsPasswordValid()
        {
            EditText inpPassword = Activity.FindViewById<EditText>(Resource.Id.inpPassword);

            if (string.IsNullOrWhiteSpace(inpPassword.Text))
            {
                RaiseError(inpPassword, "Password is required");
                return false;
            }

            if (inpPassword.Text.Length < AppResource.Validation.MinPasswordLength)
            {
                RaiseError(inpPassword, "Password is too short");
                return false;
            }

            return true;
        }
    }
}