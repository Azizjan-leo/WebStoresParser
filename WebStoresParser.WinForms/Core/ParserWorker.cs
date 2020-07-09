using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoresParser.WinForms.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> _parser;
        IParserSettings _settings;
        bool isActive;
        HtmlLoader loader;

        #region Properties

        public IParser<T> Parser 
        {
            get
            {
                return _parser;
            }
            set
            {
                _parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = value;
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

        #region Envents

        public event Action<object, T> OnNewData;

        public event Action<object> OnCompleted;

        #endregion

        public ParserWorker(IParser<T> parser)
        {
            _parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings settings)
        {
            _parser = parser;
            _settings = settings;
        }

        public void Start(string productName)
        {
            isActive = true;
            Worker(productName);
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker(string productName)
        {
            
            if (!isActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }
                  

            var source = await loader.GetSourceByProductName(productName);
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);

            var result = _parser.Parse(document);

            OnNewData?.Invoke(this, result);
           
            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
