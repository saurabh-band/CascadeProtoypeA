using CascadeProtoypeA.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using CascadeProtoypeA.Models;

namespace CascadeProtoypeA.Views;

public partial class Contacts : ContentPage
{
	public Contacts()
	{
		InitializeComponent();
	}
    private void OnAlphabetSelected(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            if (e.CurrentSelection.Count > 0)
            {
                string selectedAlphabet = e.CurrentSelection[0].ToString();
                Debug.WriteLine($"Selected Alphabet: {selectedAlphabet}");

                if (!string.IsNullOrEmpty(selectedAlphabet))
                {
                    // Find the first contact group that matches the selected alphabet
                    var targetGroup = ((ContactsViewModel)BindingContext).ContactsGrouped
                        .FirstOrDefault(g => g.Initial == selectedAlphabet);

                    if (targetGroup != null)
                    {
                        // Scroll to the selected group
                        ContactsListView.ScrollTo(targetGroup, ScrollToPosition.Start, true);
                        Debug.WriteLine($"Scrolling to group: {selectedAlphabet}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in OnAlphabetSelected: {ex.Message}");
        }
    }
}
