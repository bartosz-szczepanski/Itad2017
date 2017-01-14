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
            var list = _context.Participant.Select(n => n).ToList();
            throw new NotImplementedException();
        }
    }
}
