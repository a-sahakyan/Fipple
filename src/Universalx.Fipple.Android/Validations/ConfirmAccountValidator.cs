using Android.Widget;

namespace Universalx.Fipple.Android.Validations
{
    public class ConfirmAccountValidator : TextViewValidator
    {
        public ConfirmAccountValidator(ConfirmAccountActivity activity) : base(activity)
        {
        }

        public bool IsVerificationCodeValid()
        {
            TextView inpVerificationCode = Activity.FindViewById<EditText>(Resource.Id.inpVerificationCode);

            if (string.IsNullOrWhiteSpace(inpVerificationCode.Text))
            {
                RaiseError(inpVerificationCode, "Verification Code is required");
                return false;
            }

            return true;
        }

        public bool AgreeToTermsAndPrivacy()
        {
            CheckBox checkBoxTermsAndPrivacy = Activity.FindViewById<CheckBox>(Resource.Id.checkBoxTermsAndPrivacy);
            return checkBoxTermsAndPrivacy.Checked;
        }
    }
}