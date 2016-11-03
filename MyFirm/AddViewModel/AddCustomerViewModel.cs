using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyFirm.View;
using MyFirm.ViewModelComponent;
using System.Text.RegularExpressions;
using System.ComponentModel;
using MyFirm.Model;


namespace MyFirm.AddViewModel
{
    public class AddCustomerViewModel : NotifyPropertyChang, IDataErrorInfo
    {

        #region --Private_filds_for_column_name--
        private string _address="";
        private string _name = "";
        private string _surName = "";
        private string _phone = "";
        private string _email = "";
        private DateTime _birthday=DateTime.Now;

        private const int _birthdayCountChars=10;
        private const int _countCharInPhone = 12;
        private const int _countCharInAddress = 30;
        private const int _countCharInname = 20;
        private const int _countCharInSurName = 20;
        private const int _countCharInEmail = 30;

        private bool _isaddress;
        private bool _isName;
        private bool _isSurName;
        private bool _isPhone;
        private bool _isEmail;
        private bool _isBirthday;
        #endregion

        #region --Property--
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string Address
        {
            get
            {
                if (CustomersViewModel.IsChanged && CustomersViewModel._customersSelected != null)
                {
                    return _address = CustomersViewModel._customersSelected.cust_address;
                }
                else
                {
                    return _address;
                }
            }
            set
            {
                if (value.Length < _countCharInAddress)
                {
                    _address = value;
                }
                base.OnPropertyChanged("Address");
            }
        }
        public string Name
        {
            get
            {
                if (CustomersViewModel.IsChanged && CustomersViewModel._customersSelected != null)
                {
                 return _name= CustomersViewModel._customersSelected.cust_name;
                }
                else
                {
                    return _name;
                }
            }
            set
            {
                if (value.Length < _countCharInname)
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
                if (CustomersViewModel.IsChanged && CustomersViewModel._customersSelected != null)
                {
                    return _surName=CustomersViewModel._customersSelected.cust_surName;
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
                if (CustomersViewModel.IsChanged && CustomersViewModel._customersSelected != null)
                {
                    return _phone = CustomersViewModel._customersSelected.cust_phone;
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
                if (CustomersViewModel.IsChanged && CustomersViewModel._customersSelected != null)
                {
                   return _email = CustomersViewModel._customersSelected.cust_email;
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
                if (CustomersViewModel.IsChanged && CustomersViewModel._customersSelected != null)
                {
                return _birthday=(DateTime)CustomersViewModel._customersSelected.cust_dateBirth;
                }
                else
                {
                    return _birthday;
                }
            }
            set
            {
                _birthday = value;
              //  _isBirthday = true;
                base.OnPropertyChanged("DateBirth");
            }
        }
        #endregion

        #region --Patterns--
        private const string patternLogin = @"\w";
        private const string patternPassword = @"_+|\W";
        private const string patternPhone = @"\([0-9]{3}\)[0-9]{7}";
        private const string patternEmail = @"\w+@[a-zA-Z]+?\.[a-zA-Z]{2,6}";
   //     private const string patternDate = @"(\d{1,2}\.\d{1,2}\.\d{4})";
        #endregion

        #region --Other Filds--
        public string error;
        private Customers _customers;
        private static AddCustomers _addCustom;
        private static CustomersViewModel _customerViewModel;
        Regex regexPhone;
        Regex regexEmail;
        #endregion
    
        #region --indexer_Column_Name--
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Address":
                        {
                            if ((_address == null) || (_address == ""))
                            {
                                _isaddress = false;
                                return error = "Not valid";
                            }
                            _isaddress = true;
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
                            if (!regexPhone.IsMatch(_phone) || (_phone == null) || (_phone == ""))
                            {
                                _isPhone = false;
                                return error = "Not valid";
                            }
                            _isPhone = true;
                            break;
                        }
                    case "Email":
                        {
                            if (!regexEmail.IsMatch(_email) || (_email == null) || (_email == ""))
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
        public static void GetAddCustomers(AddCustomers _addCustomViewModel)
        {
            _addCustom = _addCustomViewModel;

        }
        #endregion

        #region -- Public Constructor--
        public AddCustomerViewModel()
        {
            OkAdd = new Command(arg => Add());
            CenselAdd = new Command(arg => Censel());
            _customers = new Customers();
            _customerViewModel = CustomersViewModel.ReturnObjViewModel();
            regexEmail = new Regex(patternEmail);
            regexPhone = new Regex(patternPhone);
        }
        #endregion

        #region --Private Method--
        private void Add()
        {
            if (_isaddress && _isName && _isSurName && _isPhone && _isEmail)
            {
                _customers.cust_name = Name;
                _customers.cust_surName = SurName;
                _customers.cust_email = Email;
                _customers.cust_dateBirth = DateBirth; 
                _customers.cust_phone = Phone;
                _customers.cust_address = Address;
                
                _customers.Add(_customers);
                CustomersViewModel.IsChanged = false;
            }
            else
            {
                System.Windows.MessageBox.Show("You entered not valid values");
                return;
            }
            _customerViewModel.Display();

            _addCustom.Close();
        }
        private void Censel()
        {
            _addCustom.Close();
            CustomersViewModel.IsChanged = false;
        }
        #endregion
    }
}