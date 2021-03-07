using Android.Content;
using Android.Util;
using System;

namespace Universalx.Fipple.Android.Infrastructure.Helpers
{
    public static class Screen
    {
        public static int DipToAbsolutePixel(ContextWrapper contextWrapper, float dp)
        {
            DisplayMetrics displayMetrics = contextWrapper.Resources.DisplayMetrics;
            float strokeWidthPx = TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, displayMetrics);
            int widthPx = (int)Math.Round(strokeWidthPx, 0);

            return widthPx;
        }
    }
}