using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using Xamarin.Essentials;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Button btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignUp.Click += StartSignUpActivity;
        }

        public void StartSignUpActivity(object sender, EventArgs e)
        {
            StartActivity(typeof(SignUpActivity));
        }
    }
}