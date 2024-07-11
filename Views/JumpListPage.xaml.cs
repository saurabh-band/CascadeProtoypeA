using CascadeProtoypeA.Models;
using CascadeProtoypeA.ViewModels;
using CommunityToolkit.Maui.Markup;
using System.Collections.ObjectModel;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace CascadeProtoypeA.Views;

public partial class JumpListPage : ContentPage
{
    private readonly JumpListViewModel _vm;

    public JumpListPage(JumpListViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}

	protected override async void OnAppearing()
	{
		await _vm.InitialSetup();

		CreateAlphabetList();

		base.OnAppearing();
    }

	private void CreateAlphabetList()
	{
        var collectionSeries = CollectionSeries.ItemsSource as ObservableCollection<GroupMyModel>;
        GridAlphabetList.RowDefinitions = Rows.Define(_vm.AlphabetList.Select(x => GridLength.Auto).ToArray());
        for (int i = 0; i < _vm.AlphabetList.Count; i++)
        {
            var label = new Label()
            {
                Text = _vm.AlphabetList[i],
                TextColor = Color.FromArgb("#09BFEF"),
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 12,
                FontFamily = "OpenSansSemibold",
                Padding = new Thickness(10, 5,0,0)
            }.Row(i).Column(0);

            var labelTapped = new TapGestureRecognizer() { Command = new Command<string>(AlphabetTapped), CommandParameter = _vm.AlphabetList[i].ToUpper() };

            label.GestureRecognizers.Add(labelTapped);

            GridAlphabetList.Children.Add(label);
        }
    }

    private void AlphabetTapped(string text)
    {
        try
        {
            var collectionSeries = CollectionSeries.ItemsSource as ObservableCollection<GroupMyModel>;
            foreach (var group in collectionSeries)
            {
                var item = group.FirstOrDefault(x => x.Name.Equals(text));
                if (item is not null)
                {
                    CollectionSeries.ScrollTo(item, null, ScrollToPosition.Start, true);
                    break;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}