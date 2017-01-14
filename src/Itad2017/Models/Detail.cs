using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itad2017.Models
{
    public class Detail
    {
        public int ID { get; set; }
        public DateTime RegisterTime { get; set; }
        public bool IsConfirmed { get; set; }
        public string Code { get; set; }
        public string TshirtSize { get; set; }
        public bool IsPresent { get; set; }
    }
}
