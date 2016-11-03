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
    public class AddOrdersViewModel : NotifyPropertyChang, IDataErrorInfo
    {

        #region --Private_filds_for_column_name--

        private DateTime _dateOrder = DateTime.Now;
        private string _countProduct = "";
        private string _orderStatus = "";
        private string _deteilsOrder = "";

        private const int _countCharInDetails = 100;
        private const int _countProd = int.MaxValue;
        private bool _isDateOrder;
        private bool _isOrderStatus;
        private bool _isDeteilsOrder;
        private static bool _isSelectedElementCustomers;
        private static bool _isSelectedElementProducts;
        private bool _isCountProduct;

        #endregion

        #region --Property--
        private int _theSelectedIndexEmployeesStatus;
        public int TheSelectedIndexEmployeesStatus
        {
            get
            {
                if (OrdersViewModel._ordersSelected != null && OrdersViewModel.IsChanged)
                {
                    return _theSelectedIndexEmployeesStatus = this.SearchAndReturnTheSelectedIndexEmployeesStatus(OrdersViewModel._ordersSelected);
                }
                else
                {
                    return _theSelectedIndexEmployeesStatus;
                }
            }
            set
            {
                _theSelectedIndexEmployeesStatus = value;
            }
        }
        public static int _theSelectedIndexProducts;
        public int TheSelectedIndexProducts
        {
            get
            {
                if (OrdersViewModel.IsChanged && OrdersViewModel._ordersSelected != null)
                {
                    return _theSelectedIndexProducts = OrdersProducts.ReturnPositionProducts(Products, OrdersViewModel._ordersSelected);
                }
                else
                {
                    return _theSelectedIndexProducts;
                }
            }
            set
            {
                _theSelectedIndexProducts = value;
            }
        }

        public static int _theSelectedIndexCustomers;
        public int TheSelectedIndexCustomers
        {
            get
            {
                if (OrdersViewModel.IsChanged && OrdersViewModel._ordersSelected != null)
                {
                    return _theSelectedIndexCustomers = CustomersOrders.ReturnPositionCustomers(Customers, OrdersViewModel._ordersSelected);
                }
                else
                {
                    return _theSelectedIndexCustomers;
                }
            }
            set
            {
                _theSelectedIndexCustomers = value;
            }
        }
        private static Products _selectedElementProducts;
        public static Products StaticSelectedElementProducts
        {
            get
            {
                if (_isSelectedElementProducts)
                {
                    return _selectedElementProducts;
                }
                return null;
            }
        }
        public Products SelectedElementProducts
        {
            set
            {
                _selectedElementProducts = value;
                _isSelectedElementProducts = true;
                OnPropertyChanged("SelectedElementProducts");
            }
            get { return _selectedElementProducts; }
        }
        private static Customers _selectedElementCustomers;
        public static Customers SelectedElementCustomersStatic
        {
            get
            {
                if (_isSelectedElementCustomers)
                {
                    return _selectedElementCustomers;
                }
                return null;
            }
        }
        public Customers SelectedElementCustomers
        {
            set
            {
                _selectedElementCustomers = value;
                _isSelectedElementCustomers = true;
                OnPropertyChanged("SelectedElementCustomers");
            }
            get { return _selectedElementCustomers; }
        }
        public List<Products> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }
        private List<Customers> customers;
        public List<Customers> Customers
        {
            get
            {
                return customers;
            }
            set
            {

                customers = value;
                OnPropertyChanged("Customers");
            }
        }
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string OrderDeteils
        {
            get
            {
                if (OrdersViewModel.IsChanged && OrdersViewModel._ordersSelected != null)
                {
                    return _deteilsOrder = OrdersViewModel._ordersSelected.order_dateils;

                }
                else
                {
                    return _deteilsOrder;
                }
            }
            set
            {
                if (value.Length < _countCharInDetails)
                {
                    _deteilsOrder = value;
                }
                base.OnPropertyChanged("OrderDeteils");
            }
        }

        public string CountProduct
        {
            get
            {
                if (OrdersViewModel.IsChanged && OrdersViewModel._ordersSelected != null)
                {
                    return _countProduct = (OrdersViewModel._ordersSelected.order_prodCount).ToString();

                }
                else
                {
                    return _countProduct;
                }
            }
            set
            {
                int IntValue;
                bool checkIntValue = int.TryParse(value, out IntValue);
                if (checkIntValue || _countProduct.Length == 1)
                {
                    _countProduct = value;
                }
                // _countProduct = value; 
                base.OnPropertyChanged("CountProduct");
            }
        }
        public string OrderStatus
        {
            get
            {
                if (OrdersViewModel.IsChanged && OrdersViewModel._ordersSelected != null)
                {
                    return _orderStatus = OrdersViewModel._ordersSelected.order_status;

                }
                else
                {
                    return _orderStatus;
                }
            }
            set
            {
                _orderStatus = value;
                _isOrderStatus = true;
                base.OnPropertyChanged("OrderStatus");
            }
        }
        public DateTime DateOrder
        {
            get
            {
                if (OrdersViewModel.IsChanged && OrdersViewModel._ordersSelected != null)
                {
                    return _dateOrder = OrdersViewModel._ordersSelected.order_date;
                }
                else
                {
                    return _dateOrder;
                }
            }
            set
            {
                _dateOrder = value;
                //  _isDateOrder = true;
                base.OnPropertyChanged("DateOrder");
            }
        }
        #endregion

        #region --Patterns--
        private const string patternCountProduct = @"\D";
        private const string patternDateOrder = @"(\d{1,2}\.\d{1,2}\.\d{4})";
        #endregion

        #region --Other Filds--
        public string error;
        private Orders _orders;
        private static AddOrder _addOrders;
        private static OrdersViewModel _orderViewModel;
        private List<Products> products;
        Regex regexDateOrder;
        Regex regexCountProduct;
        private int _ordersId;
        #endregion

        #region --indexer_VALIDATION_Column_Name--
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "OrderDeteils":
                        {
                            if ((_deteilsOrder == null) || (_deteilsOrder == ""))
                            {
                                _isDeteilsOrder = false;
                                return error = "Not valid";
                            }
                            _isDeteilsOrder = true;
                            break;
                        }
                    case "CountProduct":
                        {
                            if (regexCountProduct.IsMatch(_countProduct) || (_countProduct == null) || (_countProduct == ""))
                            {
                                _isCountProduct = false;
                                return error = "Not valid";
                            }
                            _isCountProduct = true;
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
        public static void GetAddCustomers(AddOrder _addViewModel)
        {
            _addOrders = _addViewModel;

        }
        #endregion

        #region -- Public Constructor--
        public AddOrdersViewModel()
        {
            OkAdd = new Command(arg => Add());
            CenselAdd = new Command(arg => Censel());
            _orders = new Orders();
            _orderViewModel = OrdersViewModel.ReturnObjViewModel();
            regexDateOrder = new Regex(patternDateOrder);
            regexCountProduct = new Regex(patternCountProduct);
            Products = new List<Products>(Model.Products.ReturnAllProductsAsList());
            Customers = new List<Customers>(Model.Customers.GetAll());
            if (!(OrdersViewModel.IsChanged))
            {
                SelectedElementProducts = Products[0];
            }
        }
        #endregion

        #region --Private Method--
        private int SearchAndReturnTheSelectedIndexEmployeesStatus(Orders orders)
        {
            switch (orders.order_status)
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
            if (_isSelectedElementCustomers && _isSelectedElementProducts && _isCountProduct && _isOrderStatus && _isDeteilsOrder)
            {
                _orders.order_dateils = OrderDeteils;
                _orders.order_date = DateOrder;
                _orders.order_status = _addOrders.OrderStatus.Text;
                _orders.order_prodCount = int.Parse(CountProduct);
                _orders.Add(_orders);
                OrdersViewModel.IsChanged = false;
            }
            else
            {
                System.Windows.MessageBox.Show("You entered not valid values");
                return;
            }
            _orderViewModel.Display();
            _addOrders.Close();
        }
        private void Censel()
        {
            _addOrders.Close();
            OrdersViewModel.IsChanged = false;
        }
        #endregion
    }
}
