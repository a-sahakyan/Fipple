using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace Universalx.Fipple.Android.Components
{
    public class DialogBuilder
    {
        private BaseActivity activity;
        private LinearLayout linearLayout;
        private AlertDialog alertDialog;

        public DialogBuilder(BaseActivity activity)
        {
            this.activity = activity;
        }

        public void CreateDialog(string message)
        {
            int padding = 30;
            LinearLayout linearLayout = new LinearLayout(activity);
            linearLayout.Orientation = global::Android.Widget.Orientation.Horizontal;

            linearLayout.SetPadding(padding, padding, padding, padding);
            linearLayout.SetGravity(GravityFlags.Center);

            LinearLayout.LayoutParams linearLayoutParam = new LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.WrapContent,
                    LinearLayout.LayoutParams.WrapContent);

            linearLayoutParam.Gravity = GravityFlags.Center;
            linearLayout.LayoutParameters = linearLayoutParam;

            ProgressBar progressBar = new ProgressBar(activity);
            progressBar.Indeterminate = true;
            progressBar.SetPadding(0, 0, padding, 0);
            progressBar.LayoutParameters = linearLayoutParam;

            linearLayoutParam = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            linearLayoutParam.Gravity = GravityFlags.Center;

            TextView textView = new TextView(activity);
            textView.Text = message;
            textView.SetTextColor(ColorStateList.ValueOf(Color.Black));
            textView.TextSize = 20;
            textView.LayoutParameters = linearLayoutParam;

            linearLayout.AddView(progressBar);
            linearLayout.AddView(textView);

            this.linearLayout = linearLayout;
        }

        public AlertDialog DisplayDialog()
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(activity);
            builder.SetCancelable(true);
            builder.SetView(linearLayout);

            alertDialog = builder.Create();
            alertDialog.Show();

            return alertDialog;
        }

        public void DismissDialog()
        {
            alertDialog.Dismiss();
        }
    }
}