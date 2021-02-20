using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Constants;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class SignUpActivity : BaseActivity
    {
        private RestClient restClient;
        private EditText inpFirstName;
        private EditText inpLastName;
        private EditText inpEmail;
        private EditText inpPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddEventListeners();
        }

        protected override int GetLayoutResourceId()
        {
            return Resource.Layout.activity_signUp;
        }

        private void AddEventListeners()
        {
            Button btnContinue = FindViewById<Button>(Resource.Id.btnContinue);
            btnContinue.Click += Initalize;
            btnContinue.Click += async (sender, e) => await CreateUserAsync(sender, e);
        }

        private void Initalize(object sender, EventArgs e)
        {
            restClient = new RestClient(IdentityBaseAddress);
            inpFirstName = FindViewById<EditText>(Resource.Id.inpFirstName);
            inpLastName = FindViewById<EditText>(Resource.Id.inpLastName);
            inpEmail = FindViewById<EditText>(Resource.Id.inpEmail);
            inpPassword = FindViewById<EditText>(Resource.Id.inpPassword);
        }

        private async Task CreateUserAsync(object sender, EventArgs e)
        {
            if (ValidationFails()) return;

            var userModel = new RequestUserModel
            {
                FirstName = inpFirstName.Text,
                LastName = inpLastName.Text,
                Email = inpEmail.Text,
                Password = inpPassword.Text
            };

            await restClient.PostAsync<RequestUserModel, object>("/Account/CreateUser", userModel);

            StartEmailVerificationActivity();
        }

        private bool ValidationFails()
        {
            bool validationFails = false;

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

            if (string.IsNullOrWhiteSpace(inpFirstName.Text))
            {
                ValidateInput(inpFirstName, "Last Name is required");
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

            if (!Regex.IsMatch(inpPassword.Text, AppResource.Validation.PasswordRegexPattern))
            {
                ValidateInput(inpPassword, "Password should contain at least 1+ number/1+ lowercase/1+ uppercase");
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