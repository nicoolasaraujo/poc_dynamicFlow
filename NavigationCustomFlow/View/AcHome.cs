﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NavigationCustomFlow.View.Common;

namespace NavigationCustomFlow.View
{
    [Activity(Label = "AcHome")]
    public class AcHome : AcControlFlow
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LayoutAcHome);
        }
    }
}