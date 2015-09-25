using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationDemo
{
    public interface IGetCurrentLocation
    {
        Task<LocationCoordinates> GetCurrentLocation(); 
    }

    public class LocationCoordinates
    {
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public DateTimeOffset Status { get; set; }
    }
}
