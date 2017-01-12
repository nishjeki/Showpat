﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ShowPat.Forms.Droid
{
	public class YouTubeFragment : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			return inflater.Inflate(Resource.Layout.VideoCollection, container, false);
		}

		public void SetAdapter(VideoCollectionAdapter videoCollectionAdapter)
		{
			GridView gridView = this.View.FindViewById<GridView>(Resource.Id.gridView1);
			gridView.Adapter = videoCollectionAdapter;
		}
	}
}
