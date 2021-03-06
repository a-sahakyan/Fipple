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
                Validate(inpEmail, "Email is required");
                return false;
            }

            return true;
        }

        public bool IsPasswordValid()
        {
            EditText inpPassword = Activity.FindViewById<EditText>(Resource.Id.inpPassword);

            if (string.IsNullOrWhiteSpace(inpPassword.Text))
            {
                Validate(inpPassword, "Password is required");
                return false;
            }

            return true;
        }
    }
}