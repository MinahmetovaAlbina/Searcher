using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using HtmlAgilityPack;

namespace WebApplication2.Models
{
    public static class Logic
    {
        public async static void SaveDomain(this Input input, DbContext context)
        {
            await context.AddAsync(new Input(input.Domain, input.Depth));
        }

        public async static void Parse(this SaveVC saveVC)
        {
            if (saveVC.Input.Domain == null || saveVC.Input.Domain == "")
                return;
            saveVC.Parse(saveVC.Input.Domain, saveVC.Input.Depth);
            //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);
        }

        private async static void Parse(this SaveVC saveVC, string url, int i)
        {
            if (i < 0 || saveVC.Htmls.Any(h =>  h.Url == url))
                return;
            i--;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc;
            try
            {
                htmlDoc = web.Load(url);
            }
            catch
            {
                return;
            }
            var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
            var body = "";
            if (htmlBody != null) body = htmlBody.InnerText;
            saveVC.Htmls.Add(new Html(url, body));
            var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
            if (nodes == null) return;
            foreach (var node in nodes)
            {
                if (node.Attributes["href"] == null) continue;
                var current = node.Attributes["href"].Value;
                var urlNow = "";
                var uri = new Uri(current, UriKind.RelativeOrAbsolute);
                if (!uri.IsAbsoluteUri)
                    urlNow = url;
                urlNow += current;     
                if (current != "#")
                {
                    saveVC.Parse(urlNow, i);
                }
            }
        }
    }
}



