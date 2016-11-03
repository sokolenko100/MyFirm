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
    public class TasksViewModel 
    {
      #region CommandProperty
      public ICommand AddCommand { get; set; }

      public ICommand DeleteCommand { get; set; }

      public ICommand ChangeCommand { get; set; }

      public ICommand InfoCommand { get; set; }
      #endregion

      #region Constructor
      public TasksViewModel()
      {
          AddCommand = new Command(arg => AddMethod());
          DeleteCommand = new Command(arg => DeleteMethod());
          ChangeCommand = new Command(arg => ChangeMethod());
          InfoCommand = new Command(arg => InfoMethod());
          IsChanged = true;
          _taskViewModel = this;
      }
      #endregion

      #region StaticField
      private static TasksViewModel _taskViewModel;
      public static TasksWindow _addTask;
      public static Tasks _taskSelected;
      private static Tasks _taskDeleteStat;
      #endregion

      #region Field
      private MainMenu _mainMenu;
      #endregion

      #region Property
      public static bool  IsChanged { get; set; }
      public static bool IsAdd { get; set; }
      public static Tasks SelectedItemTasks
      {
          get
          {
              return _taskSelected;
          }
          set
          {
              _taskSelected = value;
              TasksViewModel.SetEmployees(_taskSelected);
          }
      }
      #endregion

      #region Private_Method
      private void _add_Closed(object sender, EventArgs e)
      {
          IsChanged = true;
       //   IsAdd = true;
          _addTask = null;
      }
      private void CreateAddObjectAndSubscribeEventUnloaded()
      {
          _addTask = new TasksWindow();
          AddTasksViewModel.GetAddTasks(_addTask);
          _addTask.Unloaded += _add_Closed;
          IsChanged = false;
      }
      private void AddMethod()
      {
          IsChanged = false;
          this.CreateAddObjectAndSubscribeEventUnloaded();
          _addTask.ShowDialog();
          IsAdd = true;
      }
      private void DeleteMethod()
      {
          if (TasksViewModel._taskSelected!=null)
          {
              IsChanged = false;
              Tasks.Delete(TasksViewModel.SelectedItemTasks);
              this.Display(); 
          }
      }
      private void ChangeMethod()
      {
          if (IsChanged)
          {
              if (_taskSelected != null)
              {
                  IsAdd = false;
                  this.CreateAddObjectAndSubscribeEventUnloaded();
                  _addTask.ShowDialog();
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
      public static TasksViewModel ReturnObjViewModel()
      {
          return _taskViewModel;
      }  
      public void Display()
      {
          _mainMenu.TasksDataGrid.ItemsSource = Tasks.ReturnAllTasksAsList();
      }

      public static void SetEmployees(Tasks _tasksDelete)
      {
          _taskDeleteStat = _tasksDelete;
      }
      #endregion
    }
}
