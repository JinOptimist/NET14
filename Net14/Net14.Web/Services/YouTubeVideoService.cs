using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;
using Net14.Web.EfStuff.Repositories;
using Net14.Web.Models;
namespace Net14.Web.Services
{
    public class YouTubeVideoService
    {
        private VideoSocialRepository _videoSocialRepository;
        
        [AutoRegister]
        public YouTubeVideoService(VideoSocialRepository videoSocialRepository) 
        {
            _videoSocialRepository = videoSocialRepository; 
        }

        private Task<List<SearchResult>> GetVideosFromChannelAsync(string ytChannelId)
        {

            return Task.Run(() =>
            {
                List<SearchResult> res = new List<SearchResult>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyAuB3O2VayUYQct_x1aJBllRxpQf2TMkgA",
                    ApplicationName = "SocialWeb"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Search.List("snippet");
                    searchListRequest.MaxResults = 50;
                    searchListRequest.Type = "video";
                    searchListRequest.ChannelId = ytChannelId;
                    searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }
        public IEnumerable<SocialVideoViewModel> GetVideos(int page, int perPage, string chanelId)
        {
            var res = GetVideosFromChannelAsync(chanelId).Result
            .OrderByDescending(res => res.Snippet.PublishedAt)
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .Select(video => new SocialVideoViewModel()
            {
                VideoDescription = video.Snippet.Title,
                VideoId = video.Id.VideoId,
                VideoPhoto = video.Snippet.Thumbnails.Medium.Url,

            }).ToList();

            return res;

        }

    }
}

