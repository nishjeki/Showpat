using System;

using Xamarin.Forms;

namespace ShowPat.Forms
{
    public partial class MainPage : ContentPage
	{
        MainPageViewModel _mainPageViewModel;

		public MainPage ()
		{
			InitializeComponent ();
            _mainPageViewModel = new MainPageViewModel();
            this.BindingContext = _mainPageViewModel;
		}

        public void SearchButtonPressed(object sender, EventArgs e)
        {
			_mainPageViewModel.SearchDailyMotion();
        }

		public void YouTubeButtonClicked(object sender, EventArgs e)
		{
			_mainPageViewModel.SearchYouTube();
		}

		public void DailyMotionButtonClicked(object sender, EventArgs e)
		{
			_mainPageViewModel.SearchDailyMotion();
		}
    }
}

