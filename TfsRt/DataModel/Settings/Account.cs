using ReactiveUI;
using ReactiveUI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TfsRt.DataModel.Settings
{
    [DataContract]
    public class Account : ReactiveObject
    {
        [DataMember]
        public string Path { get; set;}
        [DataMember]
        public string UserName{ get; set;}
        [DataMember]
        public string Password { get; set; }

        public ReactiveCommand Ok { get; protected set; }
        public Account()
        {
            Path = UserName = Password = string.Empty;
            var isValid = this.WhenAny(x => x.UserName, x => x.Password, x => x.Path,
                (u, p, s) =>
                {
                    return !string.IsNullOrWhiteSpace(u.Value) && !string.IsNullOrWhiteSpace(p.Value) && !string.IsNullOrWhiteSpace(s.Value);
                });
            Ok = new ReactiveCommand(isValid);
        }
    }
}
