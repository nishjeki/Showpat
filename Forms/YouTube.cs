using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace ShowPat.Forms
{
    /// <summary>
    /// See https://developers.google.com/youtube/v3/code_samples/dotnet#search_by_keyword
    /// </summary>
    internal class YouTube
    {
        public List<VideoViewModel> Search(string searchTerm)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "REPLACE_ME_WITH_YOUR_YOUTUBE_KEY",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchTerm;
            searchListRequest.MaxResults = 5;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

			List<VideoViewModel> videoViewModels = new List<VideoViewModel>();

            foreach (var searchResult in searchListResponse.Items)
            {
				VideoViewModel videoViewModel = new VideoViewModel();
                videoViewModel.Title = searchResult.Snippet.Title;
                videoViewModel.Description = searchResult.Snippet.Description;
                videoViewModels.Add(videoViewModel);
            }

            return videoViewModels;
        }
    }
}