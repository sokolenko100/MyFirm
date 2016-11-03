using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirm.View;
using MyFirm.ViewModelComponent;
using System.Text.RegularExpressions;
using System.ComponentModel;
using MyFirm.Model;
using System.Windows.Input;

namespace MyFirm.AddViewModel
{
    class AddProductsViewModel : NotifyPropertyChang, IDataErrorInfo
  {

        #region --Private_filds_for_column_name--
        private string _name="";
        private string _count = "";
        private string _oilness = "";
        private string _density = "";
        private string _bit = "";
        private string _kernelImpurety = "";
        private string _protein = "";
        private string _price = "";
        private string _dump = "";
        private string _litter = "";

        private const decimal _countMoney = decimal.MaxValue;
        private const int _countCharsNameAndDump = 10;
        private const int _countCharsAnotherPosition = 12;

        private bool _isName;
        private bool _isCount;
        private bool _isOilness;
        private bool _isDensity;
        private bool _isBit;
        private bool _isKernelImpurety;
        private bool _isProtein;
        private bool _isPrice;
        private bool _isDump;
        private bool _isLitter;
        #endregion

        #region --Property--
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string Dump
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                    return _dump = ProductsViewModel._productsSelected.prod_dump;

                }
                else
                {
                          return _dump;
                }
            }
            set
            {
                if (value.Length < _countCharsNameAndDump)
                {
                    _dump = value;
                }
                base.OnPropertyChanged("Dump");
            }
        }
        public string Litter
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                     return _litter = ProductsViewModel._productsSelected.prod_litter;

                }
                else
                {
                    return _litter;
                }
            }
            set
            {
                if (value.Length < _countCharsAnotherPosition)
                {
                    _litter = value;
                }
                base.OnPropertyChanged("Name");
            }
        }
        public string Count
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                    return _count =(ProductsViewModel._productsSelected.prod_Qty).ToString();

                }
                else
                {
                    return _count;
                }
            }
            set
            {
                if (value.Length < _countCharsAnotherPosition)
                {
                    _count = value;
                }
                base.OnPropertyChanged("Count");
            }
        }
        public string Name
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                   return _name = ProductsViewModel._productsSelected.prod_name;

                }
                else
                {
                    return _name;
                }
            }
            set
            {
                if (value.Length < _countCharsNameAndDump)
                {
                    _name = value;
                }
                base.OnPropertyChanged("Name");
            }
        }
        public string Oilness
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                  return _oilness = ProductsViewModel._productsSelected.prod_oilness;

                }
                else
                {
                    return _oilness;
                }
            }
            set
            {
                if (value.Length < _countCharsAnotherPosition)
                {
                    _oilness = value;
                }
                base.OnPropertyChanged("Oilness");
            }
        }
        public string Density
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                 return _density = ProductsViewModel._productsSelected.prod_density;

                }
                else
                {
                    return _density;
                }
            }
            set
            {
                if (value.Length < _countCharsAnotherPosition)
                {
                    _density = value;
                }
                base.OnPropertyChanged("Density");
            }
        }
        public string Bit
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                 return _bit= ProductsViewModel._productsSelected.prod_bit;

                }
                else
                {
                    return _bit;
                }
            }
            set
            {
                if (value.Length < _countCharsAnotherPosition)
                {
                    _bit = value;
                }
                base.OnPropertyChanged("Bit");
            }
        }
        public string KernelImpurety
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                 return _kernelImpurety = ProductsViewModel._productsSelected.prod_kernelImpurety;
                }
                else
                {
                    return _kernelImpurety;
                }
            }
            set
            {
                if (value.Length < _countCharsAnotherPosition)
                {
                    _kernelImpurety = value;
                }
                base.OnPropertyChanged("KernelImpurety");
            }
        }
        public string Protein
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                    return _protein = ProductsViewModel._productsSelected.prod_protein;
                }
                else
                {
                    return _protein;
                }
            }
            set
            {
                if (value.Length < _countCharsAnotherPosition)
                {
                    _protein = value;
                }
                base.OnPropertyChanged("Protein");
            }
        }
        public string Price
        {
            get
            {
                if (ProductsViewModel.IsChanged && ProductsViewModel._productsSelected != null)
                {
                  return _price = (ProductsViewModel._productsSelected.prod_Price).ToString();
                }
                else
                {
                    return _price;
                } 
            }
            set
            {
                if (value.Length < _countMoney)
                {
                    _price = value;
                }
                base.OnPropertyChanged("Price");
            }
        }
        #endregion

        #region --Patterns--
        private const string patternNumbers = @"\d";
        private const string patternNumbersDontChars = @"\D";
        private const string patternString = @"\.";
        #endregion

        #region --Other Filds--
          public string error;
          private Products _products;
          private static ProductWindows _addProduct;
          private static ProductsViewModel _productViewModel;
          Regex regexNumb;
          Regex regexNumbDontChars;
          Regex regexString;
          #endregion

        #region --indexer VALIDATION _Column_Name--
          public string this[string columnName]
          {
              get
              {
                  switch (columnName)
                  {
                      case "Count":
                          {
                              if (!(regexNumb.IsMatch(_count) & !(regexNumbDontChars.IsMatch(_count))))
                              {
                                  _isCount = false;
                                  return error = "Not valid";
                              }
                              _isCount = true;
                              break;
                          }

                      case "Dump":
                          {
                              if (!(regexNumb.IsMatch(_dump) & !(regexNumbDontChars.IsMatch(_dump))))
                              {
                                  _isDump = false;
                                  return error = "Not valid";
                              }
                              _isDump = true;
                              break;
                          }
                      case "Litter":
                          {
                              if (!(regexNumb.IsMatch(_litter) & !(regexNumbDontChars.IsMatch(_litter))))
                              {
                                  _isLitter = false;
                                  return error = "Not valid";
                              }
                              _isLitter = true;
                              break;
                          }
                      case "KernelImpurety":
                          {
                              if (!(regexNumb.IsMatch(_kernelImpurety) & !(regexNumbDontChars.IsMatch(_kernelImpurety))))
                              {
                                  _isKernelImpurety = false;
                                  return error = "Not valid";
                              }
                              _isKernelImpurety = true;
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
                      case "Oilness":
                          {
                                  if (!(regexNumb.IsMatch(_oilness) & !(regexNumbDontChars.IsMatch(_oilness))))
                              {
                                  _isOilness = false;
                                  return error = "Not valid";
                              }
                              _isOilness = true;
                              break;
                          }
                      case "Density":
                          {
                              if (!(regexNumb.IsMatch(_density) & !(regexNumbDontChars.IsMatch(_density))))
                              {
                                  _isDensity = false;
                                  return error = "Not valid";
                              }
                              _isDensity = true;
                              break;
                          }
                      case "Bit":
                          {
                              if (!(regexNumb.IsMatch(_bit) & !(regexNumbDontChars.IsMatch(_bit))))
                              {
                                  _isBit = false;
                                  return error = "Not valid";
                              }
                              _isBit = true;
                              break;
                          }
                      case "Protein":
                          {
                              if (!(regexNumb.IsMatch(_protein) & !(regexNumbDontChars.IsMatch(_protein))))
                              {
                                  _isProtein = false;
                                  return error = "Not valid";
                              }
                              _isProtein = true;
                              break;
                          }
                      case "Price":
                          {
                              if (!regexNumb.IsMatch(_price) & !(regexNumbDontChars.IsMatch(_price)))
                              {
                                  _isPrice = false;
                                  return error = "Not valid";
                              }
                              _isPrice = true;
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
          public static void GetAdd(ProductWindows _addViewModel)
          {
              _addProduct = _addViewModel;

          }
          #endregion

        #region -- Public Constructor--
          public AddProductsViewModel()
        {
            OkAdd = new Command(arg => Add());
            CenselAdd = new Command(arg => Censel());
            _products = new Products();
            _productViewModel = ProductsViewModel.ReturnObjViewModel();
            regexNumb = new Regex(patternNumbers);
            regexString = new Regex(patternString);
            regexNumbDontChars = new Regex(patternNumbersDontChars);
        }
        #endregion

        #region --Private Method--
         private void Add()
        {
            if (_isCount && _isName && _isOilness && _isDensity && _isBit && _isKernelImpurety && _isProtein && _isPrice && _isDump && _isLitter)
            {
                _products.prod_name = Name;
                _products.prod_oilness = Oilness;
                _products.prod_dump = Dump;
                _products.prod_litter = Litter;
                _products.prod_bit = Bit;
                _products.prod_kernelImpurety = KernelImpurety;
                _products.prod_density = Density;
                _products.prod_Qty = int.Parse(Count);
                _products.prod_protein = Protein;
                _products.prod_Price = decimal.Parse(Price);
                _products.Add(_products);
                ProductsViewModel.IsChanged = false;
            }
            else
            {
                System.Windows.MessageBox.Show("You entered not valid values");
                return;
            }
            _productViewModel.Display();
            
            _addProduct.Close();
        }
        private void Censel()
        {
            _addProduct.Close();
            ProductsViewModel.IsChanged = false;
        }
      #endregion
}
}
