using System;
using UIKit;

namespace ShowPat.Forms.iOS
{
	public partial class VideosViewController : UIViewController
	{
		static MainPageViewModel _mainPageViewModel = new MainPageViewModel();

		//Modified the default constructor, since removing of the auto-generated 
		//SearchViewController.nib is deleted manually.
		//Exception: Could not find an existing managed instance for this object, 
		//nor was it possible to create a new managed instance 
		//(because the type 'ShowPat.Forms.iOS.SearchViewController' 
		//does not have a constructor that takes one IntPtr argument).
		public VideosViewController(IntPtr handle) : base(handle)
		{
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			videoCollectionView.RegisterNibForCell(VideoCollectionViewCell.Nib, VideoCollectionViewCell.Key);
			videoCollectionView.Source = new VideoCollectionViewSource(_mainPageViewModel);
			_mainPageViewModel.VideoViewModels.CollectionChanged += (sender1, e1) =>
				{
					videoCollectionView.ReloadData();
				};

			//Do null check because individual search buttons are available only when the
			//respective tab is visible
			if (sbYouTube != null)
			{
				sbYouTube.TextChanged += (sender, e) =>
				{
					_mainPageViewModel.SearchText = sbYouTube.Text;
				};

				sbYouTube.SearchButtonClicked += (sender, e) =>
				{
					if (string.IsNullOrWhiteSpace(_mainPageViewModel.SearchText))
						return;
					_mainPageViewModel.SearchYouTube();

					//Do not do anything below. Above method is async
				};
			}

			if (sbDailyMotion != null)
			{
				sbDailyMotion.TextChanged += (sender, e) =>
				{
					_mainPageViewModel.SearchText = sbDailyMotion.Text;
				};

				sbDailyMotion.SearchButtonClicked += (sender, e) =>
				{
					if (string.IsNullOrWhiteSpace(_mainPageViewModel.SearchText))
						return;
					_mainPageViewModel.SearchDailyMotion();

					//Do not do anything below. Above method is async
				};

			}

			if (sbVimeo != null)
			{
				sbVimeo.TextChanged += (sender, e) =>
				{
					_mainPageViewModel.SearchText = sbVimeo.Text;
				};

				sbVimeo.SearchButtonClicked += (sender, e) =>
				{
					if (string.IsNullOrWhiteSpace(_mainPageViewModel.SearchText))
						return;
					_mainPageViewModel.SearchVimeo();

					//Do not do anything below. Above method is async
				};
			}
		}

		public override void ViewDidAppear(bool animated)
		{
			if (string.IsNullOrWhiteSpace(_mainPageViewModel.SearchText))
			   return;

			//Handling tab change
			if (sbYouTube != null)
			{
				sbYouTube.Text = _mainPageViewModel.SearchText;
				_mainPageViewModel.SearchYouTube();
			}

			if (sbDailyMotion != null)
			{
				sbDailyMotion.Text = _mainPageViewModel.SearchText;
				_mainPageViewModel.SearchDailyMotion();
			}

			if (sbVimeo != null)
			{
				sbVimeo.Text = _mainPageViewModel.SearchText;
				_mainPageViewModel.SearchVimeo();
			}

			base.ViewDidAppear(animated);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


