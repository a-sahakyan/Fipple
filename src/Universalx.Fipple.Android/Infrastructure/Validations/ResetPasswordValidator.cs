using Android.Content;
using Android.Widget;
using Universalx.Fipple.Android.Helpers;
using Universalx.Fipple.Mobile.Shared.Constants;

namespace Universalx.Fipple.Android.Infrastructure.Validations
{
    public class ResetPasswordValidator : TextViewValidator
    {
        public ResetPasswordValidator(Context context) : base(context)
        {
        }

        public bool IsPasswordValid()
        {
            TextView inpNewPassword = ApplicationManager.GetActivity(Context).FindViewById<TextView>(Resource.Id.inpNewPassword);

            if (string.IsNullOrWhiteSpace(inpNewPassword.Text))
            {
                RaiseError(inpNewPassword, "Password is required");
                return false;
            }

            if (inpNewPassword.Text.Length < AppResource.Validation.MinPasswordLength)
            {
                RaiseError(inpNewPassword, "Password is too short");
                return false;
            }

            return true;
        }

        public bool IsConfirmPasswordValid()
        {
            TextView inpConfirmPassword = ApplicationManager.GetActivity(Context).FindViewById<TextView>(Resource.Id.inpConfirmPassword);

            if (string.IsNullOrWhiteSpace(inpConfirmPassword.Text))
            {
                RaiseError(inpConfirmPassword, "Confirmation Password is required");
                return false;
            }

            TextView inpNewPassword = ApplicationManager.GetActivity(Context).FindViewById<TextView>(Resource.Id.inpNewPassword);

            if (!inpNewPassword.Text.Equals(inpConfirmPassword.Text))
            {
                RaiseError(inpConfirmPassword, "Password and Confirmation Password should be same");
                return false;
            }

            return true;
        }
    }
}