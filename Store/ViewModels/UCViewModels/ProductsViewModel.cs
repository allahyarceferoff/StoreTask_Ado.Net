using Store.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.UCViewModels
{
    public class ProductsViewModel: BaseViewModels
    {
		private string productName;

		public string ProductName
		{
			get { return productName; }
			set { productName = value; OnPropertyChanged(); }
		}

		private int productQuantity;

		public int ProductQuantity
        {
			get { return productQuantity; }
			set { productQuantity = value; OnPropertyChanged(); }
		}

		private decimal productPrice;

		public decimal ProductPrice
        {
			get { return productPrice; }
			set { productPrice = value; OnPropertyChanged(); }
		}

		private string imagePath;

		public string ImagePath
		{
			get { return imagePath; }
			set { imagePath = value; OnPropertyChanged(); }
		}
	}
}
