using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Input;
using MyFirm.View;
using MyFirm.ViewModelComponent;
using System.Text.RegularExpressions;
using System.ComponentModel;
using MyFirm.Model;

namespace MyFirm.ViewModelComponent
{
  public class AddEmployeesViewModel : NotifyPropertyChang, IDataErrorInfo
  {
        #region --Private_filds_for_column_name--
        private string _login="";
        private string _password="";
        private string _name="";
        private string _surName="";
        private string _phone="";
        private string _email="";
        private DateTime _birthday=DateTime.Now;

        private const int _countCharInPhone = 12;
        private const int _countCharInlogin = 30;
        private const int _countCharInpassword = 30;
        private const int _countCharInname = 20;
        private const int _countCharInSurName = 20;
        private const int _countCharInEmail = 30;

        private bool _isLogin;
        private bool _isPassword;
        private bool _isName;
        private bool _isSurName;
        private bool _isPhone;
        private bool _isEmail;
        #endregion

        #region --Property--
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string Login
        {
            get
            {
                if (EmployeeViewModel.IsChanged && EmployeeViewModel._employeesSelected != null)
                {
                    return _login = EmployeeViewModel._employeesSelected.emp_login;

                }
                else
                {
                    return _login;
                }
            }
            set
            {
                if (value.Length < _countCharInlogin)
                {
                    _login = value;
                }
                base.OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get
            {
                if (EmployeeViewModel.IsChanged && EmployeeViewModel._employeesSelected != null)
                {
                 return _password = EmployeeViewModel._employeesSelected.emp_password;
                }
                else
                {
                    return _password;
                }
            }
            set
            {
                if (value.Length < _countCharInpassword)
                {
                    _password = value;
                }
                base.OnPropertyChanged("Password");
            }
        }
        public string Name
        {
            get
            {
                if (EmployeeViewModel.IsChanged && EmployeeViewModel._employeesSelected != null)
                {
                    return _name= EmployeeViewModel._employeesSelected.emp_name;
                }
                else
                {
                    return _name;
                }
            }
            set
            {
                if (value.Length<_countCharInname)
                {
                    _name = value;
                }
                base.OnPropertyChanged("Name"); 
            }
        }
        public string SurName
        {
            get
            {
                if (EmployeeViewModel.IsChanged && EmployeeViewModel._employeesSelected != null)
                {
                 return _surName= EmployeeViewModel._employeesSelected.emp_surName;
                }
                else
                {
                    return _surName;
                }
            }
            set
            {
                if (value.Length < _countCharInSurName)
                {
                    _surName = value;
                }
                base.OnPropertyChanged("SurName");
            }
        }
        public string Phone
        {
            get
            {
                if (EmployeeViewModel.IsChanged && EmployeeViewModel._employeesSelected != null)
                {
                return _phone = EmployeeViewModel._employeesSelected.emp_phone;
                }
                else
                {
                    return _phone;
                }
            }
            set
            {
                if (value.Length < _countCharInPhone+1)
                {
                    _phone = value;
                }
             
                base.OnPropertyChanged("Phone");
            }
        }
        public string Email
        {
            get
            {
                if (EmployeeViewModel.IsChanged && EmployeeViewModel._employeesSelected != null)
                {
                return _email = EmployeeViewModel._employeesSelected.emp_email;
                }
                else
                {
                    return _email;
                }
            }
            set
            {
                if (value.Length < _countCharInEmail)
                {
                    _email = value;
                }
                base.OnPropertyChanged("Email");
            }
        }
        public DateTime DateBirth
        {
            get
            {
                if (EmployeeViewModel.IsChanged && EmployeeViewModel._employeesSelected != null)
                {
                return _birthday =(DateTime) EmployeeViewModel._employeesSelected.emp_dateBirth;
                }
                else
                {
                    return _birthday;
                }
            }
            set
            {
                _birthday = value;
                base.OnPropertyChanged("DateBirth");
            }
        }
        #endregion

        #region --Patterns--
        private const string patternPassword = @"_+|\W";
        private const string patternPhone = @"\([0-9]{3}\)[0-9]{7}";
        private const string patternEmail = @"\w+@[a-zA-Z]+?\.[a-zA-Z]{2,6}";
        #endregion

        #region --Other Filds--
          public string error;
          private Employees emp;
          private static AddEmployee _addEmp;
          private static EmployeeViewModel _empEmployeeViewModel;
          Regex regexPhone;
          Regex regexEmail;
          Regex regexPassword;
          #endregion

        #region --indexer_Column_Name--
          public string this[string columnName]
          {
              get
              {
                  switch (columnName)
                  {
                      case "Login":
                          {
                              if ((_login == null) || (_login == ""))
                              {
                                  _isLogin = false;
                                  return error = "Not valid";
                              }
                              _isLogin = true;
                              break;
                          }
                      case "Password":
                          {
                              if ((regexPassword.IsMatch(_password)) || (_password == null) || (_password == ""))
                              {
                                  _isPassword = false;
                                  return error = "Not valid";
                              }
                              _isPassword = true;
                              break;
                          }
                      case "Name":
                          {
                              if ((_name == null) || (_name == ""))
                              {
                                  _isName = false;
                                  return error = "Not valid";
                              }
                              _isName = true;
                              break;
                          }
                      case "SurName":
                          {
                              if ((_surName == null) || (_surName == ""))
                              {
                                  _isSurName = false;
                                  return error = "Not valid";
                              }
                              _isSurName = true;
                              break;
                          }
                      case "Phone":
                          {
                              bool myBool = regexPhone.IsMatch(_phone);
                              if (!(_phone.Length == _countCharInPhone) || !regexPhone.IsMatch(_phone) || (_phone == null) || (_phone == ""))
                              {
                                  _isPhone = false;
                                  return error = "Not valid";
                              }
                              _isPhone = true;
                              break;
                          }
                      case "Email":
                          {
                              if (!(regexEmail.IsMatch(_email)) || (_email == null) || (_email == ""))
                              {
                                  _isEmail = false;
                                  return error = "Not valid";
                              }
                              _isEmail = true;
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
          public static void GetAddEmployee(AddEmployee _addEmp1)
          {
              _addEmp = _addEmp1;
          }
          #endregion

        #region -- Public Constructor--
         public AddEmployeesViewModel()
        {
            OkAdd = new Command(arg => Add());
            CenselAdd = new Command(arg => Censel());
            emp = new Employees();
            _empEmployeeViewModel = EmployeeViewModel.ReturnObjViewModel();
            regexEmail = new Regex(patternEmail);
            regexPhone = new Regex(patternPhone);
            regexPassword = new Regex(patternPassword);
        }
        #endregion

        #region --Private Method--
         private void Add()
        {
            if (_isLogin && _isPassword && _isName && _isSurName && _isPhone && _isEmail)
            {
                emp.emp_name = Name;
                emp.emp_surName = SurName;
                emp.emp_email = Email;
                emp.emp_dateBirth = DateBirth;
                emp.emp_phone = Phone;
                emp.emp_login = Login;
                emp.emp_password = Password;
                emp.Add(emp);
                EmployeeViewModel.IsChanged = false;
            }
            else
            {
                System.Windows.MessageBox.Show("You entered not valid values");
                return;
            }
            _empEmployeeViewModel.Display();
            
            _addEmp.Close();
        }
        private void Censel()
        {
            _addEmp.Close();
            EmployeeViewModel.IsChanged = false;
        }
      #endregion
    }
}
