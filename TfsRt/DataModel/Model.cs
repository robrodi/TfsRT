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
    public interface IDisplayBits
    {
        string Id { get; set; }
        string Title { get; set; }
        string ImagePath { get; set; }
    }
    public class Item : ReactiveObject, IDisplayBits
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
    }

    public class Group<T> : Item
    {
        public Group()
        {
            Items = new ReactiveCollection<T>();
        }
        public ReactiveCollection<T> Items { get; set; }
    }

    public class Model
    {
        public Model()
        {
            AllGroups = CreateTfsTypeList();
        }

        public AccountsModel Accounts { get; set; }
        
        internal SummaryModel Summary { get; set; }
        public ReactiveCollection<Item> AllGroups { get; set; }

        private static ReactiveCollection<Item> CreateTfsTypeList()
        {
            return new ReactiveCollection<Item> 
            { 
                new Group<Item> { Id = Guid.NewGuid().ToString(), Title = "Work Items" },
                new Group<Item> { Id = Guid.NewGuid().ToString(), Title = "Builds" },
                new Group<Item> { Id = Guid.NewGuid().ToString(), Title = "Reports" },
            };
        }
    }
}
