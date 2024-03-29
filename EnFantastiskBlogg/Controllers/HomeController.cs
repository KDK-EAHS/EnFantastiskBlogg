﻿using EnFantastiskBlogg.Data;
using EnFantastiskBlogg.Models;
using EnFantastiskBlogg.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EnFantastiskBlogg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeViewModel
            {
                Posts = await  _context.Posts.OrderBy(x => x.CreatedDate).ToListAsync<Post>()
            };
            return View(vm);

            //var posts = await _context.Posts.OrderBy(x => x.CreatedDate).ToListAsync<Post>();
            //return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}