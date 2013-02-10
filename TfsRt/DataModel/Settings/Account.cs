using ReactiveUI;
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
        public Uri Path { get; set;}
        [DataMember]
        public string UserName{ get; set;}
        [DataMember]
        public string Password { get; set; }
    }
}
