using System;

using Xamarin.Forms;

namespace ShowPat.Forms
{
    public partial class MainPage : ContentPage
	{
        MainPageVM _mainPageVM;

		public MainPage ()
		{
			InitializeComponent ();
            _mainPageVM = new MainPageVM();
            this.BindingContext = _mainPageVM;
		}

        public void SearchButtonPressed(object sender, EventArgs e)
        {
            _mainPageVM.SearchResultsVM.Clear();
            _mainPageVM.Search();
        }
    }
}

