// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ShowPat.Forms.iOS
{
    [Register ("VideosViewController")]
    partial class VideosViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar sbDailyMotion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar sbVimeo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar sbYouTube { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchDisplayController searchDisplayController { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView videoCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (sbDailyMotion != null) {
                sbDailyMotion.Dispose ();
                sbDailyMotion = null;
            }

            if (sbVimeo != null) {
                sbVimeo.Dispose ();
                sbVimeo = null;
            }

            if (sbYouTube != null) {
                sbYouTube.Dispose ();
                sbYouTube = null;
            }

            if (searchDisplayController != null) {
                searchDisplayController.Dispose ();
                searchDisplayController = null;
            }

            if (videoCollectionView != null) {
                videoCollectionView.Dispose ();
                videoCollectionView = null;
            }
        }
    }
}