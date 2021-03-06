using Android.Widget;
using Universalx.Fipple.Android.Activities;
using Universalx.Fipple.Mobile.Shared.Constants;

namespace Universalx.Fipple.Android.Validations
{
    public class ResetPasswordValidator : TextViewValidator
    {
        public ResetPasswordValidator(ResetPasswordActivity activity) : base(activity)
        {
        }

        public bool IsPasswordValid()
        {
            TextView inpNewPassword = Activity.FindViewById<TextView>(Resource.Id.inpNewPassword);

            if (string.IsNullOrWhiteSpace(inpNewPassword.Text))
            {
                Validate(inpNewPassword, "Password is required");
                return false;
            }

            if (inpNewPassword.Text.Length < AppResource.Validation.MinPasswordLength)
            {
                Validate(inpNewPassword, "Password is too short");
                return false;
            }

            return true;
        }

        public bool IsConfirmPasswordValid()
        {
            TextView inpConfirmPassword = Activity.FindViewById<TextView>(Resource.Id.inpConfirmPassword);

            if (string.IsNullOrWhiteSpace(inpConfirmPassword.Text))
            {
                Validate(inpConfirmPassword, "Confirmation Password is required");
                return false;
            }

            TextView inpNewPassword = Activity.FindViewById<TextView>(Resource.Id.inpNewPassword);

            if (!inpNewPassword.Text.Equals(inpConfirmPassword.Text))
            {
                Validate(inpConfirmPassword, "Password and Confirmation Password should be same");
                return false;
            }

            return true;
        }
    }
}