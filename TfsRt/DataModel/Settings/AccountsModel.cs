using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsRt.DataModel.Settings
{
    public class AccountsModel
    {
        public ICollection<Account> Accounts { get; set; }
    }
}
