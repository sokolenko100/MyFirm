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
   public class ProductsViewModel
    {
      #region CommandProperty
      public ICommand AddCommand { get; set; }

      public ICommand DeleteCommand { get; set; }

      public ICommand ChangeCommand { get; set; }

      public ICommand InfoCommand { get; set; }
      #endregion

      #region Constructor
      public ProductsViewModel()
      {
          AddCommand = new Command(arg => AddMethod());
          DeleteCommand = new Command(arg => DeleteMethod());
          ChangeCommand = new Command(arg => ChangeMethod());
          InfoCommand = new Command(arg => InfoMethod());
          _productViewModel = this;
          IsChanged = true;
      }
      #endregion

      #region StaticField
      private static ProductsViewModel _productViewModel;
      public static ProductWindows _addProduct;
      public static Products _productsSelected;
      private static Products _productsDeleteStat;
      #endregion

      #region Field
      private MainMenu _mainMenu;
      #endregion

      #region Property
      public static bool IsAdd { get; set; }
      public static bool  IsChanged { get; set; }
      public static Products SelectedItemProducts
      {
          get
          {
              return _productsSelected;
          }
          set
          {
              _productsSelected = value;
              ProductsViewModel.SetEmployees(_productsSelected);
          }
      }
      #endregion

      #region Private_Method
      private void _add_Closed(object sender, EventArgs e)
      {
          IsChanged = true;
        //  IsAdd = true;
          _addProduct = null;
      }
      private void CreateAddObjectAndSubscribeEventUnloaded()
      {

          _addProduct = new ProductWindows();
          AddProductsViewModel.GetAdd(_addProduct);
          _addProduct.Unloaded += _add_Closed;
          IsChanged = false;
      }
      private void AddMethod()
      {
          this.CreateAddObjectAndSubscribeEventUnloaded();
          _addProduct.ShowDialog();
          IsAdd = true;
      }
      private void DeleteMethod()
      {
          IsChanged = false;
          Products.Delete(ProductsViewModel.SelectedItemProducts);
          this.Display();
      }
      private void ChangeMethod()
      {
          if (IsChanged)
          {
              if ( _productsSelected != null)
              {
                  IsAdd = false;
                  this.CreateAddObjectAndSubscribeEventUnloaded();
                  _addProduct.ShowDialog();
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
      public static ProductsViewModel ReturnObjViewModel()
      {
          return _productViewModel;
      }  
      public void Display()
      {
          _mainMenu.ProductDataGrid.ItemsSource = Products.ReturnAllProductsAsList();
      }

      public static void SetEmployees(Products _prodDelete)
      {
          _productsDeleteStat = _prodDelete;
      }
      #endregion
    }
}
