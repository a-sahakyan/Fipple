using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddEventListeners();
        }

        protected override int GetLayoutResourceId()
        {
            return Resource.Layout.activity_main;
        }

        private void AddEventListeners()
        {
            Button btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignUp.Click += StartSignUpActivity;
        }

        private void StartSignUpActivity(object sender, EventArgs e)
        {
            StartActivity(typeof(SignUpActivity));
        }
    }
}