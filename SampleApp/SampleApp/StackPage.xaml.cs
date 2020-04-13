using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    public class ContactMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StackPage : ContentPage
    {
        public StackPage()
        {
            InitializeComponent();
            GetContactMethods().ForEach(cm => contactMethods.Items.Add(cm.Name));
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            label.IsVisible = e.Value;
        }

        private void Entry_Completed(object sender, System.EventArgs e)
        {
            completedLabel.Text = "Completed";
        }

        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DisplayAlert("Slected type", GetContactMethods().First(cm => contactMethods.Items[contactMethods.SelectedIndex] == cm.Name).Name, "Ok");
        }

        private IList<ContactMethod> GetContactMethods()
        {
            return new List<ContactMethod>
            {
                new ContactMethod
                {
                    Id=1,
                    Name="SMS"
                },
                new ContactMethod
                {
                    Id=2,
                    Name="Email"
                }
            };
        }
    }
}