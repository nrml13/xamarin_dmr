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
using App4.Interfaces;
using App4.Droid.Platform;
using Xamarin.Forms;

[assembly:Dependency(typeof(PlatformInfo))]
namespace App4.Droid.Platform
{
    class PlatformInfo : IPlatformInfo
    {
        public string GetModel()
        {
            return $"{ Build.Manufacturer } { Build.Model }";
        }

        public string GetVersion()
        {
            return $"{ Build.VERSION.Release }";
        }
    }
}