using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Android.Components;
using Universalx.Fipple.Android.Validations;
using Universalx.Fipple.Mobile.Models;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class SignUpActivity : BaseActivity
    {
        private RestClient restClient;
        private SignUpValidator signUpValidator;

        protected override int LayoutResourceId => Resource.Layout.activity_signUp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            restClient = new RestClient(IdentityBaseAddress);
            signUpValidator = new SignUpValidator(this);
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
            if (!signUpValidator.IsFirstNameValid()) return;
            if (!signUpValidator.IsLastNameValid()) return;
            if (!signUpValidator.IsEmailValid()) return;
            if (!signUpValidator.IsPasswordValid()) return;

            ApiResponse<object> apiResponse;
            using (var signUpDialog = new DialogBuilder(this, "Signing up..."))
            {
                signUpDialog.DisplayDialog();

                var userModel = new RequestUserModel
                {
                    FirstName = FindViewById<EditText>(Resource.Id.inpFirstName).Text,
                    LastName = FindViewById<EditText>(Resource.Id.inpLastName).Text,
                    Email = FindViewById<EditText>(Resource.Id.inpEmail).Text,
                    Password = FindViewById<EditText>(Resource.Id.inpPassword).Text
                };

                apiResponse = await restClient.PostAsync<RequestUserModel, object>("/Account/CreateUser", userModel);
            }

            if (apiResponse.Status.Failed)
            {
                signUpValidator.RaiseError(Resource.Id.inpEmail, apiResponse.Status.ErrorMessage);
                return;
            }

            StartConfirmAccountActivity();
        }

        private void StartConfirmAccountActivity()
        {
            Intent confirmAccountIntent = new Intent(this, typeof(ConfirmAccountActivity));
            confirmAccountIntent.PutExtra("Email", FindViewById<EditText>(Resource.Id.inpEmail).Text);
            StartActivity(confirmAccountIntent);
        }
    }
}