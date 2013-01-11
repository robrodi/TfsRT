using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsRt.DataModel.Settings
{
    class Account
    {
    }
    class AccountsModel
    {
        public IObservable<Account> Accounts { get; set; }
    }
}
