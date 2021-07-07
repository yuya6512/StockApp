using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    internal class MainWindowViewModel : BindableBase
    {
        private string stock;
        public string Stock
        {
            get { return stock; }
            set { SetProperty(ref stock, value); }
        }

        public MainWindowViewModel()
        {
            Stock = "a";
        }
    }
}
