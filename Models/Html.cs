using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Html
    {
        public Html()
        {
        }

        public Html(string url, string body)
        {
            Url = url;
            Body = body;
        }

        public int UrlId { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }

        public int DomainId { get; set; }
    }
}
