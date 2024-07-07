using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeProtoypeA.Models
{
    public class ContactGroup : ObservableCollection<Contact>
    {
        public string Initial { get; private set; }

        public ContactGroup(string initial)
        {
            Initial = initial;
        }
    }
}
