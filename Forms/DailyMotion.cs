﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Dynamic;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace ShowPat.Forms
{
    class DailyMotion
    {
		public async Task<List<VideoViewModel>> Search(string searchText)
        {
            HttpWebRequest request = WebRequest.Create("https://api.dailymotion.com/videos?fields=id,title,description&search="+searchText) as HttpWebRequest;

            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string stringJson = reader.ReadToEnd();
				List<VideoViewModel> videoViewModels = new List<VideoViewModel>();

				dynamic dynamicJson = JObject.Parse (stringJson);
				dynamic videos = dynamicJson["list"];
				foreach (dynamic video in videos)
                {
					VideoViewModel videoViewModel = new VideoViewModel();
					dynamic title = video["title"];
					videoViewModel.Title = title.Value;
                    dynamic id = video["id"];
                    videoViewModel.VideoID = id.Value;
                    videoViewModel.Host = Host.DailyMotion;
                    videoViewModels.Add(videoViewModel);
                }

                return videoViewModels;
            }
        }

        public Uri GetEmbedUri(VideoViewModel videoViewModel, bool autoPlay = true)
        {
            string uriString = "http://www.dailymotion.com/embed/video/" + videoViewModel.VideoID;
            uriString += "&autoPlay=" + ((autoPlay) ? "1" : "0");
            Uri uri = new Uri(uriString);
            return uri;
        }
    }
}
