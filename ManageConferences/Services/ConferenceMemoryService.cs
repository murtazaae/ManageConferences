using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageConferences.Services
{
    public class ConferenceMemoryService : IConferenceService
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();

        public ConferenceMemoryService()
        {
            conferences.Add(new ConferenceModel { AttendeeTotal = 20021, Id = 202, Location = "Dubai, UAE", Name = "Micheal", Start = new DateTime(2018, 7, 7) });
            conferences.Add(new ConferenceModel { AttendeeTotal = 105, Id = 203, Location = "Karachi, Pakistan", Name = "John", Start = new DateTime(2018, 7, 12) });
            conferences.Add(new ConferenceModel { AttendeeTotal = 105, Id = 204, Location = "Alain, UAE", Name = "Shabbir", Start = new DateTime(2018, 8, 10) });
            conferences.Add(new ConferenceModel { AttendeeTotal = 107, Id = 205, Location = "Sharjah, UAE", Name = "Nasir", Start = new DateTime(2018, 8, 10) });
        }
        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => conferences.First(c => c.Id == id));
        }
        public Task<StatisticsModel> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new StatisticsModel
                {
                    NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                    AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)

                };
            }
            );
        }
        public Task Add(ConferenceModel model)
        {

            model.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(model);
            return Task.CompletedTask;
        }
    }
}
