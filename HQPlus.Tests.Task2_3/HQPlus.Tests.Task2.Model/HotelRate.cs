using System;
using System.Collections.Generic;

namespace HQPlus.Tests.Task2.Model
{
    /// <summary>
    /// Individual room hotel rate
    /// </summary>
    public class HotelRate
    {
        /// <summary>
        /// Number of adults per room
        /// </summary>
        public int adults { get; set; }

        /// <summary>
        /// Length of stay (number of days)
        /// </summary>
        public int los { get; set; }

        /// <summary>
        /// Price class
        /// </summary>
        public Price price { get; set; }

        /// <summary>
        /// Description of rate
        /// </summary>
        public string rateDescription { get; set; }

        /// <summary>
        /// Rate Id
        /// </summary>
        public string rateID { get; set; }

        /// <summary>
        /// Rate name
        /// </summary>
        public string rateName { get; set; }

        /// <summary>
        /// List of rate tags (e.g. Breakfast)
        /// </summary>
        public List<RateTag> rateTags { get; set; }

        /// <summary>
        /// Date of arrival
        /// </summary>
        public DateTime targetDay { get; set; }
    }
}
