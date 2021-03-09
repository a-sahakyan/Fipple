using Android.App;
using Android.Content;
using Android.Widget;
using System;
using Universalx.Fipple.Android.Helpers;
using Universalx.Fipple.Mobile.Shared.Constants;

namespace Universalx.Fipple.Android.Infrastructure.Validations
{
    public class IntroduceYourselfValidator : TextViewValidator
    {
        public IntroduceYourselfValidator(Context context) : base(context)
        {
        }

        public bool IsBirthDateValid()
        {
            Activity activity = AppManager.GetActivity(Context);
            EditText inpDayOfBirth = activity.FindViewById<EditText>(Resource.Id.inpDayOfBirth);
            bool dayParsed = int.TryParse(inpDayOfBirth.Text, out int dayOfBirth);

            if (!dayParsed)
            {
                RaiseError(inpDayOfBirth, "Days should be number");
                return false;
            }

            EditText inpMonthOfBirth = activity.FindViewById<EditText>(Resource.Id.inpMonthOfBirth);
            bool monthParsed = int.TryParse(inpMonthOfBirth.Text, out int monthOfBirth);

            if (!monthParsed)
            {
                RaiseError(inpMonthOfBirth, "Months Should be number");
                return false;
            }

            EditText inpYearOfBirth = activity.FindViewById<EditText>(Resource.Id.inpYearOfBirth);
            bool yearParsed = int.TryParse(inpYearOfBirth.Text, out int yearOfBirth);

            if (!yearParsed)
            {
                RaiseError(inpYearOfBirth, "Years Should be number");
                return false;
            }

            if (!IsValidDate(yearOfBirth, monthOfBirth, dayOfBirth))
            {
                RaiseError(inpDayOfBirth, "Not a valid date");
                return false;
            }

            return true;
        }

        private bool IsValidDate(int year, int month, int day)
        {
            if (year < AppResource.Validation.MinBornYear || year > AppResource.Validation.MaxBornYear)
                return false;

            if (month < 1 || month > 12)
                return false;

            return day > 0 && day <= DateTime.DaysInMonth(year, month);
        }

        public bool IsMatchPreferenceSelected()
        {
            Spinner spinnerMatchPreference = AppManager.GetActivity(Context).FindViewById<Spinner>(Resource.Id.spinnerMatchPreference);
            if (spinnerMatchPreference.SelectedItem == null)
            {
                RaiseError((TextView)spinnerMatchPreference.SelectedView, string.Empty);
                return false;
            }

            return true;
        }

        public bool IsGenderSelected()
        {
            Activity activity = AppManager.GetActivity(Context);
            RadioGroup radioGroupGender = activity.FindViewById<RadioGroup>(Resource.Id.radioGroupGender);

            int notSelected = -1;
            if (radioGroupGender.CheckedRadioButtonId == notSelected)
            {
                TextView txtGender = activity.FindViewById<TextView>(Resource.Id.txtGender);
                RaiseError(txtGender, string.Empty);
                return false;
            }

            return true;
        }
    }
}