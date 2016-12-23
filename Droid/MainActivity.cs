using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace ShowPat.Forms.Droid
{
	[Activity (Label = "Forms.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FragmentActivity
	{
		TabLayout tabLayout;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.Main);

			tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);

			InitTabLayout();
		}

		void InitTabLayout()
		{
			tabLayout.SetTabTextColors(Android.Graphics.Color.Aqua, Android.Graphics.Color.AntiqueWhite);
			//Fragment array
			var fragments = new Android.Support.V4.App.Fragment[]
			{
				new YouTubeFragment(),
				new DailyMotionFragment(),
				new VimeoFragment(),
			};

			//Tab title array
			var titles = CharSequence.ArrayFromStringArray(new[] {
				"YouTube",
				"DailyMotion",
				"Vimeo",
			});

			var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
			//viewpager holding fragment array and tab title text
			viewPager.Adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, fragments, titles);

			// Give the TabLayout the ViewPager 
			tabLayout.SetupWithViewPager(viewPager);
		}
	}
}

