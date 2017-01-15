using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itad2017.Models;
using Itad2017.Data;

namespace Itad2017.Services
{

    public class ObjectValidationService : IDataObjectValidation
    {
        private readonly ApplicationDbContext _context;
        public ObjectValidationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool ValidateNewParticipant(Participant newParticipant)
        {
            if (newParticipant.FirstName == null || newParticipant.FirstName == "") { throw new ArgumentException("FirstName invalid"); }
            if (newParticipant.SecondName == null || newParticipant.SecondName == "") { throw new ArgumentException("SecondName invalid"); }
            if (newParticipant.Email == null || newParticipant.Email == "") { throw new ArgumentException("Email invalid"); }
            if (!newParticipant.Email.Contains('@')) { throw new ArgumentException("Email invalid"); }
            if (!newParticipant.Email.Contains('.')) { throw new ArgumentException("Email invalid"); }
            if (_context.Participant.Where(n=>n.Email == newParticipant.Email).Count()>0) { throw new ArgumentException("Email exist in database"); }
            return true;
        }
    }
}
