using Android.Content;
using Android.Widget;
using Universalx.Fipple.Android.Helpers;

namespace Universalx.Fipple.Android.Infrastructure.Validations
{
    public class ConfirmAccountValidator : TextViewValidator
    {
        public ConfirmAccountValidator(Context context) : base(context)
        {
        }

        public bool IsVerificationCodeValid()
        {
            TextView inpVerificationCode = AppManager.GetActivity(Context).FindViewById<EditText>(Resource.Id.inpVerificationCode);

            if (string.IsNullOrWhiteSpace(inpVerificationCode.Text))
            {
                RaiseError(inpVerificationCode, "Verification Code is required");
                return false;
            }

            return true;
        }

        public bool AgreeToTermsAndPrivacy()
        {
            CheckBox checkBoxTermsAndPrivacy = AppManager.GetActivity(Context).FindViewById<CheckBox>(Resource.Id.checkBoxTermsAndPrivacy);
            return checkBoxTermsAndPrivacy.Checked;
        }
    }
}