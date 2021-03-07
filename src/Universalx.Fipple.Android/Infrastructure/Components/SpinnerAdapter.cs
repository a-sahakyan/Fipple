using Android.Content;
using Android.Database;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace Universalx.Fipple.Android.Infrastructure.Components
{
    /* Decorator Adapter to allow a Spinner to show no selected items. 
    /  The item is initially displayed instead of the first choice in the Adapter. */
    public class SpinnerAdapter : Object, ISpinnerAdapter, IListAdapter
    {
        protected static int EXTRA = 1;
        protected ISpinnerAdapter adapter;
        protected Context context;
        protected int nothingSelectedLayout;
        protected int nothingSelectedDropdownLayout;
        protected LayoutInflater layoutInflater;

        public SpinnerAdapter(ISpinnerAdapter spinnerAdapter, int nothingSelectedLayout, Context context)
            : this(spinnerAdapter, nothingSelectedLayout, -1, context)
        {
        }

        public SpinnerAdapter(ISpinnerAdapter spinnerAdapter, int nothingSelectedLayout,
                              int nothingSelectedDropdownLayout, Context context)
        {
            this.adapter = spinnerAdapter;
            this.context = context;
            this.nothingSelectedLayout = nothingSelectedLayout;
            this.nothingSelectedDropdownLayout = nothingSelectedDropdownLayout;
            layoutInflater = LayoutInflater.From(context);
        }

        public int Count
        {
            get
            {
                int count = adapter.Count;
                return count == 0 ? 0 : count + EXTRA;
            }
        }

        public bool HasStableIds => adapter.HasStableIds;

        public bool IsEmpty => adapter.IsEmpty;

        public int ViewTypeCount => 1;

        public new int JniIdentityHashCode => adapter.JniIdentityHashCode;

        public JniManagedPeerStates JniManagedPeerState => adapter.JniManagedPeerState;

        public bool AreAllItemsEnabled() => false;

        public void Disposed() => adapter.Disposed();

        public void DisposeUnlessReferenced() => adapter.DisposeUnlessReferenced();

        public void Finalized() => adapter.Finalized();

        protected View GetNothingSelectedDropdownView(ViewGroup parent)
            => layoutInflater.Inflate(nothingSelectedDropdownLayout, parent, false);

        public Object GetItem(int position)
            => position == 0 ? null : adapter.GetItem(position - EXTRA);

        public long GetItemId(int position)
            => position >= EXTRA ? adapter.GetItemId(position - EXTRA) : position - EXTRA;

        public int GetItemViewType(int position) => default;

        protected View GetNothingSelectedView(ViewGroup parent)
            => layoutInflater.Inflate(nothingSelectedLayout, parent, false);

        public bool IsEnabled(int position) => position != 0;

        public void RegisterDataSetObserver(DataSetObserver observer)
            => adapter.RegisterDataSetObserver(observer);

        public void SetJniIdentityHashCode(int value) { }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
            => adapter.SetJniManagedPeerState(value);

        public void SetPeerReference(JniObjectReference reference)
            => adapter.SetPeerReference(reference);

        public void UnregisterDataSetObserver(DataSetObserver observer)
            => adapter.UnregisterDataSetObserver(observer);

        public View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            if (position == 0)
            {
                return nothingSelectedDropdownLayout == -1 ? new View(context) : GetNothingSelectedDropdownView(parent);
            }

            return adapter.GetDropDownView(position - EXTRA, null, parent);
        }

        public View GetView(int position, View convertView, ViewGroup parent)
        {
            if (position == 0)
            {
                return GetNothingSelectedView(parent);
            }

            return adapter.GetView(position - EXTRA, null, parent);
        }
    }
}