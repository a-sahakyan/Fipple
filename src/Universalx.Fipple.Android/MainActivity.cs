using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        protected override int LayoutResourceId => Resource.Layout.activity_main;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            Button btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            btnSignIn.Click += OnSingInBtnClick;

            Button btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignUp.Click += OnSignUpBtnClick;
        }

        private void OnSingInBtnClick(object sender, EventArgs e)
        {
            if (ValidationFails()) return;
        }

        private void OnSignUpBtnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(SignUpActivity));
        }

        private bool ValidationFails()
        {
            EditText inpEmail = FindViewById<EditText>(Resource.Id.inpEmail);
            EditText inpPassword = FindViewById<EditText>(Resource.Id.inpPassword);
            bool validationFails = false;

            if (string.IsNullOrWhiteSpace(inpEmail.Text))
            {
                ValidateInput(inpEmail, "Email is required");
                validationFails = true;
            }

            if (string.IsNullOrWhiteSpace(inpPassword.Text))
            {
                ValidateInput(inpPassword, "Password is required");
                validationFails = true;
            }

            return validationFails;
        }
    }
}