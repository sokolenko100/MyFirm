using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyFirm.ViewModelComponent;

namespace MyFirm.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        #region -- Fild---
        private EmployeeViewModel _empEmployeeViewModel;
        private CustomersViewModel _custCustomersViewModel;
        private OrdersViewModel _orderViewModel;
        private ProductsViewModel _prodViewModel;
        private TasksViewModel _taskViewModel;
        private static  MainMenu _mainMenu;
        #endregion

        #region -- Constructor  Return Object ViewModel all classes ---
        public MainMenu()
        {
            InitializeComponent();
           _mainMenu = this;
           this._empEmployeeViewModel = EmployeeViewModel.ReturnObjViewModel();
           this._empEmployeeViewModel.CallMainMenuObject();

           this._custCustomersViewModel = CustomersViewModel.ReturnObjViewModel();
           this._custCustomersViewModel.CallMainMenuObject();

           this._orderViewModel = OrdersViewModel.ReturnObjViewModel();
           this._orderViewModel.CallMainMenuObject();
           this._prodViewModel = ProductsViewModel.ReturnObjViewModel();
           this._prodViewModel.CallMainMenuObject();
           this._taskViewModel = TasksViewModel.ReturnObjViewModel();
           this._taskViewModel.CallMainMenuObject();
           TabControlViewModel.SetMainMenuObject();
        }
        #endregion

        #region -- Static Method Returned MainMenu object---
        public  static MainMenu ReturnMeinMenuObject()
        {
            return _mainMenu;
        }
        #endregion
    }
}
