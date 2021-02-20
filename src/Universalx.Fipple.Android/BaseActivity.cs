using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Xamarin.Essentials;

namespace Universalx.Fipple.Android
{
    public abstract class BaseActivity : AppCompatActivity
    {
        protected abstract int LayoutResourceId { get; }

        protected string IdentityBaseAddress => Resources.GetString(Resource.String.identity_base_address);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);

            SetContentView(LayoutResourceId);
        }

        protected virtual void ValidateInput(TextView textView, string error) 
        {
            textView.RequestFocus();
            textView.Error = error;
        }
    }
}