using ReactiveUI;
using ReactiveUI.Xaml;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TfsRt.DataModel.Settings
{
    public class AccountsModel : ReactiveObject
    {
        public AccountsModel()
        {
            Accounts = new ReactiveCollection<Account>();
        }
        public ReactiveCommand AddAccount { get; set; }
        public ReactiveCommand UpdateAccount { get; protected set; }
        public ReactiveCollection<Account> Accounts { get; set; }

        public static IReactiveCollection<Account> GetAccounts() 
        {
            return null;
        }

        public string Serialize()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new DataContractJsonSerializer(typeof(Account[])).WriteObject(ms, this.Accounts.ToArray());
                return Encoding.UTF8.GetString(ms.ToArray(),0, (int)ms.Length);
            }
        }
    }
}
