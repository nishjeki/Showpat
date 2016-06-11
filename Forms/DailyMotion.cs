using System;
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
            HttpWebRequest request = WebRequest.Create("https://api.dailymotion.com/videos?fields=title,description&search="+searchText) as HttpWebRequest;

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
                    videoViewModels.Add(videoViewModel);
                }

                return videoViewModels;
            }
        }
    }
}
