using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HQPlus.Tests.Task2.Model;

namespace HQPlus.Tests.Task3.RatesFilter
{
    public class RatesFilterOperation : IRatesFilterOperation
    {
        private readonly IEnumerable<HotelRates> _hotelRates;

        public RatesFilterOperation(string jsonFilePath)
        {
            var jsonContent = File.ReadAllText(jsonFilePath);
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            var _hotelRates = JsonSerializer.Deserialize<HotelRates>(jsonContent, options);
        }

        public IEnumerable<HotelRates> Filter(int hotelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HotelRates> Filter(int hotelId, DateTime arrivalDate, string filterOperator)
        {
            throw new NotImplementedException();
        }
    }
}
