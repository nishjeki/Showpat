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
        public List<SearchResultVM> Search(string searchTerm)
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

            List<SearchResultVM> searchResultsVM = new List<SearchResultVM>();

            foreach (var searchResult in searchListResponse.Items)
            {
                SearchResultVM searchResultVM = new SearchResultVM();
                searchResultVM.Title = searchResult.Snippet.Title;
                searchResultVM.Description = searchResult.Snippet.Description;
                searchResultsVM.Add(searchResultVM);
            }

            return searchResultsVM;
        }
    }
}