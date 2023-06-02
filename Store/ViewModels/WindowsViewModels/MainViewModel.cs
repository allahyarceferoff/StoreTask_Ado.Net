using Store.Models;
using Store.Repostiory;
using Store.ViewModels.BaseViewModel;
using Store.ViewModels.UCViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Store.Views.UserControls;

namespace Store.ViewModels.WindowsViewModels
{
    public class MainViewModel : BaseViewModels
    {
        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; }
        }

        public Repo ProductsRepo { get; set; }


        public MainViewModel()
        {
            ProductsRepo = new Repo();
            AllProducts = ProductsRepo.GetAll();

            ProductUC productUC;
            ProductsViewModel productsViewModel;
            for (int i = 0; i < AllProducts.Count; i++)
            {
                productUC = new ProductUC();
                productsViewModel = new ProductsViewModel();
                productsViewModel.ProductName = AllProducts[i].Name;
                productsViewModel.ProductPrice = AllProducts[i].Price;
                productsViewModel.ProductQuantity = AllProducts[i].Quantity;
                productsViewModel.ImagePath = AllProducts[i].ImagePath;
                //productUC.Margin = new Thickness(left, up, right, down);
                productUC.DataContext = productsViewModel;
                App.MyGrid.Children.Add(productUC);
            }

        }
    }
}
