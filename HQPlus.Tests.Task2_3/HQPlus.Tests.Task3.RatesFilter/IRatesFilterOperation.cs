using HQPlus.Tests.Task2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HQPlus.Tests.Task3.RatesFilter
{
    public interface IRatesFilter
    {
        /// <summary>
        /// Filter the Hotel Rates by IdHotel
        /// </summary>
        /// <param name="hotelId">integer representing the hotel id to get all rates</param>
        /// <returns>HotelRates</returns>
        IEnumerable<HotelRates> Filter(int hotelId);

        /// <summary>
        /// Filter the Hotel Rates by IdHotel, ArrivalDate and operator to be applied
        /// to arrival date parameter
        /// </summary>
        /// <param name="hotelId">integer representing the hotel id to get rates to filter</param>
        /// <param name="arrivalDate">date to be filtered with filterOperator parameter</param>
        /// <param name="filterOperator">Possible values: [=, <, >, <=, >=] </param>
        /// <returns></returns>
        IEnumerable<HotelRates> Filter(int hotelId, DateTime arrivalDate, string filterOperator);
    }
}
