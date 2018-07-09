using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ApplicationContext:DbContext
    {

        public DbSet<ConferenceModel> conferenceModels { get; set; }
    }
}
