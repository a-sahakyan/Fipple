using Android.Content;
using Android.Text;
using Android.Widget;
using Java.Lang;
using Universalx.Fipple.Android.Helpers;

namespace Universalx.Fipple.Android.Infrastructure.Watchers
{
    public class MonthOfBirthWatcher : Object, ITextWatcher
    {
        private const int MaxDigitsForMonth = 2;
        private readonly Context context;

        public MonthOfBirthWatcher(Context context)
        {
            this.context = context;
        }

        public void AfterTextChanged(IEditable sequence)
        {
            if(sequence.Length() == MaxDigitsForMonth)
            {
                TextView inpYearOfBirth = AppManager.GetActivity(context).FindViewById<TextView>(Resource.Id.inpYearOfBirth);
                inpYearOfBirth.RequestFocus();
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