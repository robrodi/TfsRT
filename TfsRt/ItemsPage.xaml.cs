using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TfsRt.DataModel;
using Windows.UI.ApplicationSettings;
using TfsRt.Common;
using TfsRt.Settings;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace TfsRt
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class ItemsPage : TfsRt.Common.LayoutAwarePage
    {
        static readonly RoamingDataAdaptor adaptor = new RoamingDataAdaptor();
        readonly Model model;

        public static Model GetModel()
        {
            adaptor.Load();
            return adaptor.Model;
        }

        #region Constructors
        public ItemsPage() : this(GetModel()) {}
        public ItemsPage(Model model){
            this.model = model;
            this.InitializeComponent();
            SettingsPane.GetForCurrentView().CommandsRequested += ItemsPage_CommandsRequested;
        }
        #endregion

        void ItemsPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(SettingsWindow.Create("sample", "Accounts", new AccountSettings(model.Accounts)));
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            this.DefaultViewModel["Items"] = model.AllGroups;// sampleDataGroups;
        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var groupId = ((Item)e.ClickedItem).Id;
            //this.Frame.Navigate(typeof(SplitPage), groupId);
        }
    }
}
