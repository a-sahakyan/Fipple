using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using System;
using Universalx.Fipple.Android.Helpers;
using Universalx.Fipple.Android.Infrastructure.Components;
using Universalx.Fipple.Android.Infrastructure.Validations;
using Universalx.Fipple.Android.Infrastructure.Watchers;
using Universalx.Fipple.Mobile.Shared.Constants;

namespace Universalx.Fipple.Android.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class IntroduceYourselfActivity : BaseActivity
    {
        private IntroduceYourselfValidator introduceYourselfValidator;
        protected override int LayoutResourceId => Resource.Layout.activity_introduceYourself;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            introduceYourselfValidator = new IntroduceYourselfValidator(this);

            AddEventListeners();
        }

        private void AddEventListeners()
        {
            InitializeMatchPreferenceSpinner();
            AddBirthdateWatcherListeners();

            Button btnContinue = FindViewById<Button>(Resource.Id.btnContinue);
            btnContinue.Click += OnContinueBtnClick;
        }

        private void InitializeMatchPreferenceSpinner()
        {
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerMatchPreference);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.match_preference_array, Resource.Layout.support_simple_spinner_dropdown_item);

            spinner.Adapter = new SpinnerAdapter(adapter, Resource.Layout.spinner_item_selected, this);
            spinner.ItemSelected += OnMatchPreferenceSpinnerItemSelected;
        }

        private void AddBirthdateWatcherListeners()
        {
            TextView inpDayOfBirth = FindViewById<TextView>(Resource.Id.inpDayOfBirth);
            inpDayOfBirth.AddTextChangedListener(new DayOfBirthWatcher(this));

            TextView inpMonthOfBirth = FindViewById<TextView>(Resource.Id.inpMonthOfBirth);
            inpMonthOfBirth.AddTextChangedListener(new MonthOfBirthWatcher(this));

            TextView inpYearOfBirth = FindViewById<TextView>(Resource.Id.inpYearOfBirth);
            inpYearOfBirth.AddTextChangedListener(new YearOfBirthWatcher(this));
        }

        private void OnMatchPreferenceSpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            int chooseMatchPreferenceItem = 0;

            if (e.Position != chooseMatchPreferenceItem)
            {
                Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerMatchPreference);
                spinner.Background = CreateSpinnerShape();
            }
        }

        private GradientDrawable CreateSpinnerShape()
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(Screen.DipToAbsolutePixel(this, AppResource.DipDefault.Radius));
            shape.SetColor(Color.White);
            shape.SetStroke(Screen.DipToAbsolutePixel(this, AppResource.DipDefault.StrokeWidth),
                GetColorStateList(Resource.Color.colorHavelockBlue));

            return shape;
        }

        private void OnContinueBtnClick(object sender, EventArgs e)
        {
            if (!introduceYourselfValidator.IsBirthDateValid()) return;
            if (!introduceYourselfValidator.IsMatchPreferenceSelected()) return;
            if (!introduceYourselfValidator.IsGenderSelected()) return;

        }
    }
}