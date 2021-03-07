using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Android.Infrastructure.Validations;
using Universalx.Fipple.Mobile.Models;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class ForgotPasswordVerificationActivity : BaseActivity
    {
        private RestClient restClient;
        private ForgotPasswordVerificationValidator forgotPasswordVerificationValidator;
        protected override int LayoutResourceId => Resource.Layout.activity_forgotPasswordVerification;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            restClient = new RestClient(IdentityBaseAddress);
            forgotPasswordVerificationValidator = new ForgotPasswordVerificationValidator(this);

            AddEventListeners();
        }

        private void AddEventListeners()
        {
            Button btnVerifyFrgPassword = FindViewById<Button>(Resource.Id.btnVerifyFrgPassword);
            btnVerifyFrgPassword.Click += async (sender, e) => await OnVerifyForgotPasswordBtnClick(sender, e);
        }

        private async Task OnVerifyForgotPasswordBtnClick(object sender, EventArgs e)
        {
            if (!forgotPasswordVerificationValidator.IsValidationCodeValid()) return;

            RequestConfirmAccountModel confirmAccountModel = new RequestConfirmAccountModel
            {
                Email = Intent.GetStringExtra("Email"),
                VerificationCode = FindViewById<TextView>(Resource.Id.inpVerificationCode).Text
            };

            ApiResponse<object> apiResponse = await restClient.PostAsync<RequestConfirmAccountModel, object>("/ForgotPassword/ConfirmResetPassword", confirmAccountModel);

            if (apiResponse.Status.Failed)
            {
                forgotPasswordVerificationValidator.RaiseError(Resource.Id.inpVerificationCode, apiResponse.Status.ErrorMessage);
                return;
            }

            StartResetPasswordActivity();
        }

        private void StartResetPasswordActivity()
        {
            Intent resetPasswordIntent = new Intent(this, typeof(ResetPasswordActivity));
            resetPasswordIntent.PutExtra("Email", Intent.GetStringExtra("Email"));
            StartActivity(resetPasswordIntent);
        }
    }
}