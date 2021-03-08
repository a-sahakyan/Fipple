using Android.App;
using Android.Content;

namespace Universalx.Fipple.Android.Helpers
{
    public static class ApplicationManager
    {
        public static Activity GetActivity(Context context)
        {
            return context as Activity;
        }
    }
}