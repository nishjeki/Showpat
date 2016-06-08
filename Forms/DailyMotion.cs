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
        public async Task<List<SearchResultVM>> Search(string searchTerm)
        {
            HttpWebRequest request = WebRequest.Create("https://api.dailymotion.com/videos?fields=title,description&search="+searchTerm) as HttpWebRequest;

            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string stringJson = reader.ReadToEnd();
                List<SearchResultVM> searchResultsVM = new List<SearchResultVM>();

                IList videoList = dynamicJson["list"] as IList;
                foreach (JObject videoDetails in videoList)
                {
                    SearchResultVM searchResultVM = new SearchResultVM();
                    JToken jToken = videoDetails.GetValue("title");
                    searchResultVM.Title = jToken.Value<string>();
                    searchResultsVM.Add(searchResultVM);
                }

                return searchResultsVM;
            }
        }
    }
}
