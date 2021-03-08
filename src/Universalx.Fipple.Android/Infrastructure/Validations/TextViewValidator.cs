using Android.Content;
using Android.Widget;
using Universalx.Fipple.Android.Helpers;

namespace Universalx.Fipple.Android.Infrastructure.Validations
{
    public abstract class TextViewValidator
    {
        protected Context Context { get; }

        protected TextViewValidator(Context context)
        {
            Context = context;
        }

        public virtual void RaiseError(int resouceId, string errorMsg)
        {
            TextView textView = ApplicationManager.GetActivity(Context).FindViewById<TextView>(resouceId);
            RaiseError(textView, errorMsg);
        }

        protected virtual void RaiseError(TextView textView, string errorMsg)
        {
            textView.RequestFocus();
            textView.Error = errorMsg;
        }
    }
}