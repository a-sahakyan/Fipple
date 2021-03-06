using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Android.Validations;
using Universalx.Fipple.Mobile.Models;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class ResetPasswordActivity : BaseActivity
    {
        private ResetPasswordValidator resetPasswordValidator;
        private RestClient restClient;
        protected override int LayoutResourceId => Resource.Layout.activity_resetPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            restClient = new RestClient(IdentityBaseAddress);
            resetPasswordValidator = new ResetPasswordValidator(this);

            AddEventListeners();
        }

        private void AddEventListeners()
        {
            Button btnResetPassword = FindViewById<Button>(Resource.Id.btnResetPassword);
            btnResetPassword.Click += async (sender, e) => await OnResetPasswordBtnClick(sender, e);
        }

        private async Task OnResetPasswordBtnClick(object sender, EventArgs e)
        {
            if (!resetPasswordValidator.IsPasswordValid()) return;
            if (!resetPasswordValidator.IsConfirmPasswordValid()) return;

            RequestResetPasswordModel resetPasswordModel = new RequestResetPasswordModel
            {
                Email = Intent.GetStringExtra("Email"),
                Password = FindViewById<TextView>(Resource.Id.inpNewPassword).Text,
                ConfirmPassword = FindViewById<TextView>(Resource.Id.inpConfirmPassword).Text
            };

            ApiResponse<object> apiResponse = await restClient.PostAsync<RequestResetPasswordModel, object>("/ForgotPassword/ResetPassword", resetPasswordModel);

            if (apiResponse.Status.Failed)
            {
                resetPasswordValidator.RaiseError(Resource.Id.btnResetPassword, apiResponse.Status.ErrorMessage);
                return;
            }

            StartMainActivity();
        }

        private void StartMainActivity()
        {
            StartActivity(typeof(MainActivity));
        }
    }
}