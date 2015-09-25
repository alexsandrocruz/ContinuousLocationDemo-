using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocationDemo
{
    public partial class FirstPage : ContentPage
    {

        ObservableCollection<LocationCoordinates> myLocations; 

        public FirstPage()
        {
            InitializeComponent();
            myLocations = new ObservableCollection<LocationCoordinates>();
            listGeolocations.ItemsSource = myLocations; 
        }

        public async void OnGetLocationClicked(object sender, EventArgs e)
        {
            // Start getting the location in Background
            var getLocationTask = DependencyService.Get<IGetCurrentLocation>().GetCurrentLocation();
            var currentLocation = await getLocationTask;

            if (getLocationTask.Status == TaskStatus.RanToCompletion)
            {
                var cords = new LocationCoordinates { Latitude = getLocationTask.Result.Latitude, Longitude = getLocationTask.Result.Longitude, Status = getLocationTask.Result.Status };

                myLocations.Add(cords); 
            }
            
        }
    }
}
