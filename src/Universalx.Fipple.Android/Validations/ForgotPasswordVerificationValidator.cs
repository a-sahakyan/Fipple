using Android.Widget;
using Universalx.Fipple.Android.Activities;

namespace Universalx.Fipple.Android.Validations
{
    public class ForgotPasswordVerificationValidator : TextViewValidator
    {
        public ForgotPasswordVerificationValidator(ForgotPasswordVerificationActivity activity) : base(activity)
        {
        }

        public bool IsValidationCodeValid()
        {
            TextView inpVerificationCode = Activity.FindViewById<TextView>(Resource.Id.inpVerificationCode);

            if (string.IsNullOrWhiteSpace(inpVerificationCode.Text))
            {
                Validate(inpVerificationCode, "Verification Code is required");
                return false;
            }

            return true;
        }
    }
}