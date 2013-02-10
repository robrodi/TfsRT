using System;
using Windows.Storage;
using System.Linq;
using System.Runtime.Serialization.Json;
using TfsRt.DataModel.Settings;
using System.IO;
using System.Text;
namespace TfsRt.DataModel
{
    public class RoamingDataAdaptor
    {
        public RoamingDataAdaptor()
        {
            Model = new Model();
        }
        public Model Model { get; set; }
        public void UpdateModelWithRoamingData()
        {
            UpdateModelWithRoamingData(ApplicationData.Current.RoamingSettings);
        }

        // TODO: Make this reflect over MODEL and pull values accordingly.
        public void UpdateRoamingDataWithModel()
        {
            var settings = ApplicationData.Current.RoamingSettings;
            settings.Values["Accounts"] = Model.Accounts;
        }

        private void UpdateModelWithRoamingData(ApplicationDataContainer roamingSettings)
        {
            if (roamingSettings == null) throw new ArgumentNullException("roamingSettings");

            var accounts = roamingSettings.Values["Accounts"] as AccountsModel;
            Model.Accounts = accounts ?? new AccountsModel();
        }

        void DataChangeHandler(ApplicationData appData, object o)
        {
        }
    }
}
