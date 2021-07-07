using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    internal class MainWindowViewModel : BindableBase
    {
        private string stockValue;
        public string StockValue
        {
            get { return stockValue; }
            set { SetProperty(ref stockValue, value); }
        }

        public MainWindowViewModel()
        {
            // 株価を取得したいサイトのURL
            var code = "2317.T";
            var urlstring = $"http://stocks.finance.yahoo.co.jp/stocks/detail/?code={code}";
            // ページの HTML を取得
            var client = new HttpClient();
            var res = await client.GetStringAsync(urlstring);
            // HTML をパース
            var parser = new HtmlParser();
            var doc = await parser.ParseDocumentAsync(res);
            // クエリーセレクタを指定し株価部分を取得する
            var nodes = doc.QuerySelectorAll("#main td[class=stoksPrice]");
            
            stockValue = nodes.ToString();
        }
    }
}
