﻿using ManageConferences.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Threading.Tasks;

namespace ManageConferences.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceService service;

        public ConferenceController(IConferenceService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conference Overview";
            return View(await service.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                await service.Add(model);
            return RedirectToAction("Index");
        }


    }
}
