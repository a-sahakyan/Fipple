using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using Universalx.Fipple.Android.Helpers;
using Universalx.Fipple.Android.Infrastructure.Components;
using Universalx.Fipple.Mobile.Shared.Constants;

namespace Universalx.Fipple.Android.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class IntroduceYourselfActivity : BaseActivity
    {
        protected override int LayoutResourceId => Resource.Layout.activity_introduceYourself;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            InitializeMatchPreferenceSpinner();
        }

        private void InitializeMatchPreferenceSpinner()
        {
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerMatchPreference);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.match_preference_array, Resource.Layout.support_simple_spinner_dropdown_item);

            spinner.Adapter = new SpinnerAdapter(adapter, Resource.Layout.spinner_item_selected, this);
            spinner.ItemSelected += OnMatchPreferenceSpinnerItemSelected;
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
    }
}