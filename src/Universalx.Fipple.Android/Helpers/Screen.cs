using Android.Content;
using Android.Util;
using System;

namespace Universalx.Fipple.Android.Helpers
{
    public static class Screen
    {
        public static int DipToAbsolutePixel(ContextWrapper contextWrapper, float dp)
        {
            DisplayMetrics displayMetrics = contextWrapper.Resources.DisplayMetrics;
            int px = (int)Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, displayMetrics), 0);

            return px;
        }
    }
}