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

		public void SearchBarTextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(searchBar.Text))
				_mainPageViewModel.VideoViewModels.Clear ();
		}

		public void YouTubeButtonClicked(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(searchBar.Text))
				_mainPageViewModel.SearchYouTube();
		}

		public void DailyMotionButtonClicked(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(searchBar.Text))
				_mainPageViewModel.SearchDailyMotion();
		}

		public void VimeoButtonClicked(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(searchBar.Text))
				_mainPageViewModel.SearchVimeo();
		}

        public void OnItemTapped(object sender, EventArgs e)
        {
            ItemTappedEventArgs itemTappedEventArgs = e as ItemTappedEventArgs;
            VideoViewModel videoViewModel = itemTappedEventArgs.Item as VideoViewModel;
            WebPlayerPage playerPage = new WebPlayerPage(videoViewModel);
            Navigation.PushAsync(playerPage);
        }
    }
}

