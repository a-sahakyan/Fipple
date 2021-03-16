using Android.App;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using System;

namespace Universalx.Fipple.Android.Helpers
{
    public static class Screen
    {
        public static int DipToAbsolutePixel(float dp)
        {
            DisplayMetrics displayMetrics = Application.Context.Resources.DisplayMetrics;
            int px = (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, displayMetrics), 0);
            return px;
        }

        public static void CloseKeyboard(View view)
        {
            InputMethodManager inputMethodManager = (InputMethodManager)Application.Context.GetSystemService(Context.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
        }
    }
}