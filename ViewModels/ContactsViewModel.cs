using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadeProtoypeA.Models;
using Contact = CascadeProtoypeA.Models.Contactss;


namespace CascadeProtoypeA.ViewModels
{
    public class ContactsViewModel
    {
        private string searchQuery;
        public ObservableCollection<ContactGroup> ContactsGrouped { get; set; }
        public ObservableCollection<string> AvailableInitials { get; set; }
        private ObservableCollection<Contact> allContacts;

        public string SearchQuery
        {
            get => searchQuery;
            set
            {
                searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                FilterAndGroupContacts();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ContactsViewModel()
        {
            // Initialize contacts
            allContacts = new ObservableCollection<Contact>
        {
            new Contact { Name = "Genevieve Adams", Email = "genevieve.adams@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "Michael Alderton", Email = "michael.alderton@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "Patricia Atkinson", Email = "patricia.atkinson@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "Christopher Aston", Email = "christopher.aston@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "AAAAA BBBB", Email = "a.b@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "SSSSS ABCD", Email = "s.a@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "ABCD JKLM", Email = "a.j@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "JKLM Poiu", Email = "j.p@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "ZZZZZ RRRRR", Email = "z.r@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" },
            new Contact { Name = "YYYYY ZZZZZ", Email = "y.z@company.com", Phone = "0161 637 3758 (2479)", ImageUrl = "person.png" }
        };

            ContactsGrouped = new ObservableCollection<ContactGroup>();
            AvailableInitials = new ObservableCollection<string>();

            FilterAndGroupContacts();
        }

        private void FilterAndGroupContacts()
        {
            try
            {
                Debug.WriteLine("Filtering and grouping contacts...");
                Debug.WriteLine($"Search Query: {SearchQuery}");

                // Filter contacts based on search query
                var filteredContacts = string.IsNullOrWhiteSpace(SearchQuery)
                    ? allContacts
                    : new ObservableCollection<Contact>(allContacts.Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.ToLower().Contains(SearchQuery.ToLower())));

                Debug.WriteLine($"Filtered contacts count: {filteredContacts.Count}");

                foreach (var contact in filteredContacts)
                {
                    Debug.WriteLine($"Contact Name: {contact.Name}");
                }

                // Group by the first letter of the contact's name and sort
                var groupedContacts = filteredContacts
                    .Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.Length > 0) // Ensure Name is not empty
                    .GroupBy(c => c.Name[0].ToString().ToUpper())
                    .OrderBy(g => g.Key)
                    .Select(g =>
                    {
                        var sortedGroup = new ContactGroup(g.Key);
                        foreach (var contact in g.OrderBy(c => c.Name))
                        {
                            Debug.WriteLine($"Adding contact {contact.Name} to group {g.Key}");
                            sortedGroup.Add(contact);
                        }
                        return sortedGroup;
                    });

                Debug.WriteLine($"Grouped contacts count: {groupedContacts.Count()}");

                // Clear and repopulate ContactsGrouped
                ContactsGrouped.Clear();
                foreach (var group in groupedContacts)
                {
                    Debug.WriteLine($"Adding group {group.Initial} with {group.Count} contacts");
                    ContactsGrouped.Add(group);
                }

                // Update AvailableInitials based on grouped contacts
                AvailableInitials.Clear();
                foreach (var group in groupedContacts)
                {
                    AvailableInitials.Add(group.Initial);
                }

                OnPropertyChanged(nameof(ContactsGrouped));
                OnPropertyChanged(nameof(AvailableInitials));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Debug.WriteLine($"Error encountered: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unhandled error: {ex.Message}");
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ContactGroup : ObservableCollection<Contact>
    {
        public string Initial { get; private set; }

        public ContactGroup(string initial)
        {
            Initial = initial;
        }
    }
}