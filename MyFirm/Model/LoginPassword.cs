using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MyFirm.Model
{
    class LoginPassword : NotifyPropertyChang
    {
        #region Constructor
        public LoginPassword()
        {
            this.Login = "";
            this.PassWord = "";
            this.PropertyChanged += ErrorPassWord;
            this.PropertyChanged += ErrorLogin;
        }
        #endregion

        #region Property
        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
                base.OnPropertyChanged("Login");
            }
        }
        public string PassWord
        {
            get
            {
                return _passWord;
            }
            set
            {
                _passWord = value;
                base.OnPropertyChanged("PassWord");
            }
        }
        public string MessageErorPassWord
        {
            get { return _messageErorPassWord; }
            set
            {
                _messageErorPassWord = value;
                base.OnPropertyChanged("MessageErorPassWord");
            }
        }
        public string MessageErorLogin
        {
            get { return _messageErorLogin; }
            set
            {
                _messageErorLogin = value;
                base.OnPropertyChanged("MessageErorLogin");
            }
        }
        #endregion

        #region Field
        private string _login;
        private string _passWord;
        private string _messageErorPassWord;
        private string _messageErorLogin;
        Regex regex;
        public bool isNotCharSymbolPassWord;
        public bool isNotCharSymbolLogin;
        #endregion

        #region Method
        private void ErrorLogin(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Login")
            {
                string pattern = @"\s|\W";
                regex = new Regex(pattern);
                isNotCharSymbolLogin = regex.IsMatch(_login);
                if (isNotCharSymbolLogin)
                {
                    MessageErorLogin = "Please enter corect value (a-z,A-Z,0-9)";
                }
                else
                {
                    MessageErorLogin = "";
                }
            }
        }
        private void ErrorPassWord(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PassWord")
            {
                string pattern = @"\s|\W";
                regex = new Regex(pattern);
                isNotCharSymbolPassWord = regex.IsMatch(_passWord);
                if (isNotCharSymbolPassWord)
                {
                    MessageErorPassWord = "Please enter corect value (a-z,A-Z,0-9)";
                }
                else
                {
                    MessageErorPassWord = "";
                }
            }
        }
        #endregion
    }
}
