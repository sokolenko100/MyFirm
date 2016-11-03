using System.Windows.Input;
using MyFirm.View;
using MyFirm.ViewModelComponent;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using MyFirm.Model;
using System;
namespace MyFirm.AddViewModel
{
    class AddTasksViewModel : NotifyPropertyChang, IDataErrorInfo
    {

        #region --Private_filds_for_column_name--

        private string _nameTask = "";
        private string _deskription = "";
        private string _taskStatus = "";
        private Employees _employoyee;
        private DateTime _taskDate = DateTime.Now;

        private const int _countCharsDetails = 150;
        private const int _countCharsNameTask = 20;

        private bool _isNameTask;
        private bool _isDeskription;
        private bool _isTaskStatus;
        private bool _isEmployoyee;
        private bool _isTaskDate;

        #endregion

        #region --Property--
        public string Error
        {
            get
            {
                return null;
            }
        }
        public static int _theSelectedIndexEmployees;
        private int _theSelectedIndexTaskStatus;
        public int TheSelectedIndexTasksStatus
        {
            get
            {
                if (TasksViewModel._taskSelected != null && TasksViewModel.IsChanged)
                {
                    return _theSelectedIndexTaskStatus = this.SearchAndReturnTheSelectedIndexTaskStatus(TasksViewModel._taskSelected);
                }
                else
                {
                    return _theSelectedIndexTaskStatus;
                }
            }
            set
            {
                _theSelectedIndexTaskStatus = value;
            }
        }
        public int TheSelectedIndexEmployees
        {
            get
            {
                if (TasksViewModel.IsChanged && TasksViewModel._taskSelected != null)
                {
                    return _theSelectedIndexEmployees = Tasks.ReturnPositionEmployee(Employees, TasksViewModel._taskSelected);

                }
                else
                {
                    return _theSelectedIndexEmployees;
                }
            }
            set
            {
                _theSelectedIndexEmployees = value;
            }
        }
        private List<Employees> employees;
        public List<Employees> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }
        public string Name
        {
            get
            {
                if (TasksViewModel.IsChanged && TasksViewModel._taskSelected != null)
                {
                    return _nameTask = TasksViewModel._taskSelected.task_name;

                }
                else
                {
                    return _nameTask;
                }
            }
            set
            {
                if (value.Length < _countCharsNameTask)
                {
                    _nameTask = value;
                }
                base.OnPropertyChanged("Name");
            }
        }
        public string Deskription
        {
            get
            {
                if (TasksViewModel.IsChanged && TasksViewModel._taskSelected != null)
                {
                    return _deskription = TasksViewModel._taskSelected.task_dateils;

                }
                else
                {
                    return _deskription;
                }
            }
            set
            {
                if (value.Length < _countCharsDetails)
                {
                    _deskription = value;
                }
                base.OnPropertyChanged("Deskription");
            }
        }
        public string TaskStatus
        {
            get
            {
                if (TasksViewModel.IsChanged && TasksViewModel._taskSelected != null)
                {
                    return _taskStatus = TasksViewModel._taskSelected.task_status;

                }
                else
                {
                    return _taskStatus;
                }
            }
            set
            {

                _taskStatus = value;
                _isTaskStatus = true;
                base.OnPropertyChanged("TaskStatus");
            }
        }
        public Employees Employee
        {
            get
            {
                return _employoyee;
            }
            set
            {
                _employoyee = value;
                _isEmployoyee = true;
                base.OnPropertyChanged("Employee");
            }
        }
        public DateTime DateTasks
        {
            get
            {
                if (TasksViewModel.IsChanged && TasksViewModel._taskSelected != null)
                {
                    return _taskDate = TasksViewModel._taskSelected.task_date;
                }
                else
                {
                    return _taskDate;
                }

            }
            set
            {
                _taskDate = value;
                base.OnPropertyChanged("DateTasks");
            }
        }
        #endregion

        #region --Patterns--
        private const string patternName = @"\.";
        private const string patternDate = @"(\d{1,2}\.\d{1,2}\.\d{4})";
        #endregion

        #region --Other Filds--
        public string error;
        private Tasks _tasks;
        private static TasksWindow _addTask;
        private static TasksViewModel _taskViewModel;
        private Regex regexDateTasks;
        private const int _countDateChars = 10;
        #endregion

        #region --indexer_VALIDATION_Column_Name--
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            if ((_nameTask == null) || (_nameTask == ""))
                            {
                                _isNameTask = false;
                                return error = "Not valid";
                            }
                            _isNameTask = true;
                            break;
                        }
                    case "Deskription":
                        {
                            if ((_deskription == null) || (_deskription == ""))
                            {
                                _isDeskription = false;
                                return error = "Not valid";
                            }
                            _isDeskription = true;
                            break;
                        }

                    default:
                        break;
                }
                return string.Empty;
            }
        }

        #endregion

        #region --Command_Delegate--
        public ICommand OkAdd { get; set; }
        public ICommand CenselAdd { get; set; }
        #endregion

        #region --Public_Method--
        public static void GetAddTasks(TasksWindow _addViewModel)
        {
            _addTask = _addViewModel;

        }
        #endregion

        #region -- Public Constructor--
        public AddTasksViewModel()
        {
            OkAdd = new Command(arg => Add());
            CenselAdd = new Command(arg => Censel());
            _tasks = new Tasks();
            _taskViewModel = TasksViewModel.ReturnObjViewModel();
            regexDateTasks = new Regex(patternDate);
            Employees = new List<Employees>(Model.Employees.ReturnAllEmployeeAsList());
        }
        #endregion

        #region --Private Method--
        private int SearchAndReturnTheSelectedIndexTaskStatus(Tasks task)
        {
            switch (task.task_status)
            {
                case "New Order":
                    {
                        return 0;
                    }
                case "Executing":
                    {
                        return 1;
                    }
                case "Executed":
                    {
                        return 2;
                    }
                default:
                    break;
            }

            return 0;
        }
        private void Add()
        {
            if (_isDeskription && _isTaskStatus && _isEmployoyee)
            {
                _tasks.task_date = DateTasks;
                _tasks.task_dateils = Deskription;
                _tasks.task_status = _addTask.TaskStatus.Text;
                _tasks.task_name = Name;
                _tasks.Employees = this.Employee;
                _tasks.Add(_tasks);
                TasksViewModel.IsChanged = false;
            }
            else
            {
                System.Windows.MessageBox.Show("You entered not valid values");
                return;
            }
            _taskViewModel.Display();

            _addTask.Close();
        }
        private void Censel()
        {
            _addTask.Close();
            TasksViewModel.IsChanged = false;
        }
        #endregion
    }
}
