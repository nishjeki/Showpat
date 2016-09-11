using System;
using Foundation;
using UIKit;

namespace ShowPat.Forms.iOS
{
	public class VideoCollectionViewSource : UICollectionViewSource
	{
		MainPageViewModel _mainPageViewModel;

		public VideoCollectionViewSource(MainPageViewModel mainPageViewModel)
		{
			_mainPageViewModel = mainPageViewModel;
		}

		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return _mainPageViewModel.VideoViewModels.Count;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (VideoCollectionViewCell)collectionView.DequeueReusableCell(VideoCollectionViewCell.Key, indexPath);
			cell.UpdateCell(_mainPageViewModel.VideoViewModels[indexPath.Row].Title);

			return cell;
		}
	}
}

