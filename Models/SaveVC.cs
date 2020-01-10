using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class SaveVC
    {
        public SaveVC(Input input, List<Html> htmls)
        {
            Input = input;
            Htmls = htmls;
        }

        public Input Input { get; set; }
        public List<Html> Htmls { get; set; }

    }
}
