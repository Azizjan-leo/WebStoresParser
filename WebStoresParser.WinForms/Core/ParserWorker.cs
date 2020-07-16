using AngleSharp.Html.Parser;
using System;
using System.Threading.Tasks;

namespace WebStoresParser.WinForms.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> _parser;
        ParserSettings _settings;
        HtmlLoader loader;
        bool _isActive;

        #region Properties

        public IParser<T> Parser { get => _parser; set => _parser = value; }

        public ParserSettings Settings
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
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }
        #endregion

        #region Envents

        public event Action<object, T> OnNewData;

        public event Action<object> OnCompleted;

        #endregion

        public ParserWorker(IParser<T> parser)
        {
            Parser = parser;
        }

        public ParserWorker(IParser<T> parser, ParserSettings settings)
        {
            Parser = parser;
            _settings = settings;
        }

        public async Task Start(string productName)
        {
            IsActive = true;
            await Worker(productName);
        }

        public void Abort()
        {
            IsActive = false;
        }

        private async Task Worker(string productName)
        {
            if (!IsActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }


            var source = await loader.GetSourceByProductName(productName);
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);

            var result = Parser.Parse(document);

            OnNewData?.Invoke(this, result);
           
            OnCompleted?.Invoke(this);
            IsActive = false;
        }
    }
}
