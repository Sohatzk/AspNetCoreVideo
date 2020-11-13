﻿using AspNetCoreVideo.Entities;
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
                Genre = video.Genre.ToString()
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
            var model = new VideoViewModel { Id = video.Id, Title = video.Title, Genre = video.Genre.ToString() };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var video = new Video
                {
                    Title = model.Title,
                    Genre = model.Genre
                };
                _videos.Add(video);
                _videos.Commit();
                return RedirectToAction("Details", new { id = video.Id });
            }
            else return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var video = _videos.Get(id);
            if (video == null) return RedirectToAction("Index");
            return View(video);
        }

        [HttpPost]
        public IActionResult Edit(int id, VideoEditViewModel model)
        {
            var video = _videos.Get(id);
            if (video == null || !ModelState.IsValid)
            {
                return View(model);
            }
            video.Title = model.Title;
            video.Genre = model.Genre;
            _videos.Commit();
            return RedirectToAction("Details", new { id = video.Id });
        }

    }
}

