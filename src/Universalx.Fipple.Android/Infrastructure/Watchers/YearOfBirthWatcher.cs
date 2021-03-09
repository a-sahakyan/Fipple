using Android.Content;
using Android.Text;
using Android.Widget;
using Java.Lang;
using Universalx.Fipple.Android.Helpers;

namespace Universalx.Fipple.Android.Infrastructure.Watchers
{
    public class YearOfBirthWatcher : Object, ITextWatcher
    {
        private const int MaxDigitsForYear = 4;
        private readonly Context context;

        public YearOfBirthWatcher(Context context)
        {
            this.context = context;
        }

        public void AfterTextChanged(IEditable sequence)
        {
            if (sequence.Length() == MaxDigitsForYear)
            {
                TextView inpYearOfBirth = AppManager.GetActivity(context).FindViewById<TextView>(Resource.Id.inpYearOfBirth);

                inpYearOfBirth.ClearFocus();
                Screen.CloseKeyboard(inpYearOfBirth);
            }
        }

        public void BeforeTextChanged(ICharSequence sequence, int start, int count, int after)
        {
        }

        public void OnTextChanged(ICharSequence sequence, int start, int before, int count)
        {
        }
    }
}