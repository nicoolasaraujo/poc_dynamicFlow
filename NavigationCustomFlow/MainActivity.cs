using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using NavigationCustomFlow.View.Common;

namespace NavigationCustomFlow
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AcControlFlow
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
        }

        private void LoadVisualComponents()
        {
        }
    }
}