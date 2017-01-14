using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itad2017.Models
{
    public class Participation
    {
        public int ID { get; set; }
        public Workshop Workshop { get; set; }
        public Participant Who { get; set; }
    }
}
