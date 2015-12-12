using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Phoneword
{
    [Activity(Label = "@string/CallHistory")]
    public class CallHistoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var callList = Intent.Extras.GetStringArrayList("call_history");
            ListAdapter =
                new ArrayAdapter<string>(
                    this,
                    Android.Resource.Layout.SimpleListItem1,
                    callList);
        }
    }
}