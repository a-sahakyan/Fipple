using Android.App;
using Android.OS;
using Android.Widget;
using System;
using Universalx.Fipple.Android.Activities;
using Universalx.Fipple.Android.Validations;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        private SignInValidator signInValidator;
        protected override int LayoutResourceId => Resource.Layout.activity_main;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            signInValidator = new SignInValidator(this);
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            Button btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            btnSignIn.Click += OnSingInBtnClick;

            Button btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignUp.Click += OnSignUpBtnClick;

            Button btnForgotPassword = FindViewById<Button>(Resource.Id.btnForgotPassword);
            btnForgotPassword.Click += OnForgotPasswordBtnClick;
        }

        private void OnSingInBtnClick(object sender, EventArgs e)
        {
            if (!signInValidator.IsEmailValid()) return;
            if (!signInValidator.IsPasswordValid()) return;

        }

        private void OnSignUpBtnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(SignUpActivity));
        }

        private void OnForgotPasswordBtnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(ForgotPasswordActivity));
        }
    }
}