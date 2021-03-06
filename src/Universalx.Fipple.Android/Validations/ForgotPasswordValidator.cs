using Android.Widget;
using Universalx.Fipple.Android.Activities;

namespace Universalx.Fipple.Android.Validations
{
    public class ForgotPasswordValidator : TextViewValidator
    {
        public ForgotPasswordValidator(ForgotPasswordActivity activity) : base(activity)
        {
        }

        public bool IsEmailValid()
        {
            EditText inpEmail = Activity.FindViewById<EditText>(Resource.Id.inpEmail);

            if (string.IsNullOrWhiteSpace(inpEmail.Text))
            {
                RaiseError(inpEmail, "Email is required");
                return false;
            }

            return true;
        }
    }
}