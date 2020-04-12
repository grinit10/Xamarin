using System.ComponentModel;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Demo_1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private int _count = 0;
        private IList<string> _quotes = new List<string> { "Quote 1", "Quote 2", "Quote 3" };
        public MainPage()
        {
            InitializeComponent();
            slider.Value = 0.5;
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            _count++;
            label.Text = _quotes[_count % 3];
        }

        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.FontSize = e.NewValue * 100;
        }
    }
}
