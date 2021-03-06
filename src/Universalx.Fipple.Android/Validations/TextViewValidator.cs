using Android.Widget;

namespace Universalx.Fipple.Android.Validations
{
    public abstract class TextViewValidator
    {
        protected BaseActivity Activity { get; }

        protected TextViewValidator(BaseActivity activity)
        {
            Activity = activity;
        }

        public virtual void RaiseError(int resouceId, string errorMsg)
        {
            TextView textView = Activity.FindViewById<TextView>(resouceId);
            Validate(textView, errorMsg);
        }

        protected virtual void Validate(TextView textView, string errorMsg)
        {
            textView.RequestFocus();
            textView.Error = errorMsg;
        }
    }
}