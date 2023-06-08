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
using Store.Commands;

namespace Store.ViewModels.WindowsViewModels
{
    public class MainViewModel : BaseViewModels
    {
        public RelayCommand InsertCommand { get; set; }

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; }
        }

        private ObservableCollection<Category> allCategories;

        public ObservableCollection<Category> AllCategories
        {
            get { return allCategories; }
            set { allCategories = value; }
        }


        public Repo ProductsRepo { get; set; }

        public async Task GetAllCategories()
        {
            await ProductsRepo.GetAllCategories(AllCategories);
        }

        public async Task GetAllProducts()
        {
            await ProductsRepo.GetAllProduct(AllProducts);
        }

        public async void CallCategoryUC()
        {
            await GetAllCategories();

            App.MyWrapPanel.Children.Clear();
            CategoriesUC categoriesUC;
            CategoryUcViewModel categoryUcViewModel;
            for (int i = 0; i < AllCategories.Count; i++)
            {
                categoriesUC = new CategoriesUC();
                categoryUcViewModel = new CategoryUcViewModel();
                categoryUcViewModel.CategoryName = AllCategories[i].Name;
                categoriesUC.DataContext = categoryUcViewModel;
                App.MyWrapPanel.Children.Add(categoriesUC);
            }
        }

        public async void CallProductUC()
        {
            await GetAllProducts();

            App.MyGrid.Children.Clear();
            ProductUC productUC;
            ProductsViewModel productsViewModel;
            for (int i = 0; i < AllProducts.Count; i++)
            {
                productUC = new ProductUC();
                productsViewModel = new ProductsViewModel();
                productsViewModel.ProductName = AllProducts[i].Name;
                productsViewModel.ProductPrice = $"{AllProducts[i].Price} $";
                productsViewModel.ProductQuantity = AllProducts[i].Quantity;
                productsViewModel.ImagePath = AllProducts[i].ImagePath;
                productUC.DataContext = productsViewModel;
                App.MyGrid.Children.Add(productUC);
            }
        }

        public MainViewModel()
        {
            AllProducts = new ObservableCollection<Product>();
            AllCategories = new ObservableCollection<Category>();
            ProductsRepo = new Repo();

            CallProductUC();
            CallCategoryUC();

            InsertCommand = new RelayCommand((obj) =>
            {
                InsertUserControl insertUC = new InsertUserControl();
                InsertUCViewModel insertUCVM = new InsertUCViewModel();
                App.MyGrid.Children.Clear();
                App.MyGrid.Children.Add(insertUC);
            });

        }
    }
}
