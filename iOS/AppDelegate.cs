using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ShowPat.Forms.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		//Required for using storyboard
		//Application output: The app delegate must implement the window property if it wants to use a main storyboard file.ß
		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			return true;
		}
	}
}

