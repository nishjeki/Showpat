﻿using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System.Threading.Tasks;
using System;

namespace ShowPat.Forms
{
    /// <summary>
    /// See https://developers.google.com/youtube/v3/code_samples/dotnet#search_by_keyword
    /// </summary>
    internal class YouTube
    {
        public async Task<List<VideoViewModel>> Search(string searchText)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
				ApiKey = "REPLACE_ME_WITH_YOUR_YOUTUBE_KEY",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchText;
            searchListRequest.MaxResults = 10;

            var searchListResponse = await searchListRequest.ExecuteAsync();

			List<VideoViewModel> videoViewModels = new List<VideoViewModel>();

            foreach (var searchResult in searchListResponse.Items)
            {
				VideoViewModel videoViewModel = new VideoViewModel();
                videoViewModel.Host = Host.YouTube;
                videoViewModel.Title = searchResult.Snippet.Title;
                videoViewModel.Description = searchResult.Snippet.Description;
                videoViewModel.VideoID = searchResult.Id.VideoId;
                videoViewModels.Add(videoViewModel);
            }

            return videoViewModels;
        }

        public Uri GetEmbedUri(VideoViewModel videoViewModel, bool autoPlay = true)
        {
            string uriString = "http://www.youtube.com/embed/" + videoViewModel.VideoID;
            uriString += "?&rel=0&autoplay=" + ((autoPlay) ? "1" : "0");
            Uri uri = new Uri(uriString);
            return uri;
        }
    }
}