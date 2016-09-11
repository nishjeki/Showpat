using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ShowPat.Forms.iOS
{
	[Register("VideoCollectionViewFlowLayout")]
	public class VideoCollectionViewFlowLayout : UICollectionViewFlowLayout
	{
		public VideoCollectionViewFlowLayout(IntPtr handle) : base(handle) 
		{
		}

		public override void PrepareLayout()
		{
			ItemSize = new CGSize(CollectionView.Bounds.Size.Width, ItemSize.Height);
			base.PrepareLayout();
		}
	}
}

