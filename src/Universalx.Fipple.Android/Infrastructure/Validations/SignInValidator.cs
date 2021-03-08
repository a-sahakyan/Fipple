using Android.Content;
using Android.Widget;
using Universalx.Fipple.Android.Helpers;

namespace Universalx.Fipple.Android.Infrastructure.Validations
{
    public class SignInValidator : TextViewValidator
    {
        public SignInValidator(Context context) : base(context) { }

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

        public bool IsPasswordValid()
        {
            EditText inpPassword = ApplicationManager.GetActivity(Context).FindViewById<EditText>(Resource.Id.inpPassword);

            if (string.IsNullOrWhiteSpace(inpPassword.Text))
            {
                RaiseError(inpPassword, "Password is required");
                return false;
            }

            return true;
        }
    }
}