using ReactiveUI;

namespace TfsRt.DataModel.Settings
{
    public class AccountsModel : ReactiveObject
    {
        public ReactiveCollection<Account> Accounts { get; set; }

        public static IReactiveCollection<Account> GetAccounts() 
        {
            return null;
        }
    }
}
