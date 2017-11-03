using System.Data.Entity.Spatial;
using TolgaTheWizard.Models;

namespace TolgaTheWizard.Extensions
{
    public static class LocationExtensions
    {
        /// <summary>
        /// Converts given location to DbGeography
        /// </summary>
        /// <param name="longitude">longitude</param>
        /// <param name="latitude">latitude</param>
        /// <returns></returns>
        public static DbGeography ToDbGeography(double longitude, double latitude)
        {
            return DbGeography.FromText($"POINT({longitude} {latitude})");
        }

        /// <summary>
        /// Converts given location to DbGeography
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public static DbGeography ToDbGeography(this Coordinate coordinate)
        {
            return DbGeography.FromText($"POINT({coordinate.Longitude} {coordinate.Latitude})");
        }
    }
}
