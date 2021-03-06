using Android.Widget;

namespace Universalx.Fipple.Android.Validations
{
    public class SignInValidator : TextViewValidator
    {
        public SignInValidator(MainActivity activity) : base(activity) { }

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

        public bool IsPasswordValid()
        {
            EditText inpPassword = Activity.FindViewById<EditText>(Resource.Id.inpPassword);

            if (string.IsNullOrWhiteSpace(inpPassword.Text))
            {
                RaiseError(inpPassword, "Password is required");
                return false;
            }

            return true;
        }
    }
}