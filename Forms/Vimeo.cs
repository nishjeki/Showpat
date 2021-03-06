﻿using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ShowPat.Forms
{
	class Vimeo
	{
		public async Task<List<VideoViewModel>> Search(string searchText)
		{
			string accessToken = "REPLACE_ME_WITH_YOUR_VIMEO_ACCESS_TOKEN";
			HttpWebRequest request = WebRequest.Create("https://api.vimeo.com/videos?access_token=" + accessToken + "&query=" + searchText) as HttpWebRequest;

			using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
			{
				StreamReader reader = new StreamReader(response.GetResponseStream());

				string stringJson = reader.ReadToEnd();
				List<VideoViewModel> videoViewModels = new List<VideoViewModel>();

				dynamic dynamicJson = JObject.Parse (stringJson);
				dynamic videos = dynamicJson["data"];
				foreach (dynamic video in videos)
				{
					VideoViewModel videoViewModel = new VideoViewModel();
					dynamic title = video["name"];
					videoViewModel.Title = title.Value;
                    dynamic uri = video["uri"];
					string videoID = uri.ToString().Replace("/videos/","");
					videoViewModel.VideoID = videoID;
                    videoViewModel.Host = Host.Vimeo;
					videoViewModels.Add(videoViewModel);
				}

				return videoViewModels;
			}
		}

		internal Uri GetEmbedUri(VideoViewModel videoViewModel, bool autoPlay = true)
		{
			string uriString = "http://player.vimeo.com/video/" + videoViewModel.VideoID;
			uriString += "?autoplay=" + ((autoPlay) ? "1" : "0");
			Uri uri = new Uri(uriString);
			return uri;
		}
	}
}

