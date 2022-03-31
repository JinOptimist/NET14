using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.EfStuff.DbModel.SocialDbModels;

namespace Net14.Web.Services
{
    public class YouTubeVideoGetter
    {
        public Task<List<SearchResult>> GetVideosFromChannelAsync(string ytChannelId)
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

    }
}

