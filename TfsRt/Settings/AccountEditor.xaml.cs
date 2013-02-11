using ReactiveUI;
using ReactiveUI.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TfsRt.DataModel.Settings;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AccountEditor : UserControl, IViewFor<Account>
    {
        public AccountEditor() : this(new Account()) { }
        public AccountEditor(Account account)
        {
            ViewModel = account;
            this.InitializeComponent();
            this.Bind(ViewModel, x => x.UserName);
            this.Bind(ViewModel, x => x.Password);
            this.Bind(ViewModel, x => x.Path);
            this.BindCommand(ViewModel, x => x.Ok);
        }

        public Account ViewModel
        {
            get { return (Account)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(Account), typeof(AccountEditor), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (Account)value; }
        }

    }
}
