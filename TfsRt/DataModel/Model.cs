using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsRt.DataModel.Settings;

namespace TfsRt.DataModel
{
    public class Model
    {
        public Model()
        {
            AllGroups = new ReactiveCollection<object>();
        }

        public AccountsModel Accounts { get; private set; }
        

        //private ObservableCollection<SampleDataGroup> _types = CreateTfsTypeList();

        //internal SummaryModel Summary { get; private set; }
        public ReactiveCollection<object> AllGroups { get; set;}


        //private static ObservableCollection<SampleDataGroup> CreateTfsTypeList()
        //{
        // return    new ObservableCollection<SampleDataGroup>(new[] { new SampleDataGroup(0.ToString(), "WorkItems", "Tfs Work Items", string.Empty, "Work Items" )});
        //}


        //internal static SampleDataGroup GetGroup(string p)
        //{
        //    return new SampleDataGroup(p, "Hello", "World", string.Empty, "stuffs");
        //}
    }
}
