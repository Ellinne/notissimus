using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notissimus.Core.Site
{
    class SiteParser : Parser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();

            var toys = document.QuerySelectorAll("div").Where(toy => toy.ClassName != null && toy.ClassName.Contains("card-preview"));
            


            var cities = document.QuerySelectorAll("a").Where(city => city.ClassName != null && city.ClassName.Contains("city-selection"));
            var breadcrumbs = document.QuerySelectorAll("ol").Where(bread => bread.ClassName != null && bread.ClassName.Contains("breadcrumb"));
            var names = document.QuerySelectorAll("a").Where(name => name.ClassName != null && name.ClassName.Contains("name"));
            //var names = document.QuerySelectorAll("h1").Where(name => name.ClassName != null && name.ClassName.Contains("content-title"));
            //var prices = document.QuerySelectorAll("div").Where(price => price.ClassName != null && price.ClassName.Contains("price"));

            var prices = document.QuerySelectorAll("[itemprop='price']");

            //var images = document.QuerySelectorAll("img").Where(image => image.ClassName != null && image.ClassName.Contains("img-fluid"));
            var images = document.QuerySelectorAll("img[src]").Where(image => image.ClassName != null && image.ClassName.Contains("img-fluid"));
            //var links = document.QuerySelectorAll("meta").Where(link => link.ClassName != null && link.ClassName.Contains("og:url"));
            var links = document.QuerySelectorAll("a").Where(link => link.ClassName != null && link.ClassName.Contains("name"));

            foreach(var city in cities)
            {
                list.Add(city.TextContent);
            }
            foreach (var bread in breadcrumbs)
            {
                list.Add(bread.TextContent);
            }

            foreach (var name in names)
            {
                list.Add(name.TextContent);
            }
            foreach (var price in prices)
            {
                list.Add(price.GetAttribute("content"));
            } 

            foreach (var image in images)
            {
                list.Add(image.Attributes["src"].Value);
            }

            foreach (var link in links)
            {
                list.Add(link.GetAttribute("href"));
            }

            return list.ToArray();
        }
    }
}
