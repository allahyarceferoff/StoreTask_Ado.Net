using Store.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModels.UCViewModels
{
    public class CategoryUcViewModel : BaseViewModels
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; OnPropertyChanged(); }
		}

		private string categoryName;

		public string CategoryName
        {
			get { return categoryName; }
			set { categoryName = value; OnPropertyChanged(); }
		}

	}
}
