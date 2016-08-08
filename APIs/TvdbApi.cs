using TVDB = TVKetchup.Models.TVDB;
using Flurl.Http;
using System.Threading.Tasks;
using Flurl;

namespace TVKetchup.APIs
{
    public class TvdbApi
    {
        private Options.TVDB options;
        private string jwtToken { get; set; }

        public TvdbApi(Options.TVDB Options)
        {
            options = Options;
        }

        public void Login()
        {
            var task = options.BaseURL
                .AppendPathSegment("login")
                .PostJsonAsync(new TVDB.Auth { 
                    apikey = options.ApiKey, 
                    username = options.Username, 
                    userkey = options.UserKey})
                .ReceiveJson<TVDB.AuthResponse>();
                task.Wait();
            if (task.IsCompleted && string.IsNullOrWhiteSpace(task.Result.Error))
            {
                            jwtToken = task.Result.Token;
            }
        }

        public async Task<TVDB.SeriesEpisodes> GetSeriesEpisodesPage(int seriesId, int page)
        {
            if (jwtToken == null)
            {
                Login();
            }            
            return await options.BaseURL
                .AppendPathSegment(string.Format("series/{0}/episodes", seriesId))
                .SetQueryParam("page", page)
                .WithOAuthBearerToken(jwtToken)
                .GetJsonAsync<TVDB.SeriesEpisodes>();
        }

        public async Task<TVDB.SeriesEpisodes> GetSeriesAllEpisodes(int seriesId)
        {
            int page = 1;
            TVDB.SeriesEpisodes data = new TVDB.SeriesEpisodes();
            do
            {
                var next = await GetSeriesEpisodesPage(seriesId, page);
                data.Merge(next);
                page++;
            }
            while (page <= data.links.last);
            return data;
        }
        
        public async Task<TVDB.EpisodeRecordData> GetEpisodeDetails(int episodeId)
        {
            if (jwtToken == null)
            {
                Login();
            }           
            return await options.BaseURL
                .AppendPathSegment(string.Format("/episodes/{0}", episodeId))
                .WithOAuthBearerToken(jwtToken)
                .GetJsonAsync<TVDB.EpisodeRecordData>();
        }

        public async Task<TVDB.SeriesImageQueryResults> GetBackgroundImages(int seriesId)
        {
            if (jwtToken == null)
            {
                Login();
            }           
            return await options.BaseURL
                .AppendPathSegment(string.Format("/series/{0}/images/query", seriesId))
                .SetQueryParam("keyType", "fanart")
                .WithOAuthBearerToken(jwtToken)
                .GetJsonAsync<TVDB.SeriesImageQueryResults>();
        }
    }
}