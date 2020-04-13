using Plugin.Geolocator;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridPage : ContentPage
    {
        SensorSpeed speed = SensorSpeed.Default; 
        public GridPage()
        {
            InitializeComponent();
            CrossGeolocator.Current.DesiredAccuracy = 0.05;
            CrossGeolocator.Current.PositionChanged += Accelerometer_ReadingChanged;
            CrossGeolocator.Current.StartListeningAsync(new TimeSpan(20000000), 0.05);
        }

        void Accelerometer_ReadingChanged(object sender, EventArgs e)
        {
            var data = e;
            setLocation();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            setLocation();
        }

        private async Task setLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                //var location = await Geolocation.GetLocationAsync(request);
                var location = await CrossGeolocator.Current.GetPositionAsync();
                if (location != null)
                {
                    Gps.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}, Speed: {location.Speed}";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}