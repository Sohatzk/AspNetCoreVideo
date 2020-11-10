using AspNetCoreVideo.Entities;
using AspNetCoreVideo.Models;
using AspNetCoreVideo.Services;
using AspNetCoreVideo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreVideo.Controllers
{
    public class HomeController : Controller
    {
        private IVideoData _videos;

        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }
        public ViewResult Index()
        {
            var model = _videos.GetAll().Select(video =>
            new VideoViewModel
            {
                Id = video.Id,
                Title = video.Title,
                Genre = Enum.GetName(typeof(Genres), video.GenreId)
            });
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var video = _videos.Get(id);
            if (video is null)
            {
                return RedirectToAction("Index");
            }
            var model = new VideoViewModel { Id = video.Id, Title = video.Title, Genre = Enum.GetName(typeof(Genres), video.GenreId) };
            return View(model);
        }
    }
}
