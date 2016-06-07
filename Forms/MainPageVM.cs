using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ShowPat.Forms
{
    class MainPageVM : INotifyPropertyChanged
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

        private ObservableCollection<SearchResultVM> _searchResultsVM;
        public ObservableCollection<SearchResultVM> SearchResultsVM
        {
            get
            {
                return _searchResultsVM;
            }
        }

        public MainPageVM()
        {
            _searchResultsVM = new ObservableCollection<SearchResultVM>();
        }

        internal void Search()
        {
            YouTube youTube = new YouTube();
            List<SearchResultVM> searchResultsVM = youTube.Search(SearchText);
            foreach (SearchResultVM searchResultVM in searchResultsVM)
            {
                SearchResultsVM.Add(searchResultVM);
            }
        }
    }
}
