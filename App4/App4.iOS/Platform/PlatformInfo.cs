using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace App4.iOS.Platform
{
    class PlatformInfo
    {
        UIDevice device = new UIDevice();

        public string GetModel()
        {
            return device.Model;
        }

        public string GetVersion()
        {
            return device.SystemVersion;
        }
    }
}