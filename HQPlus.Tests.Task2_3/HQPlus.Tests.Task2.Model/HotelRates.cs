using System.Collections.Generic;

namespace HQPlus.Tests.Task2.Model
{
    /// <summary>
    /// Root class for reading hoterates.json file
    /// </summary>
    public class HotelRates
    {
        /// <summary>
        /// Hotel class
        /// </summary>
        public Hotel hotel { get; set; }

        /// <summary>
        /// Hotel rates
        /// </summary>
        public List<HotelRate> hotelRates { get; set; }
    }
}
