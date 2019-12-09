using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Linq.Dynamic.Core;
using HQPlus.Tests.Task2.Model;

namespace HQPlus.Tests.Task3.RatesFilter
{
    public class RatesFilterOperation : IRatesFilterOperation
    {
        private readonly string _jsonFilePath;

        public RatesFilterOperation(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public IEnumerable<HotelRates> Filter(int hotelId)
        {
            var rates = GetHotelRatesFromJsonFile();
            return (from c in rates where c.hotel.hotelID == hotelId select c).ToList();
        }

        public IEnumerable<HotelRates> Filter(int hotelId, DateTime arrivalDate, string filterOperator)
        {
            var rates = GetHotelRatesFromJsonFile().AsQueryable();
            var hotelFiltered = rates.Where("hotel.hotelId == @0", hotelId);
            var ratesFiltered = hotelFiltered.Where($"hotelRates {filterOperator} @0", arrivalDate);
            return ratesFiltered;
        }

        private IEnumerable<HotelRates> GetHotelRatesFromJsonFile()
        {
            var jsonContent = File.ReadAllText(_jsonFilePath);

            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            var hotelRates = JsonSerializer.Deserialize<IEnumerable<HotelRates>>(jsonContent, options);
            return hotelRates;
        }
    }
}
