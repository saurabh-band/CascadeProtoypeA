using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadeProtoypeA.Models;
using Contact = CascadeProtoypeA.Models.Contactss;


namespace CascadeProtoypeA.ViewModels
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private string searchQuery;
        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<Contact> FilteredContacts { get; set; }

        public string SearchQuery
        {
            get => searchQuery;
            set
            {
                searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                FilterContacts();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<Contact>
        {
            new Contact { Name = "Genevieve Adams", Email = "genevieve.adams@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "Michael Alderton", Email = "michael.alderton@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "Patricia Atkinson", Email = "patricia.atkinson@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "Christopher Aston", Email = "christopher.aston@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "Kevin Baker", Email = "kevin.brown@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" }
        };
            FilteredContacts = new ObservableCollection<Contact>(Contacts);
        }

        private void FilterContacts()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredContacts = new ObservableCollection<Contact>(Contacts);
            }
            else
            {
                FilteredContacts = new ObservableCollection<Contact>(
                    Contacts.Where(c => c.Name.ToLower().Contains(SearchQuery.ToLower()))
                );
            }
            OnPropertyChanged(nameof(FilteredContacts));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
