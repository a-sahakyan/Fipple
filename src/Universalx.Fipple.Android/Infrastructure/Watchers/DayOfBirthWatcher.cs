using Android.Content;
using Android.Text;
using Android.Widget;
using Java.Lang;
using Universalx.Fipple.Android.Helpers;

namespace Universalx.Fipple.Android.Infrastructure.Watchers
{
    public class DayOfBirthWatcher : Object, ITextWatcher
    {
        private const int MaxDigitsForDay = 2;
        private readonly Context context;

        public DayOfBirthWatcher(Context context)
        {
            this.context = context;
        }

        public void AfterTextChanged(IEditable sequence)
        {
            if (sequence.Length() == MaxDigitsForDay)
            {
                TextView inpMonthOfBirth = ApplicationManager.GetActivity(context).FindViewById<TextView>(Resource.Id.inpMonthOfBirth);
                inpMonthOfBirth.RequestFocus();
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