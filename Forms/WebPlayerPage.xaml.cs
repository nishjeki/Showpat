using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ShowPat.Forms
{
    public partial class WebPlayerPage : ContentPage
    {
        VideoViewModel _videoViewModel;

        public WebPlayerPage(VideoViewModel videoViewModel)
        {
            InitializeComponent();
            _videoViewModel = videoViewModel;
            this.webView.Source =  videoViewModel.GetEmbedUri().ToString();
        }
    }
}
