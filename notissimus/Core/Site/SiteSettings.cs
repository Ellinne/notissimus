
namespace notissimus.Core.Site
{
    class SiteSettings : ParserSettings
    {
        public SiteSettings(int start, int end)
        {
            Start = start;
            End = end;
        }
        public string BaseUrl { get; set; } = "https://www.toy.ru/catalog/boy_transport/ ";
        public string Prefix { get; set; } = "PAGEN_5={CurrentId}";
        public int Start { get; set; }
        public int End { get; set; }
    }
}
