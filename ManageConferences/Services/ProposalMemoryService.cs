using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageConferences.Services
{
    public class ProposalMemoryService : IProposalServices
    {
        private readonly List<ProposalModel> proposals = new List<ProposalModel>();

        public ProposalMemoryService()
        {
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 202, Id = 501, Speaker = "Kareem", Title = "Informative" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 202, Id = 502, Speaker = "Kareem", Title = "Informative Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 205, Id = 503, Speaker = "Sohail", Title = "Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 205, Id = 504, Speaker = "Sohail", Title = "Informative Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 205, Id = 505, Speaker = "Sohail", Title = "Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 204, Id = 506, Speaker = "MHS", Title = "Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 204, Id = 507, Speaker = "MHS", Title = "Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 204, Id = 508, Speaker = "MHS", Title = "Informative Proposal" });
        }
        public Task Add(ProposalModel model)
        {
            model.Id = proposals.Max(c => c.Id) + 1;
            proposals.Add(model);
            return Task.CompletedTask;
        }
        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() =>
            {
                var proposal = proposals.First(p => p.Id == proposalId);
                proposal.Approved = true;
                return proposal;
            });
        }
        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => proposals.Where(c => c.ConferenceId == conferenceId).AsEnumerable());
        }
    }
}
