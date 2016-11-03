using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyFirm.View;
using System.Collections.ObjectModel;

namespace MyFirm.ViewModelComponent
{
    public class TabControlViewModel :NotifyPropertyChang
    {
        #region Field
        private static MainMenu _mainMenu;
        private static TabControlViewModel _tabControlViewModel;
        private int _selectIndex;
        #endregion

        #region Property
        public EmployeeViewModel EmployeesViewModel { get; set; }
        public CustomersViewModel CustomersViewModel { get; set; } 
        public ProductsViewModel ProductsViewModel { get; set; }
        public TasksViewModel TasksViewModel { get; set; }
        public OrdersViewModel OrdersViewModel { get; set; }
        public ICommand CommandExit { get; set; }
       
        public int SelectIndex { 
            get
            {
            return _selectIndex;
            }
            set
            {
                _selectIndex = value;
                base.OnPropertyChanged("SelectIndex");
            }
        }
        #endregion

        #region --Constryctor--
        public TabControlViewModel()
        {
            EmployeesViewModel = new EmployeeViewModel();
            CustomersViewModel = new CustomersViewModel();
            ProductsViewModel = new ProductsViewModel();
            TasksViewModel = new TasksViewModel();
            OrdersViewModel = new OrdersViewModel();
            CommandExit = new Command(args =>CloseMainMenuWindow());
            _tabControlViewModel = this;
        }
        #endregion

        #region --Private Method--
        public static void  SetMainMenuObject()
        {
            _mainMenu = MainMenu.ReturnMeinMenuObject();
        }
        #endregion

        #region --Public Method--
        public void CloseMainMenuWindow()
        {
            _mainMenu.Close();
        }
        public static MainMenu ReturnMainMenu()
        {
            return _mainMenu;
        }
        public static TabControlViewModel ReturnTabControlViewModel()
        {
            return _tabControlViewModel;
        }
        #endregion
    }
}
