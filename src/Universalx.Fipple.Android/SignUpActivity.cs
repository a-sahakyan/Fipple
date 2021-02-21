using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Universalx.Fipple.Android.Components;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Constants;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class SignUpActivity : BaseActivity
    {
        private RestClient restClient;
        private DialogBuilder signUpDialogBuilder;

        protected override int LayoutResourceId => Resource.Layout.activity_signUp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            restClient = new RestClient(IdentityBaseAddress);
            signUpDialogBuilder = new DialogBuilder(this);


            AddEventListeners();
        }

        private void AddEventListeners()
        {
            Button btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            btnSignIn.Click += OnSignInBtnClick;

            Button btnContinue = FindViewById<Button>(Resource.Id.btnContinue);
            btnContinue.Click += async (sender, e) => await OnContinueBtnClick(sender, e);
        }

        private void OnSignInBtnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private async Task OnContinueBtnClick(object sender, EventArgs e)
        {
            if (ValidationFails()) return;

            signUpDialogBuilder.CreateDialog("Signing Up...");
            signUpDialogBuilder.DisplayDialog();

            var userModel = new RequestUserModel
            {
                FirstName = FindViewById<EditText>(Resource.Id.inpFirstName).Text,
                LastName = FindViewById<EditText>(Resource.Id.inpLastName).Text,
                Email = FindViewById<EditText>(Resource.Id.inpEmail).Text,
                Password = FindViewById<EditText>(Resource.Id.inpPassword).Text
            };

            try
            {
                await restClient.PostAsync<RequestUserModel, object>("/Account/CreateUser", userModel);

            }
            catch (Exception ex)
            {

                throw;
            }
            signUpDialogBuilder.DismissDialog();

            StartEmailVerificationActivity();
        }

        private bool ValidationFails()
        {
            bool validationFails = false;
            EditText inpFirstName = FindViewById<EditText>(Resource.Id.inpFirstName);
            EditText inpLastName = FindViewById<EditText>(Resource.Id.inpLastName);
            EditText inpEmail = FindViewById<EditText>(Resource.Id.inpEmail);
            EditText inpPassword = FindViewById<EditText>(Resource.Id.inpPassword);

            if (string.IsNullOrWhiteSpace(inpFirstName.Text))
            {
                ValidateInput(inpFirstName, "First Name is required");
                validationFails = true;
            }

            if (inpFirstName.Text.Length < AppResource.Validation.MinNameLenght)
            {
                ValidateInput(inpFirstName, "First Name is too short");
                validationFails = true;
            }

            if (inpFirstName.Text.Length > AppResource.Validation.MaxNameLenght)
            {
                ValidateInput(inpFirstName, "First Name is too long");
                validationFails = true;
            }

            if (string.IsNullOrWhiteSpace(inpLastName.Text))
            {
                ValidateInput(inpLastName, "Last Name is required");
                validationFails = true;
            }

            if (inpLastName.Text.Length < AppResource.Validation.MinNameLenght)
            {
                ValidateInput(inpLastName, "Last Name is too short");
                validationFails = true;
            }

            if (inpLastName.Text.Length > AppResource.Validation.MaxNameLenght)
            {
                ValidateInput(inpLastName, "Last Name is too long");
                validationFails = true;
            }

            if (string.IsNullOrWhiteSpace(inpEmail.Text))
            {
                ValidateInput(inpEmail, "Email is required");
                validationFails = true;
            }

            if (!Regex.IsMatch(inpEmail.Text, AppResource.Validation.EmailRegexPattern))
            {
                ValidateInput(inpEmail, "Email is not valid");
                validationFails = true;
            }

            if (string.IsNullOrWhiteSpace(inpPassword.Text))
            {
                ValidateInput(inpPassword, "Password is required");
                validationFails = true;
            }

            if (inpPassword.Text.Length < AppResource.Validation.MinPasswordLength)
            {
                ValidateInput(inpPassword, "Password is too short");
                validationFails = true;
            }

            return validationFails;
        }

        private void StartEmailVerificationActivity()
        {
            AddEmailToIntent();
            StartActivity(typeof(EmailVerifyActivity));
        }

        private void AddEmailToIntent()
        {
            EditText inpEmail = FindViewById<EditText>(Resource.Id.inpEmail);
            Intent.PutExtra("Email", inpEmail.Text);
        }
    }
}