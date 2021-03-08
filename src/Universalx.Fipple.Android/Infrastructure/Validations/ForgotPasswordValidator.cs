using Android.Content;
using Android.Widget;
using Universalx.Fipple.Android.Helpers;

namespace Universalx.Fipple.Android.Infrastructure.Validations
{
    public class ForgotPasswordValidator : TextViewValidator
    {
        public ForgotPasswordValidator(Context context) : base(context)
        {
        }

        public bool IsEmailValid()
        {
            EditText inpEmail = ApplicationManager.GetActivity(Context).FindViewById<EditText>(Resource.Id.inpEmail);

            if (string.IsNullOrWhiteSpace(inpEmail.Text))
            {
                RaiseError(inpEmail, "Email is required");
                return false;
            }

            return true;
        }
    }
}