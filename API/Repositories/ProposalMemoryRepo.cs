using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class ProposalMemoryRepo : IProposalRepo
    {
        private readonly List<ProposalModel> proposals = new List<ProposalModel>();

        public ProposalMemoryRepo()
        {
            proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Roland Guijt",
                Title = "Understanding ASP.NET Core Security"
            });
            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "John Reynolds",
                Title = "Starting Your Developer Career"
            });
            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Stan Lipens",
                Title = "ASP.NET Core TagHelpers"
            });

            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 202, Id = 501, Speaker = "Kareem", Title = "Informative" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 202, Id = 502, Speaker = "Kareem", Title = "Informative Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 205, Id = 503, Speaker = "Sohail", Title = "Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 205, Id = 504, Speaker = "Sohail", Title = "Informative Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 205, Id = 505, Speaker = "Sohail", Title = "Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 204, Id = 506, Speaker = "MHS", Title = "Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 204, Id = 507, Speaker = "MHS", Title = "Proposal" });
            proposals.Add(new ProposalModel { Approved = true, ConferenceId = 204, Id = 508, Speaker = "MHS", Title = "Informative Proposal" });
        }

        public IEnumerable<ProposalModel> GetAllForConference(int conferenceId)
        {
            return proposals.Where(p => p.ConferenceId == conferenceId);
        }

        public ProposalModel Add(ProposalModel model)
        {
            model.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(model);
            return model;
        }

        public ProposalModel Approve(int proposalId)
        {
            var proposal = proposals.First(p => p.Id == proposalId);
            proposal.Approved = true;
            return proposal;
        }

        public ProposalModel GetById(int id)
        {
            return proposals.Single(p => p.Id == id);
        }
    }
}

