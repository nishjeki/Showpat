using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ShowPat.Forms
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set { if (_searchText != value) { _searchText = value; RaisePropertyChanged("SearchText"); } }
        }

		private ObservableCollection<VideoViewModel> _videoViewModels;
		public ObservableCollection<VideoViewModel> VideoViewModels
        {
            get
            {
                return _videoViewModels;
            }
        }

        public MainPageViewModel()
        {
			_videoViewModels = new ObservableCollection<VideoViewModel>();
        }

        internal async void SearchDailyMotion()
        {
			_videoViewModels.Clear ();
			
            DailyMotion dailyMotion = new DailyMotion();
			List<VideoViewModel> videoViewModels = await dailyMotion.Search(SearchText);
			foreach (VideoViewModel videoViewModel in videoViewModels)
            {
				VideoViewModels.Add(videoViewModel);
            }
        }

		internal async void SearchYouTube()
		{
			_videoViewModels.Clear ();

			YouTube youTube = new YouTube();
			List<VideoViewModel> videoViewModels = await youTube.Search(SearchText);
			foreach (VideoViewModel videoViewModel in videoViewModels)
			{
				VideoViewModels.Add(videoViewModel);
			}
		}
    }
}
