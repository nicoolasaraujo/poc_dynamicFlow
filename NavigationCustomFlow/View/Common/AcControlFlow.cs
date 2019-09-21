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
using NavigationCustomFlow.Utils;

namespace NavigationCustomFlow.View.Common
{
    [Activity(Label = "AcControlFlow")]
    public abstract class AcControlFlow : AcBase
    {
        private ImageButton navBack;
        private ImageButton navForward;
        private ImageButton navPause;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /// <summary>
        /// Se content view override to inflate the cliente layout in layout flow controller
        /// </summary>
        /// <param name="layoutResID"></param>
        public override void SetContentView(int layoutResID)
        {
            base.SetContentView(Resource.Layout.footerNavigation);

            LayoutInflater inflater = LayoutInflater.From(this);
            Android.Views.View inflatedLayout = inflater.Inflate(layoutResID, null);
            LinearLayout ll = this.Window.FindViewById<LinearLayout>(Resource.Id.navigation_container);
            ll.AddView(inflatedLayout);
            this.LoadNavComponents();
        }

        private void LoadNavComponents()
        {
            this.navBack = GetImageButton(Resource.Id.nav_back);
            this.navPause = GetImageButton(Resource.Id.nav_pause);
            this.navForward = GetImageButton(Resource.Id.nav_forward);

            #region DelegateRegion

            this.navBack.Click += delegate { this.PreviousActivity(); };
            this.navForward.Click += delegate { this.NextActivity(); };
            this.navPause.Click += delegate { this.PauseFlow(); };

            #endregion DelegateRegion
        }

        private void PauseFlow()
        {
            var toast = Toast.MakeText(this, "You have selected the pause flow option", ToastLength.Long);
            toast.Show();
        }

        private void NextActivity()
        {
            var toast = Toast.MakeText(this, "You have selected the forward option!", ToastLength.Long);
            toast.Show();

            ControlFlow.Instance.NextActivity(this);
            //this.Dispose();
            //this.Finish();
        }

        private void PreviousActivity()
        {
            var toast = Toast.MakeText(this, "You have selected the previous option!", ToastLength.Long);
            toast.Show();
            ControlFlow.Instance.PreviousActivity(this);
        }
    }
}