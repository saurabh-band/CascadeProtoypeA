using Microsoft.Maui.Controls;

namespace CascadeProtoypeA.Views;

public partial class LOGO : ContentPage
{
    string clickTotal;

    public LOGO()
	{
		InitializeComponent();
        BindingContext=this;
    }
    void OnImageButtonClicked(object sender, EventArgs e)
    {
        int click = 0;
        click += 1;
        clickTotal = click.ToString();
    }
}