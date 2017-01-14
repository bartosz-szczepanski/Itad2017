using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itad2017.Services
{
    public interface IDataObjectValidation
    {
        bool ValidateNewParticipant(Models.Participant newParticipant);
    }
}
