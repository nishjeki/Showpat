using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShowPat.Forms
{
    public class VideoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Host _host;
        public Host Host
        {
            get
            {
                return _host;
            }

            set
            {
                _host = value;
                RaisePropertyChanged("Host");
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        private string _videoID;
        public string VideoID
        {
            get
            {
                return _videoID;
            }

            set
            {
                _videoID = value;
                RaisePropertyChanged("VideoID");
            }
        }

        internal Uri GetEmbedUri()
        {
			if (Host == Host.YouTube)
				return new YouTube().GetEmbedUri(this);
			else if (Host == Host.DailyMotion)
				return new DailyMotion().GetEmbedUri(this);
			else if (Host == Host.Vimeo)
				return new Vimeo().GetEmbedUri(this);
			else
                throw new NotImplementedException();
        }
    }
}
