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
        public void Load()
        {
            Load(ApplicationData.Current.RoamingSettings);
        }

        // TODO: Make this reflect over MODEL and pull values accordingly.
        public void Save()
        {
            var settings = ApplicationData.Current.RoamingSettings;
            settings.Values["Accounts"] = Model.Accounts.Serialize();
        }

        private void Load(ApplicationDataContainer roamingSettings)
        {
            if (roamingSettings == null) throw new ArgumentNullException("roamingSettings");
            LoadAccountInfo(roamingSettings);
        }

        private void LoadAccountInfo(ApplicationDataContainer roamingSettings)
        {
            Model.Accounts = Model.Accounts ?? new AccountsModel();

            var accounts = roamingSettings.Values["Accounts"] as string;

            using (var sr = new MemoryStream(Encoding.UTF8.GetBytes(accounts)))
            {
                var accountsFromSetting = new DataContractJsonSerializer(typeof(Account[])).ReadObject(sr) as Account[];
                Model.Accounts.Accounts.AddRange(accountsFromSetting);
            }
        }

        void DataChangeHandler(ApplicationData appData, object o)
        {
        }
    }
}
