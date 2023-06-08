using Store.Commands;
using Store.Models;
using Store.Repostiory;
using Store.ViewModels.BaseViewModel;
using Store.ViewModels.WindowsViewModels;
using Store.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Store.ViewModels.UCViewModels
{
    public class InsertUCViewModel : BaseViewModels
    {
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand BackCommand { get; set; }

        private ObservableCollection<Category> allCategory;

        public ObservableCollection<Category> AllCategory
        {
            get { return allCategory; }
            set { allCategory = value; OnPropertyChanged(); }
        }

        public Repo ProductsRepo { get; set; }

        private string pName;

        public string PName
        {
            get { return pName; }
            set { pName = value; OnPropertyChanged(); }
        }

        private decimal pPrice;

        public decimal PPrice
        {
            get { return pPrice; }
            set { pPrice = value; OnPropertyChanged(); }
        }

        private int pQuantity;

        public int PQuantity
        {
            get { return pQuantity; }
            set { pQuantity = value; OnPropertyChanged(); }
        }

        private Category selectedItem;

        public Category SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }

        public async void GetAllCategories()
        {
            AllCategory = new ObservableCollection<Category>();
            await ProductsRepo.GetAllCategories(AllCategory);
        }

        public InsertUCViewModel()
        {    
            ProductsRepo = new Repo();
            GetAllCategories();

            InsertCommand = new RelayCommand((obj) =>
            {               
                ProductsRepo.Insert(PName, PPrice, PQuantity,SelectedItem);

                MessageBox.Show($"{pName} added successfully","Product Added",MessageBoxButton.OK,MessageBoxImage.Information);

                PName = String.Empty;
                PPrice = 0;
                PQuantity = 0;

            });

            BackCommand = new RelayCommand((obj) =>
            {
                var vm = new MainViewModel();                
            });



        }
    }
}
