using LocationDemo.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Geolocation;

[assembly: Xamarin.Forms.Dependency(typeof(GetCurrentLocationIOS))]

namespace LocationDemo.iOS
{
    public class GetCurrentLocationIOS : IGetCurrentLocation
    {
        public async Task<LocationCoordinates> GetCurrentLocation()
        {
            EventHandler<PositionEventArgs> handler = null;
            var result = new LocationCoordinates();
            TaskCompletionSource<LocationCoordinates> tcs = new TaskCompletionSource<LocationCoordinates>();
            Geolocator locator = new Geolocator { DesiredAccuracy = 50 };

            try
            {
                if (!locator.IsListening)
                {
                    locator.StartListening(10, 100);    
                }                

                handler = (object sender, PositionEventArgs e) =>
                {
                    result.Status = e.Position.Timestamp;
                    result.Latitude = e.Position.Latitude;
                    result.Longitude = e.Position.Longitude;
                    locator.PositionChanged -= handler;
                    tcs.SetResult(result);
                };
                locator.PositionChanged += handler;                
                
                await locator.GetPositionAsync(timeout: 10000).ContinueWith(
                    t =>
                    {
                    });               
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException.GetType().ToString() == "Xamarin.Geolocation.GeolocationException")
                {
                    tcs.SetException(ex);
                }
            }

            return tcs.Task.Result;
        }
    }
}
