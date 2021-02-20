using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Helpers;
using Xamarin.Essentials;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class EmailVerifyActivity : AppCompatActivity
    {
        private RestClient _restClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_emailVerify);

            _restClient = new RestClient(Resources.GetResourceName(Resource.String.identity_base_address));

            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += async (sender, e) => await ConfirmAccountAsync(sender, e);
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

                await _restClient.PostAsync<RequestConfirmAccountModel, object>("/Account/ConfirmAccountAsync", confirmAccount);
            }
        }

        private bool AgreedToTermsAndPrivacy()
        {
            CheckBox checkBoxTermsAndPrivacy = FindViewById<CheckBox>(Resource.Id.checkBoxTermsAndPrivacy);
            return checkBoxTermsAndPrivacy.Checked;
        }
    }
}