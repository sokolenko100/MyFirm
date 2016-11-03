using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using MyFirm.View;
using MyFirm.AddViewModel;
using MyFirm.Model;
namespace MyFirm.ViewModelComponent
{

    public partial class CustomersViewModel 
    {
      #region CommandProperty
      public ICommand AddCommand { get; set; }

      public ICommand DeleteCommand { get; set; }

      public ICommand ChangeCommand { get; set; }

      public ICommand InfoCommand { get; set; }
      #endregion

      #region Constructor
      public CustomersViewModel()
      {
          AddCommand = new Command(arg => AddMethod());
          DeleteCommand = new Command(arg => DeleteMethod());
          ChangeCommand = new Command(arg => ChangeMethod());
          InfoCommand = new Command(arg => InfoMethod());
          _customersViewModel = this;
          IsChanged = true;
      }
      #endregion

      #region StaticField
      private static CustomersViewModel _customersViewModel;
      public static AddCustomers _addCustom;
      public static Customers _customersSelected;
      private static Customers _customDeleteStat;
      #endregion

      #region Field
      private MainMenu _mainMenu;
      #endregion

      #region Property
      public static bool IsAdd { get; set; }
      public static bool  IsChanged { get; set; }
      public static Customers SelectedItemCustomers
      {
          get
          {
              return _customersSelected;
          }
          set
          {
              _customersSelected = value;
              CustomersViewModel.SetEmployees(_customersSelected);
          }
      }
      #endregion

      #region Private_Method
      private void _addCustom_Closed(object sender, EventArgs e)
      {
          IsChanged = true;
          //   IsAdd = true;
          _addCustom = null;
      }
      private void CreateAddCustomersObjectAndSubscribeEventUnloaded()
      {
          _addCustom = new AddCustomers();
          AddCustomerViewModel.GetAddCustomers(_addCustom);
          _addCustom.Unloaded += _addCustom_Closed;
          IsChanged = false;
      }
      private void AddMethod()
      {
          IsChanged = false;
          this.CreateAddCustomersObjectAndSubscribeEventUnloaded();
          _addCustom.ShowDialog();
          IsAdd = true;
      }
      private void DeleteMethod()
      {
          IsChanged = false;
          Customers.Delete(CustomersViewModel.SelectedItemCustomers);
          this.Display();
      }
      private void ChangeMethod()
      {
          if (IsChanged)
          {
              if ( _customersSelected != null)
              {
                  IsAdd = false;
                  this.CreateAddCustomersObjectAndSubscribeEventUnloaded();
                  _addCustom.ShowDialog();
              }
          }
      }
      private void InfoMethod()
      {
      } 
      #endregion

      #region Public_Method
      public void CallMainMenuObject()
      {
          _mainMenu = MainMenu.ReturnMeinMenuObject();
          this.Display();
      }
      public static CustomersViewModel ReturnObjViewModel()
      {
          return _customersViewModel;
      }  
      public void Display()
      {
          _mainMenu.CustomerDataGrid.ItemsSource = Customers.GetAll();
      }

      public static void SetEmployees(Customers _customDelete)
      {
          _customDeleteStat = _customDelete;

      }
      #endregion
    }
}
