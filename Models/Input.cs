using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Input
    {
        public Input(string domain, int depth)
        {
            Domain = domain ?? throw new ArgumentNullException(nameof(domain));
            Depth = depth;
        }

        public Input()
        {
        }

        public string Domain { get; set; }
        public int Depth { get; set; }

        public int DomainId { get; set; }
    }
}
