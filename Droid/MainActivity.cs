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
		ViewPager viewPager;
		TabsFragmentPagerAdapter tabsFragmentPagerAdapter;
		YouTubeFragment youTubeFragment;
		DailyMotionFragment dailyMotionFragment;
		VimeoFragment vimeoFragment;

		static MainPageViewModel _mainPageViewModel = new MainPageViewModel();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.Main);

			tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);

			InitTabLayout();

			_mainPageViewModel.VideoViewModels.CollectionChanged += (sender1, e1) =>
			{
				Android.Support.V4.App.Fragment selectedFragment = tabsFragmentPagerAdapter.GetItem(tabLayout.SelectedTabPosition);
				if (selectedFragment == youTubeFragment)
					youTubeFragment.SetAdapter(new VideoCollectionAdapter(this, _mainPageViewModel));
				else if (selectedFragment == dailyMotionFragment)
					dailyMotionFragment.SetAdapter(new VideoCollectionAdapter(this, _mainPageViewModel));
				else if (selectedFragment == vimeoFragment)
					vimeoFragment.SetAdapter(new VideoCollectionAdapter(this, _mainPageViewModel));
				else
					throw new NotImplementedException();
			};


			SearchView searchView = FindViewById<SearchView>(Resource.Id.searchView1);
			searchView.QueryTextSubmit += (sender, e) =>
			{
				PerformSearch(searchView);
			};
		}

		void PerformSearch(SearchView searchView)
		{
			if (string.IsNullOrWhiteSpace(searchView.Query))
				return;
			                            
			Android.Support.V4.App.Fragment selectedFragment = tabsFragmentPagerAdapter.GetItem(tabLayout.SelectedTabPosition);

			_mainPageViewModel.SearchText = searchView.Query;

			if (selectedFragment == youTubeFragment)
				_mainPageViewModel.SearchYouTube();
			else if (selectedFragment == dailyMotionFragment)
				_mainPageViewModel.SearchDailyMotion();
			else if (selectedFragment == vimeoFragment)
				_mainPageViewModel.SearchVimeo();
			else
				throw new NotImplementedException();
		}

		void InitTabLayout()
		{
			tabLayout.SetTabTextColors(Android.Graphics.Color.Aqua, Android.Graphics.Color.AntiqueWhite);

			youTubeFragment = new YouTubeFragment();
			dailyMotionFragment = new DailyMotionFragment();
			vimeoFragment = new VimeoFragment();

			//Fragment array
			var fragments = new Android.Support.V4.App.Fragment[]
			{
				youTubeFragment,
				dailyMotionFragment,
				vimeoFragment
			};

			//Tab title array
			var titles = CharSequence.ArrayFromStringArray(new[] {
				"YouTube",
				"DailyMotion",
				"Vimeo",
			});

		 	viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
			//viewpager holding fragment array and tab title text
			tabsFragmentPagerAdapter = new TabsFragmentPagerAdapter(SupportFragmentManager, fragments, titles);
			viewPager.Adapter = tabsFragmentPagerAdapter;

			// Give the TabLayout the ViewPager 
			tabLayout.SetupWithViewPager(viewPager);

			//Perform search on Tab change
			viewPager.PageSelected += (sender, e) =>
			{
				SearchView searchView = FindViewById<SearchView>(Resource.Id.searchView1);
				PerformSearch(searchView);
			};
		}
	}
}