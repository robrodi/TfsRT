using ReactiveUI;
using System;
using System.Diagnostics;
using TfsRt.DataModel.Settings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace TfsRt.Settings
{
    public sealed partial class AccountSettings : UserControl
    {
        public AccountsModel Model { get; set; }

        public AccountSettings()
        {
            Model = new AccountsModel // TODO: Load from storage
            {
                Accounts = new ReactiveCollection<Account>{
                    new Account { Path = new Uri("http://hello.world"), UserName = "Rob", Password = "RODI" }
                }
            };
            this.DataContext = Model;
            this.InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Settings.SettingsWindow.GoBack(this);
        }

        private void AddAccountClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(this.AccountsList.Items.Count);
        }
    }
}
