using Store.Commands;
using Store.Models;
using Store.Repostiory;
using Store.ViewModels.BaseViewModel;
using Store.ViewModels.WindowsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Store.ViewModels.UCViewModels
{
    public class DeleteViewModel : BaseViewModels
    {
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand BackCommand { get; set; }

        private ObservableCollection<Product> allProduct;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProduct; }
            set { allProduct = value; OnPropertyChanged(); }
        }

        public Repo ProductsRepo { get; set; }


        private Product selectedItem;

        public Product SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }

        public async void GetAllProducts()
        {
            AllProducts = new ObservableCollection<Product>();
            await ProductsRepo.GetAllProduct(AllProducts);
        }

        public async void DeleteProduct(int id)
        {
            await ProductsRepo.DeleteProduct(id);
        }

        public DeleteViewModel()
        {
            ProductsRepo = new Repo();
            GetAllProducts();

            DeleteCommand = new RelayCommand((obj) =>
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to delete the product?", "Delete product", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    MessageBox.Show($"{selectedItem.Name} has been successfully removed");
                    DeleteProduct(selectedItem.Id);
                    selectedItem= null;
                }
            });

            BackCommand = new RelayCommand((obj) =>
            {
                var vm = new MainViewModel();
            });




        }
    }
}
