using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data.SqlClient;

namespace StartupInvest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void login_button_click(object sender,EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected == true)
            {
                string login = Login.Text;
                string password = Password.Text;
                if (String.IsNullOrWhiteSpace(login))
                {
                   
                    DisplayAlert("Ошибка авторизации", "Введите логин!", "ОK");
                }
                else if(String.IsNullOrWhiteSpace(password))
                {
                    DisplayAlert("Ошибка авторизации", "Введите пароль!", "ОK");
                }
                else
                {
                    string connectionstring = "Server=tcp:startupinvest.database.windows.net,1433;Initial Catalog=mainDB;Persist Security Info=False;User ID=prusov;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
                    using (var conn = new sqlcone(connectionstring))
                    {

                    }
                        Login123.Text = login + password;
                }
                
            }
            else
            {
                DisplayAlert("Подключение к интернету отсутсвует", "Проверьте соединение и повторите попытку", "ОK");
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckConnection();
        }
        // обработка изменения состояния подключения
        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            CheckConnection();
        }
        // получаем состояние подключения
        private void CheckConnection()
        {
            if (CrossConnectivity.Current != null &&
                CrossConnectivity.Current.ConnectionTypes != null &&
                CrossConnectivity.Current.IsConnected == true)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
            }
        }
    }
}
