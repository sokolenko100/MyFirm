using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyFirm.View;
using MyFirm.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
namespace MyFirm.ViewModelComponent
{

    public partial class EmployeeViewModel 
  {       
      #region CommandProperty
      public ICommand AddCommand { get; set; }

      public ICommand DeleteCommand { get; set; }

      public ICommand ChangeCommand { get; set; }

      public ICommand InfoCommand { get; set; }
      #endregion

      #region Constructor
        //Set the command
      public EmployeeViewModel()
      {
          AddCommand = new Command(arg => AddMethod());
          DeleteCommand = new Command(arg => DeleteMethod());
          ChangeCommand = new Command(arg => ChangeMethod());
          InfoCommand = new Command(arg => InfoMethod());
          _empEmployeeViewModel = this;
          IsChanged = true;  
      }
      #endregion

      #region StaticField
      private static EmployeeViewModel _empEmployeeViewModel;
      public static AddEmployee _addEmp;
      public static Employees _employeesSelected;
      private static Employees _empDeleteStat;
      #endregion

      #region Field
      private MainMenu _mainMenu;
      #endregion

      #region Property
      public static bool IsAdd { get; set; }
      public static bool  IsChanged { get; set; }

      public static Employees SelectedItemEmployees
      {
          get
          {
              return _employeesSelected;
          }
          set
          {
              _employeesSelected = value;
              EmployeeViewModel.SetEmployees(_employeesSelected);
          }
      }
      #endregion

      #region Private_Method
      //Set need value aften work windows AddEmployee
      private void _addEmp_Closed(object sender, EventArgs e)
      {
          IsChanged = true;
          //   IsAdd = true;
          _addEmp = null;
      }
      private void CreateAddEmployeeObjectAndSubscribeEventUnloaded()
      {
          _addEmp = new AddEmployee();
          AddEmployeesViewModel.GetAddEmployee(_addEmp);
          _addEmp.Unloaded += _addEmp_Closed;
          IsChanged = false;
      }

      // Create AddEmployeeWindows or it !=null call ShowDialog Method
      private void AddMethod()
      {
              IsChanged = false;
              this.CreateAddEmployeeObjectAndSubscribeEventUnloaded();
              _addEmp.ShowDialog();
              IsAdd = true;
      }
      private void DeleteMethod()
      {
              Employees.Delete(EmployeeViewModel.SelectedItemEmployees);
              this.Display();
      }
      // Change  Employee
      private void ChangeMethod()
      {
          if (IsChanged)
          {
              if (_employeesSelected != null)
              {
                  IsAdd = false;
                  this.CreateAddEmployeeObjectAndSubscribeEventUnloaded();
                  _addEmp.ShowDialog();
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
      public static EmployeeViewModel ReturnObjViewModel()
      {
          return _empEmployeeViewModel;
      }
      public void Display()
      {
         _mainMenu.EmployeesDataGrid.ItemsSource = Model.Employees.ReturnAllEmployeeAsList();
      }

      public static void SetEmployees(Employees _empDelete)
      {
          _empDeleteStat = _empDelete;

      }
      #endregion
  }
}

