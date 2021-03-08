using Android.Content;
using Android.Widget;
using Universalx.Fipple.Android.Helpers;

namespace Universalx.Fipple.Android.Infrastructure.Validations
{
    public class ForgotPasswordVerificationValidator : TextViewValidator
    {
        public ForgotPasswordVerificationValidator(Context context) : base(context)
        {
        }

        public bool IsValidationCodeValid()
        {
            TextView inpVerificationCode = ApplicationManager.GetActivity(Context).FindViewById<TextView>(Resource.Id.inpVerificationCode);

            if (string.IsNullOrWhiteSpace(inpVerificationCode.Text))
            {
                RaiseError(inpVerificationCode, "Verification Code is required");
                return false;
            }

            return true;
        }
    }
}