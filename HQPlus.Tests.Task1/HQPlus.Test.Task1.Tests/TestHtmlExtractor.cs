using HQPlust.Tests.Task1.HtmlExtractor;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace HQPlus.Tests.Task1.Tests
{
    public class TestHtmlExtractor
    {        
        private readonly IHtmlExtractor _htmlExtractor;
        private string folder = "E:\\Source\\HQPlus\\Task1\\";
        private string file = "task 1 - Kempinski Hotel Bristol Berlin, Germany - Booking.com.html";

        public TestHtmlExtractor()
        {
            _htmlExtractor = new HtmlExtractor(folder, file);
        }

        [Fact]

        public void TestGetHotelName()
        {
            var hotelName = _htmlExtractor.GetHotelName();
            Assert.Equal("Kempinski Hotel Bristol Berlin", hotelName);
        }

        [Fact]
        public void TestGetHotelAddress()
        {
            var hotelAddress = _htmlExtractor.GetHotelAddress();
            Assert.Equal("Kurfürstendamm 27, Charlottenburg-Wilmersdorf, 10719 Berlin, Germany", hotelAddress);
        }


        [Fact]
        public void TestGetHotelClassification()
        {
            var hotelClassification = _htmlExtractor.GetHotelClassification();
            Assert.Equal(5, hotelClassification);
        }

        [Fact]
        public void TestReviewPoints()
        {
            var reviewPoints = _htmlExtractor.GetReviewPoints();
            Assert.Equal(9.3, reviewPoints);
        }

        [Fact]
        public void TestNumberOfReviews()
        {
            var hotelNumberOfReviews = _htmlExtractor.GetHotelNumberOfReviews();
            Assert.Equal(1401, hotelNumberOfReviews);
        }

        [Fact]
        public void TestGetDescription()
        {
            var testString = @"<p>This 5-star hotel on Berlin’s Kurfürstendamm shopping street offers elegant rooms, an indoor pool and great public transport links. It is 600 metres from the Gedächtniskirche Church and Berlin Zoo.</p><p>Kempinski Hotel Bristol Berlin offers air-conditioned rooms with large windows, modern bathrooms and international TV channels. Bathrobes are provided. Free WiFi is available in all areas and high-speed WiFi access can be booked at an additional cost.</p><p>Gourmet cuisine is served in the popular Kempinski Grill. Reinhard's brasserie offer light cuisine and a terrace overlooking Kurfürstendamm. Guests can enjoy drinks in the Gobelin Halle lounge or in the Bristol Bar.</p><p>Kempinski Bristol Berlin’s spa includes a sauna, steam room and gym. Massages and beauty treatments can also be booked here. The hotel's business centre can be used free of charge.</p><p>Uhlandstraße Underground Station is just outside the Kempinski’s front door. The KaDeWe shopping mall is 2 stops away.<br></p>";
            var compareTestString = Regex.Replace(testString, @"\s+", String.Empty);

            var description = _htmlExtractor.GetDescription();
            var compareDescriptionString = Regex.Replace(description, @"\s+", String.Empty);

            Assert.Equal(compareTestString, compareDescriptionString);
        }

        [Fact]
        public void TestGetListCategoryRoom()
        {
            var listCategoryRoom = _htmlExtractor.GetRoomCategories();
            Assert.Equal(7, listCategoryRoom.Count());
        }

        [Fact]
        public void TestGetListAlternativeHotel()
        {
            var listAlternativeHotel = _htmlExtractor.GetAlternativeHotels();
            Assert.Equal(4, listAlternativeHotel.Count());
        }
    }
}
