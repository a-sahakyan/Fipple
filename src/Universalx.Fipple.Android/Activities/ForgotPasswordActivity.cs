using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Universalx.Fipple.Android.Validations;
using Universalx.Fipple.Mobile.Models;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class ForgotPasswordActivity : BaseActivity
    {
        private ForgotPasswordValidator forgotPasswordValidator;
        private RestClient restClient;
        protected override int LayoutResourceId => Resource.Layout.activity_forgotPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            forgotPasswordValidator = new ForgotPasswordValidator(this);
            restClient = new RestClient(IdentityBaseAddress);

            AddEventListeners();
        }

        private void AddEventListeners()
        {
            Button btnFindAccount = FindViewById<Button>(Resource.Id.btnFindAccount);
            btnFindAccount.Click += async (sender, e) => await OnFindAccountBtnClick(sender, e);
        }

        private async Task OnFindAccountBtnClick(object sender, EventArgs e)
        {
            if (!forgotPasswordValidator.IsEmailValid()) return;

            NameValueCollection queryParams = new NameValueCollection
            {
                { "Email", FindViewById<TextView>(Resource.Id.inpEmail).Text }
            };

            ApiResponse<object> apiResponse = await restClient.GetAsync<object>("/ForgotPassword/GetUserByEmail", queryParams);

            if (apiResponse.Status.Failed)
            {
                forgotPasswordValidator.RaiseError(Resource.Id.inpEmail, apiResponse.Status.ErrorMessage);
                return;
            }

            StartForgotPasswordVerificationActivity();
        }

        private void StartForgotPasswordVerificationActivity()
        {
            Intent forgotPasswordVerificationIntent = new Intent(this, typeof(ForgotPasswordVerificationActivity));
            forgotPasswordVerificationIntent.PutExtra("Email", FindViewById<EditText>(Resource.Id.inpEmail).Text);
            StartActivity(forgotPasswordVerificationIntent);
        }
    }
}