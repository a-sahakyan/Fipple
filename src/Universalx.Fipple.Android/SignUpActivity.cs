using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Threading.Tasks;
using Universalx.Fipple.Mobile.Models.Request;
using Universalx.Fipple.Mobile.Shared.Helpers;

namespace Universalx.Fipple.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class SignUpActivity : AppCompatActivity
    {
        private RestClient _restClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_signUp);

            _restClient = new RestClient(Resources.GetString(Resource.String.identity_base_address));

            Button btnContinue = FindViewById<Button>(Resource.Id.btnContinue);

            btnContinue.Click += async (sender, e) =>
            {
                await CreateUserAsync(sender, e);
            };

            btnContinue.Click += AddEmailToIntent;
            btnContinue.Click += StartEmailVerificationActivity;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] global::Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void StartEmailVerificationActivity(object sender, EventArgs e)
        {
            StartActivity(typeof(EmailVerifyActivity));
        }

        private void AddEmailToIntent(object sender, EventArgs e)
        {
            EditText inpEmail = FindViewById<EditText>(Resource.Id.inpEmail);
            Intent.PutExtra("Email", inpEmail.Text);
        }

        private async Task CreateUserAsync(object sender, EventArgs e)
        {
            try
            {
                RequestUserModel userModel = new RequestUserModel
                {
                    FirstName = FindViewById<EditText>(Resource.Id.inpFirstName).Text,
                    LastName = FindViewById<EditText>(Resource.Id.inpLastName).Text,
                    Email = FindViewById<EditText>(Resource.Id.inpEmail).Text,
                    Password = FindViewById<EditText>(Resource.Id.inpPassword).Text
                };

                await _restClient.PostAsync<RequestUserModel, object>("/Account/CreateUser", userModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}