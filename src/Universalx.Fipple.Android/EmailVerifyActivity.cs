using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class EmailVerifyActivity : BaseActivity
    {
        private RestClient restClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddEventListeners();
        }

        protected override int GetLayoutResourceId()
        {
            return Resource.Layout.activity_emailVerify;
        }

        private void AddEventListeners()
        {
            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += Initalize;
            btnRegister.Click += async (sender, e) => await ConfirmAccountAsync(sender, e);
        }

        private void Initalize(object sender, EventArgs e)
        {
            restClient = new RestClient(IdentityBaseAddress);
        }

        private async Task ConfirmAccountAsync(object sender, EventArgs e)
        {
            if (AgreedToTermsAndPrivacy())
            {
                RequestConfirmAccountModel confirmAccount = new RequestConfirmAccountModel()
                {
                    Email = Intent.GetStringExtra("Email"),
                    VerificationCode = FindViewById<TextView>(Resource.Id.inpVerificationCode).Text
                };

                await restClient.PostAsync<RequestConfirmAccountModel, object>("/Account/ConfirmAccountAsync", confirmAccount);
            }
        }

        private bool AgreedToTermsAndPrivacy()
        {
            CheckBox checkBoxTermsAndPrivacy = FindViewById<CheckBox>(Resource.Id.checkBoxTermsAndPrivacy);
            return checkBoxTermsAndPrivacy.Checked;
        }
    }
}