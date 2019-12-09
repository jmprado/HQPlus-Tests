using System;

namespace HQPlus.Tests.Task3.Api.Model
{
    public class FilterModel
    {

        /// <summary>
        /// HotelId
        /// </summary>
        public int HotelId { get; set; }

        /// <summary>
        /// DateTime to filter arrival date
        /// </summary>
        public DateTime ArrivalDate { get; set; }
        
        /// <summary>
        /// Filter operator with default value "="
        /// </summary>
        public string Operator { get; set; } = "=";
    }
}
