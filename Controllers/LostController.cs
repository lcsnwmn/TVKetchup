using System.Linq;
using TVKetchup.APIs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TVDB = TVKetchup.Models.TVDB;
using System.Collections.Generic;
using System;
using Flurl;

namespace TVKetchup.Controllers
{
    public class LostController : Controller
    {
        private Options.TVDB tvdbOptions;
        private TvdbApi api;
        private List<TVDB.BasicEpisode> episodeList;

        public LostController(IOptions<Options.TVDB> TvdbOptions)
        {
            tvdbOptions = TvdbOptions.Value;   
            api = new TvdbApi(tvdbOptions);
            var episodeTask = api.GetSeriesAllEpisodes(73739);
            episodeTask.Wait();
            episodeList = episodeTask.Result.data.Where(ep => ep.airedSeason != 0).OrderBy(ep => ep.airedSeason).ThenBy(ep => ep.airedEpisodeNumber).ToList();       
        }

        // GET: Lost
        public ActionResult Episodes()
        {
            ViewData["episodeList"] = episodeList;
            ViewData["background"] = getBackgroundImage(73739);
            return View("Episodes");
        }

        public ActionResult Episode(int id)
        {
            var detailsTask = api.GetEpisodeDetails(id);
            detailsTask.Wait();
            var episode = detailsTask.Result.data;
            episode.filename = "http://thetvdb.com/banners/".AppendPathSegment(episode.filename);
            ViewData["episode"] = episode;
            ViewData["background"] = getBackgroundImage(73739);
            return View("Episode");
        }

        public ActionResult Today()
        {
            var index = (DateTime.Today - new DateTime(2016,8,2)).Days;
            var episodeId = episodeList[index + 3].id; // jumped forward 3 days
            
            return Episode(episodeId.Value);
        }

        private string getBackgroundImage(int seriesId)
        {
            var imageTask = api.GetBackgroundImages(seriesId);
            imageTask.Wait();
            var images = imageTask.Result.data;
            var mostPopularImage = images.OrderByDescending(i => i.ratingsInfo.average).FirstOrDefault();
            return mostPopularImage.fileName;
        }
    }
}