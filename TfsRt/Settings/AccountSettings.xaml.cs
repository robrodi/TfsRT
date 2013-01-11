using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TfsRt.DataModel.Settings;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TfsRt.Settings
{
    public static class SettingsPage
    {
        internal static void GoBack(UserControl control)
        {
            if (control == null) throw new ArgumentNullException("control");

            if (control.Parent.GetType() == typeof(Popup))
            {
                ((Popup)control.Parent).IsOpen = false;
            }

            SettingsPane.Show();
        }
    }
    public sealed partial class AccountSettings : UserControl
    {
        public AccountsModel Model { get; set; }

        public AccountSettings()
        {
            Model = new AccountsModel // TODO: Load from storage
            {
                Accounts = new []{
                    new Account { Path = new Uri("http://hello.world"), UserName = "Rob", Password = "RODI" }
                }
            };
            this.DataContext = Model;
            this.InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            SettingsPage.GoBack(this);
        }

        private void AddAccountClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(this.AccountsList.Items.Count);
        }
    }
}
