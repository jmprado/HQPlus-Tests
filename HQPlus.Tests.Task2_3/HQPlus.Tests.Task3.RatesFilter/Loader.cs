using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HQPlus.Tests.Task2.Model;

namespace HQPlus.Tests.Task3.RatesFilter
{
    public static class Loader
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true
        };

        public static IEnumerable<HotelRates> LoadJson(string jsonPath, string jsonFile)
        {
            var jsonContent = File.ReadAllText(Path.Combine(jsonPath, jsonFile));
            var hotelRates = JsonSerializer.Deserialize<IEnumerable<HotelRates>>(jsonContent, _options);
            return hotelRates;
        }

        public static IEnumerable<HotelRates> LoadJson(Stream jsonStream)
        {
            var hotelRates = JsonSerializer.DeserializeAsync<IEnumerable<HotelRates>>(jsonStream, _options).Result;
            return hotelRates;
        }

        public static IEnumerable<HotelRates> LoadJson(string jsonString)
        {
            return JsonSerializer.Deserialize<IEnumerable<HotelRates>>(jsonString, _options);
        }
    }
}
