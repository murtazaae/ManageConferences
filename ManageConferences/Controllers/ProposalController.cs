using ManageConferences.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageConferences.Controllers
{
    public class ProposalController : Controller
    {

        private readonly IProposalServices proposalService;
        private readonly IConferenceService conferenceService;
        public ProposalController(IProposalServices proposalService, IConferenceService conferenceService)
        {
            this.proposalService = proposalService;
            this.conferenceService = conferenceService;
        }

        public async Task<IActionResult> Index(int conferenceId)
        {

            var conference = await conferenceService.GetById(conferenceId);
            ViewBag.Title = $"Proposal For Conference {conference.Name} {conference.Location } ";
            ViewBag.ConferenceId = conference.Id;
            return View(await proposalService.GetAll(conferenceId));
        }

        public IActionResult Add(int conferenceId)
        {
            ViewBag.Title = "Add Proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel model )
        {
            if (ModelState.IsValid)
                await proposalService.Add(model);
            return RedirectToAction("Index",new { conferenceId=model.ConferenceId });
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await proposalService.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}
