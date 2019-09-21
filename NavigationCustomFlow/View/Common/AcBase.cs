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

namespace NavigationCustomFlow.View.Common
{
    [Activity(Label = "AcBase")]
    public class AcBase : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public Button GetButton(int id)
        {
            return FindViewById<Button>(id);
        }

        public ImageButton GetImageButton(int resourceId)
        {
            return FindViewById<ImageButton>(resourceId);
        }
    }
}