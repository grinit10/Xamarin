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
    }
}