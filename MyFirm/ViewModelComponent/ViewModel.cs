using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;
using MyFirm.Model;
using MyFirm.View;
using System.Collections;

namespace MyFirm.ViewModelComponent
{
    partial class ViewModel
    {
        #region Command
        public ICommand CommandOK { get;private set; }
        public LoginPassword myLogin { get; set; }
        public ICommand CommandCencel { get; private set; }
        #endregion
        #region Property
        public static MainMenu MainMenuProperty
        {
            get
            {
                return main;
            }
            set
            {
                main = value;
            }
        }
        #endregion
        #region Field
        static   MainMenu main;
        #endregion
        #region Constructor
        public ViewModel()
        {
            myLogin = new LoginPassword();
            CommandOK = new Command(arg=>Ok());
            CommandCencel = new Command(arg => Censel());
        }
        #endregion
        #region Event
        public static event CloseLoginWindowsHandler closeLoginWindowsHandler;
        #endregion
        #region Delegate
        public delegate void CloseLoginWindowsHandler();
        #endregion
        #region Method

        public void Ok()
        {
            if ((myLogin.isNotCharSymbolLogin==false)&& (myLogin.isNotCharSymbolPassWord==false)&&(myLogin.PassWord!="")&&(myLogin.Login!=""))
            {
                this.OnMenu();
            }
        }
        private void OnMenu()
        {
            main = new MainMenu();
            main.Show();
            closeLoginWindowsHandler();
        }
        public void Censel()
        {          
            MessageBox.Show("Censel worked");
            closeLoginWindowsHandler();
        }

        #endregion
    }
}