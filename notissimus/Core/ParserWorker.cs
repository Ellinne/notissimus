using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notissimus.Core
{
    class ParserWorker<T> where T: class
    {
        readonly Parser<T> parser;
        ParserSettings parserSettings;
        HtmlLoader loader;
        bool isActive;
        #region properties
        public Parser<T> Parser;
        public ParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        #endregion
        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public ParserWorker(Parser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(Parser<T> parser, ParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for (int i = parserSettings.Start; i <= parserSettings.End; i++)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }

                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source); //ParseAsync

                var result = parser.Parse(document);

                OnNewData?.Invoke(this, result);
            }

            OnCompleted?.Invoke(this);
            isActive = false;
        }


    }
}
