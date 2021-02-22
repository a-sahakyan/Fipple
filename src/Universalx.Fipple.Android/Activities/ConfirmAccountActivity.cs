using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Constants;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class ConfirmAccountActivity : BaseActivity
    {
        private RestClient restClient;

        protected override int LayoutResourceId => Resource.Layout.activity_confirmAccount;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            restClient = new RestClient(IdentityBaseAddress);

            AddEventListeners();
        }

        private void AddEventListeners()
        {
            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += async (sender, e) => await OnRegisterBtnClick(sender, e);

            CheckBox checkBox = FindViewById<CheckBox>(Resource.Id.checkBoxTermsAndPrivacy);
            checkBox.CheckedChange += OnTermsAndPrivacyCheckBoxChanged;
        }

        private async Task OnRegisterBtnClick(object sender, EventArgs e)
        {
            if (ValidationFails()) return;

            var confirmAccount = new RequestConfirmAccountModel()
            {
                Email = Intent.GetStringExtra("Email"),
                VerificationCode = FindViewById<TextView>(Resource.Id.inpVerificationCode).Text
            };

            await restClient.PostAsync<RequestConfirmAccountModel, object>("/Account/ConfirmAccountAsync", confirmAccount);
        }

        private void OnTermsAndPrivacyCheckBoxChanged(object sender, EventArgs e)
        {
            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            CheckBox checkBoxTermsAndPrivacy = sender as CheckBox;

            if (checkBoxTermsAndPrivacy.Checked)
            {
                btnRegister.Clickable = true;
                btnRegister.Alpha = AppResource.Opacity.FullVisible;
                return;
            }

            btnRegister.Clickable = false;
            btnRegister.Alpha = AppResource.Opacity.HalfVisible;
        }

        private bool ValidationFails()
        {
            bool validationFails = false;
            TextView inpVerificationCode = FindViewById<EditText>(Resource.Id.inpVerificationCode);

            if (string.IsNullOrWhiteSpace(inpVerificationCode.Text))
            {
                ValidateInput(inpVerificationCode, "Verification Code is required");
                validationFails = true;
            }

            if (DoesNotAgreedToTermsAndPrivacy())
            {
                validationFails = true;
            }

            return validationFails;
        }

        private bool DoesNotAgreedToTermsAndPrivacy()
        {
            CheckBox checkBoxTermsAndPrivacy = FindViewById<CheckBox>(Resource.Id.checkBoxTermsAndPrivacy);
            return checkBoxTermsAndPrivacy.Checked;
        }
    }
}