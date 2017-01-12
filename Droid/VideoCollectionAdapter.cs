using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ShowPat.Forms.Droid
{
	public class VideoCollectionAdapter : BaseAdapter
	{
		private Context _context;
		private MainPageViewModel _mainPageViewModel;
		private LayoutInflater _layoutInflator;

		public VideoCollectionAdapter(Context context, MainPageViewModel mainPageViewModel)
		{
			this._context = context;
			this._mainPageViewModel = mainPageViewModel;
		}

		public override int Count
		{
			get
			{
				return _mainPageViewModel.VideoViewModels.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			if (_layoutInflator == null)
			{
				_layoutInflator = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
			}
			if (convertView == null)
			{
				convertView = _layoutInflator.Inflate(Resource.Layout.Video, parent, false);
			}
			//BIND DATA
			TextView textView = convertView.FindViewById<TextView>(Resource.Id.textViewTitle);
			textView.Text = _mainPageViewModel.VideoViewModels[position].Title;

			return convertView;
		}
	}
}
