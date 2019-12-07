using System;
using System.Collections.Generic;

namespace HQPlus.Tests.Task1.Model
{
    public class HotelModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Classification { get; set; }
        public double ReviewPoints { get; set; }
        public int NumberOfReviews { get; set; }
        public string Description { get; set; }
        public IEnumerable<RoomCategoryModel> RoomCategories { get; set; }
        public IEnumerable<AlternativeHotelModel> AlternativeHotels { get; set; }
    }
}
