using Android.App;
using Android.Content;
using SampleApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformDetails))]
namespace SampleApp.Droid
{
    public class PlatformDetails : IMyInterface
    {
        

        public PlatformDetails()
        {
        }
        public string GetPlatformName()
        {
            return "I am Android!";
        }

        public void PublishEvent()
        {
            Intent i = new Intent("MY_SPECIFIC_ACTION");
            i.PutExtra("key", "some value from intent");
            Android.App.Application.Context.SendBroadcast(i);
        }
    }
}