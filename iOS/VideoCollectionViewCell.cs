using System;

using Foundation;
using UIKit;

namespace ShowPat.Forms.iOS
{
	public partial class VideoCollectionViewCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString("VideoCollectionViewCell");
		public static readonly UINib Nib;

		static VideoCollectionViewCell()
		{
			Nib = UINib.FromName("VideoCollectionViewCell", NSBundle.MainBundle);
		}

		protected VideoCollectionViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateCell(string title)
		{
			this.lblTitle.Text = title;
		}
	}
}
