using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;
using static Android.Widget.LinearLayout;

namespace Universalx.Fipple.Android.Infrastructure.Components
{
    public class DialogBuilder : IDisposable
    {
        private const int Padding = 30;

        private readonly Context context;
        private readonly LinearLayout linearLayout;
        private AlertDialog alertDialog;
        private AlertDialog.Builder builder;

        public DialogBuilder(Context context, string message)
        {
            this.context = context;
            linearLayout = new LinearLayout(context);
            CreateDialog(message);
        }

        public void DisplayDialog()
        {
            alertDialog.Show();
        }

        public void Dispose()
        {
            alertDialog.Dismiss();
            alertDialog.Dispose();
        }

        private void CreateDialog(string message)
        {
            ConfigureLinearLayout();

            ProgressBar progressBar = CreateProgressBar();
            TextView textView = CreateTextView(message);

            linearLayout.AddView(progressBar);
            linearLayout.AddView(textView);

            builder = new AlertDialog.Builder(context);
            builder.SetCancelable(true);
            builder.SetView(linearLayout);
            alertDialog = builder.Create();
        }

        private void ConfigureLinearLayout()
        {
            linearLayout.Orientation = global::Android.Widget.Orientation.Horizontal;
            linearLayout.SetPadding(Padding, Padding, Padding, Padding);
            linearLayout.SetGravity(GravityFlags.Center);

            LayoutParams linearLayoutParam = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

            linearLayoutParam.Gravity = GravityFlags.Center;
            linearLayout.LayoutParameters = linearLayoutParam;
        }

        private ProgressBar CreateProgressBar()
        {
            ProgressBar progressBar = new ProgressBar(context);
            progressBar.Indeterminate = true;
            progressBar.SetPadding(0, 0, Padding, 0);
            progressBar.LayoutParameters = linearLayout.LayoutParameters;

            return progressBar;
        }

        private TextView CreateTextView(string message)
        {
            TextView textView = new TextView(context);
            textView.Text = message;
            textView.SetTextColor(ColorStateList.ValueOf(Color.Black));
            textView.TextSize = 20;
            textView.LayoutParameters = linearLayout.LayoutParameters;

            return textView;
        }
    }
}