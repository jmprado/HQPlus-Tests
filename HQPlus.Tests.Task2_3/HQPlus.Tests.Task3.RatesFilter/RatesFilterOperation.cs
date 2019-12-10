using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using HQPlus.Tests.Task2.Model;

namespace HQPlus.Tests.Task3.RatesFilter
{
    public class RatesFilterOperation : IRatesFilterOperation
    {
        private readonly string _jsonFilePath;
        private readonly IEnumerable<HotelRates> _hotelRates;

        /// <summary>
        /// Initialize rates filter operation for file load
        /// </summary>
        /// <param name="jsonPath">Folder where file resided</param>
        /// <param name="jsonFile">JSON file name</param>
        public RatesFilterOperation(string jsonPath, string jsonFile)
        {
            _hotelRates = Loader.LoadJson(jsonPath, jsonFile);
        }

        /// <summary>
        /// Initialize rates filter operation for stream load
        /// </summary>
        /// <param name="jsonStream">JSON stream</param>
        public RatesFilterOperation(Stream jsonStream)
        {
            _hotelRates = Loader.LoadJson(jsonStream);
        }


        /// <summary>
        /// Initialize rates filter operation for string load
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        public RatesFilterOperation(string jsonString)
        {
            _hotelRates = Loader.LoadJson(jsonString);
        }

        /// <summary>
        /// Initialize rates filter operation for IEnumerable<HotelRates> Object
        /// </summary>
        /// <param name="hotelRates">IEnumerable HotelRates object</param>
        public RatesFilterOperation(IEnumerable<HotelRates> hotelRates)
        {
            _hotelRates = hotelRates;
        }


        public HotelRates Filter(int hotelId, DateTime? arrivalDate, string filterOperator)
        {
            if (!arrivalDate.HasValue)
                return (from c in _hotelRates where c.hotel.hotelID == hotelId select c).FirstOrDefault();

            var hotel = (from c in _hotelRates where c.hotel.hotelID == hotelId select c).FirstOrDefault();
            var ratesFiltered = new List<HotelRate>();

            TimeSpan timeInitDay = new TimeSpan(0, 0, 0, 0);
            TimeSpan timeEndDay = new TimeSpan(0, 23, 59, 59);

            DateTime dateInit = arrivalDate.Value.Add(timeInitDay);
            DateTime dateEnd = arrivalDate.Value.Add(timeEndDay);

            if (hotel != null)
            {
                var ratesToFilter = hotel.hotelRates;

                ratesFiltered = filterOperator switch
                {
                    "=" => (from c in ratesToFilter where c.targetDay >= dateInit && c.targetDay <= dateEnd select c).ToList(),
                    "<" => (from c in ratesToFilter where c.targetDay < dateInit select c).ToList(),
                    "<=" => (from c in ratesToFilter where c.targetDay <= dateInit select c).ToList(),
                    ">" => (from c in ratesToFilter where c.targetDay > dateEnd select c).ToList(),
                    ">=" => (from c in ratesToFilter where c.targetDay >= dateEnd select c).ToList(),
                    _ => ratesToFilter,
                };

                var hotelReturn = new HotelRates
                {
                    hotel = hotel.hotel,
                    hotelRates = ratesFiltered
                };

                return hotelReturn;
            }

            return null;
        }

    }
}
