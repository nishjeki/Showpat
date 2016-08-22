using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShowPat.Forms.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        MainPageViewModel _mainPageViewModel;

        public MainPage()
        {
            this.InitializeComponent();

            //LoadApplication(new ShowPat.Forms.UWP.App());

            _mainPageViewModel = new MainPageViewModel();
            this.DataContext = _mainPageViewModel;
        }

        private void asbSearch_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            Search();
        }
        
        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (string.IsNullOrWhiteSpace(_mainPageViewModel.SearchText))
                return;

            PivotItem piSelected = pivot.SelectedItem as PivotItem;
            if (piSelected == piYouTube)
                _mainPageViewModel.SearchYouTube();
            else if (piSelected == piDailyMotion)
                _mainPageViewModel.SearchDailyMotion();
            else if (piSelected == piVimeo)
                _mainPageViewModel.SearchVimeo();
            else
                throw new NotImplementedException();
        }
    }
}
