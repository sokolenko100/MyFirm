using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyFirm.View;
using MyFirm.Model;
using MyFirm.AddViewModel;
namespace MyFirm.ViewModelComponent
{
    public class OrdersViewModel 
    {
      #region CommandProperty
      public ICommand AddCommand { get; set; }

      public ICommand DeleteCommand { get; set; }

      public ICommand ChangeCommand { get; set; }

      public ICommand InfoCommand { get; set; }
      #endregion

      #region Constructor
      public OrdersViewModel()
      {
          AddCommand = new Command(arg => AddMethod());
          DeleteCommand = new Command(arg => DeleteMethod());
          ChangeCommand = new Command(arg => ChangeMethod());
          InfoCommand = new Command(arg => InfoMethod());
          _ordersViewModel = this;
          IsChanged = true;
      }
      #endregion

      #region StaticField
      private static OrdersViewModel _ordersViewModel;
      public static AddOrder _addOrders;
      public static Orders _ordersSelected;
      private static Orders _orderDeleteStat;
      #endregion

      #region Field
      private MainMenu _mainMenu;
      #endregion

      #region Property
      public static bool IsAdd { get; set; }
      public static bool  IsChanged { get; set; }
      public static Orders SelectedItemOrders
      {
          get
          {
              return _ordersSelected;
          }
          set
          {
              _ordersSelected = value;
              OrdersViewModel.SetEmployees(_ordersSelected);
          }
      }
      #endregion

      #region Private_Method
      private void _addWindow_Closed(object sender, EventArgs e)
      {
          IsChanged = true;
          //   IsAdd = true;
          _addOrders = null;
      }
      private void CreateAddObjectAndSubscribeEventUnloaded()
      {
          _addOrders = new AddOrder();
          AddOrdersViewModel.GetAddCustomers(_addOrders);
          _addOrders.Unloaded += _addWindow_Closed;
          IsChanged = false;
      }
      private void AddMethod()
      {
          IsChanged = false;
          this.CreateAddObjectAndSubscribeEventUnloaded();
          _addOrders.ShowDialog();
          IsAdd = true;
      }
      private void DeleteMethod()
      {
          IsChanged = false;
          Orders.Delete(OrdersViewModel.SelectedItemOrders);
          this.Display();
      }
      private void ChangeMethod()
      {
          if (IsChanged)
          {
              if (_ordersSelected != null)
              {
                  IsAdd = false;
                  this.CreateAddObjectAndSubscribeEventUnloaded();
                  _addOrders.ShowDialog();
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
      public static OrdersViewModel ReturnObjViewModel()
      {
          return _ordersViewModel;
      }  
      public void Display()
      {
          _mainMenu.OrdersDataGrid.ItemsSource = Orders.ReturnAllOrdersAsList();
      }

      public static void SetEmployees(Orders _orderDelete)
      {
          _orderDeleteStat = _orderDelete;

      }
      #endregion
    }
}
