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
    //private void OnAlphabetSelected(object sender, SelectionChangedEventArgs e)
    //{
    //    try
    //    {
    //        if (e.CurrentSelection.Count > 0)
    //        {
    //            string selectedAlphabet = e.CurrentSelection[0].ToString();
    //            Debug.WriteLine($"Selected Alphabet: {selectedAlphabet}");

    //            if (!string.IsNullOrEmpty(selectedAlphabet))
    //            {
    //                var viewModel = BindingContext as ContactsViewModel;
    //                if (viewModel != null)
    //                {
    //                    var targetGroup = viewModel.ContactsGrouped
    //                        .FirstOrDefault(g => g.Initial == selectedAlphabet);

    //                    if (targetGroup != null)
    //                    {
    //                        // Scroll to the target group
    //                        ContactsListView.ScrollTo(targetGroup[0], ScrollToPosition.Start, true);
    //                        Debug.WriteLine($"Scrolling to group: {selectedAlphabet}");
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Error in OnAlphabetSelected: {ex.Message}");
    //    }
    //}


    private void OnInitialSelected(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            if (e.CurrentSelection.Count > 0)
            {
                string selectedInitial = e.CurrentSelection[0].ToString();
                Debug.WriteLine($"Selected Initial: {selectedInitial}");

                if (!string.IsNullOrEmpty(selectedInitial))
                {
                    var viewModel = BindingContext as ContactsViewModel;
                    if (viewModel != null)
                    {
                        var targetGroup = viewModel.ContactsGrouped
                            .FirstOrDefault(g => g.Initial == selectedInitial);

                        if (targetGroup != null)
                        {
                            // Scroll to the target group
                            ContactsListView.ScrollTo(targetGroup[0], ScrollToPosition.Start, true);
                            Debug.WriteLine($"Scrolling to group: {selectedInitial}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in OnInitialSelected: {ex.Message}");
        }
    }
}
