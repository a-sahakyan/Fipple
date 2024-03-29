﻿using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System;
using static Android.Widget.LinearLayout;

namespace Universalx.Fipple.Android.Components
{
    public class DialogBuilder : IDisposable
    {
        private const int Padding = 30;

        private readonly BaseActivity activity;
        private readonly LinearLayout linearLayout;
        private AlertDialog alertDialog;
        private AlertDialog.Builder builder;

        public DialogBuilder(BaseActivity activity, string message)
        {
            this.activity = activity;
            linearLayout = new LinearLayout(activity);
            CreateDialog(message);
        }

        public void CreateDialog(string message)
        {
            ConfigureLinearLayout();

            ProgressBar progressBar = CreateProgressBar();
            TextView textView = CreateTextView(message);

            linearLayout.AddView(progressBar);
            linearLayout.AddView(textView);

            builder = new AlertDialog.Builder(activity);
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
            ProgressBar progressBar = new ProgressBar(activity);
            progressBar.Indeterminate = true;
            progressBar.SetPadding(0, 0, Padding, 0);
            progressBar.LayoutParameters = linearLayout.LayoutParameters;

            return progressBar;
        }

        private TextView CreateTextView(string message)
        {
            TextView textView = new TextView(activity);
            textView.Text = message;
            textView.SetTextColor(ColorStateList.ValueOf(Color.Black));
            textView.TextSize = 20;
            textView.LayoutParameters = linearLayout.LayoutParameters;

            return textView;
        }

        public void DisplayDialog()
        {
            alertDialog.Show();
        }

        public void Dispose()
        {
            alertDialog.Dismiss();
        }
    }
}