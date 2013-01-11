using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsRt.DataModel.Settings
{
    public class Account : INotifyPropertyChanged
    {
        private Uri _path;
        private string _userName, _password;

        public Uri Path { 
            get { return _path; }
            set { 
                _path = value;
                PropertyChangedHelper("Path");
            } 
        }

        public string UserName { 
            get { return _userName;} 
            set { 
                _userName = value;
                PropertyChangedHelper("UserName");
            }
        }
        
        public string Password { 
            get { return _password;} 
            set { 
                _password = value;
                PropertyChangedHelper("Password");
            }
        }

        private void PropertyChangedHelper(string propertyName) 
        {
            if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentOutOfRangeException("propertyName");
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class AccountsModel
    {
         
        public ICollection<Account> Accounts { get; set; }
    }
}
