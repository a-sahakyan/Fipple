using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
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
        private DialogBuilder dialogBuilder;

        protected override int LayoutResourceId => Resource.Layout.activity_signUp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            restClient = new RestClient(IdentityBaseAddress);
            dialogBuilder = new DialogBuilder(this);

            AddEventListeners();
        }

        private void AddEventListeners()
        {
            Button btnContinue = FindViewById<Button>(Resource.Id.btnContinue);
            btnContinue.Click += async (sender, e) => await OnContinueBtnClick(sender, e);
        }

        private async Task OnContinueBtnClick(object sender, EventArgs e)
        {
            if (ValidationFails()) return;

            SetProgressDialog();

            var userModel = new RequestUserModel
            {
                FirstName = FindViewById<EditText>(Resource.Id.inpFirstName).Text,
                LastName = FindViewById<EditText>(Resource.Id.inpLastName).Text,
                Email = FindViewById<EditText>(Resource.Id.inpEmail).Text,
                Password = FindViewById<EditText>(Resource.Id.inpPassword).Text
            };

            await restClient.PostAsync<RequestUserModel, object>("/Account/CreateUser", userModel);

            dialogBuilder.DismissDialog();
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

        private void SetProgressDialog()
        {
            dialogBuilder.CreateDialog("Signing Up...");
            dialogBuilder.DisplayDialog();
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