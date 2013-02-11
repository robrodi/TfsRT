using ReactiveUI;
using ReactiveUI.Xaml;
using System;
using System.Diagnostics;
using TfsRt.DataModel.Settings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace TfsRt.Settings
{
    public sealed partial class AccountSettings : UserControl, IViewFor<AccountsModel>
    {
        public AccountSettings() : this(
            new AccountsModel // TODO: Load from storage
            {
                Accounts = new ReactiveCollection<Account>{
                    new Account { Path = "http://hello.world", UserName = "Rob", Password = "RODI" }
                }
            }){}

        public AccountSettings(AccountsModel model)
        {
            this.DataContext = ViewModel = model;
            this.InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Settings.SettingsWindow.GoBack(this);
        }

        private void AddAccountClick(object sender, RoutedEventArgs e)
        {
        }

        public AccountsModel ViewModel { get; set;}

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (AccountsModel)value; }
        }
    }
}
