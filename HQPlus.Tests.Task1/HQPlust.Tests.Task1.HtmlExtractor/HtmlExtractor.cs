using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HQPlus.Tests.Task1.Model;
using HtmlAgilityPack;
using System.Linq;
using System.Globalization;

namespace HQPlust.Tests.Task1.HtmlExtractor
{

    public class HtmlExtractor : IHtmlExtractor
    {
        private readonly HtmlDocument _htmlDocument = new HtmlDocument();

        public HtmlExtractor(string folder, string file)
        {
            _htmlDocument.Load(Path.Combine(folder, file));
        }

        public HtmlExtractor(string source)
        {
            _htmlDocument.LoadHtml(source);
        }

        public HtmlExtractor(Stream source)
        {
            _htmlDocument.Load(source);
        }

        public HotelModel GetHotelInformation()
        {
            var hotelModel = new HotelModel
            {
                Name = GetHotelName(),
                Address = GetHotelAddress(),
                Description = GetDescription(),
                Classification = GetHotelClassification(),
                ReviewPoints = GetReviewPoints(),
                NumberOfReviews = GetHotelNumberOfReviews(),
                RoomCategories = GetRoomCategories(),
                AlternativeHotels = GetAlternativeHotels()
            };

            return hotelModel;
        }

        public string GetHotelName()
        {
            var htmlNode = _htmlDocument.DocumentNode.SelectSingleNode("//span[@id=\"hp_hotel_name\"]");
            string value = (htmlNode == null) ? "Error, id not found" : htmlNode.InnerText;
            return value.Trim();
        }

        public string GetHotelAddress()
        {
            var htmlNode = _htmlDocument.DocumentNode.SelectSingleNode("//span[@id=\"hp_address_subtitle\"]");
            string value = (htmlNode == null) ? "Error, id not found" : htmlNode.InnerText;
            return value.Trim();
        }

        public int GetHotelClassification()
        {
            var htmlNode = _htmlDocument.DocumentNode.SelectSingleNode("//i[contains(@class, 'ratings_stars_')]");
            var nodeClasses = htmlNode.GetClasses();
            var classificationClass = nodeClasses.Where(c => c.Contains("ratings_stars_")).FirstOrDefault();
            var classification = classificationClass.Replace("ratings_stars_", string.Empty);
            return int.Parse(classification);
        }

        public double GetReviewPoints()
        {
            var htmlNode = _htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"location_score_tooltip\"]");
            var stringNode = htmlNode.Descendants().Where(n => n.Name == "p").FirstOrDefault().InnerText;
            var reviewPoints = stringNode.Substring(stringNode.IndexOf("/") - 3, 3).Trim();
            return double.Parse(reviewPoints.Trim(), CultureInfo.InvariantCulture);
        }

        public int GetHotelNumberOfReviews()
        {
            var htmlNode = _htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"location_score_tooltip\"]");
            var nodeNumberOfReviews = htmlNode.Descendants().Where(n => n.Name == "small").FirstOrDefault();
            var strNumberOfReviews = nodeNumberOfReviews.Descendants().Where(n => n.Name == "strong").FirstOrDefault().InnerText;
            return int.Parse(strNumberOfReviews);
        }

        public string GetDescription()
        {
            var htmlNode = _htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"summary\"]");
            var paragraphNodes = htmlNode.Descendants().Where(n => n.Name == "p");
            StringBuilder sb = new StringBuilder();
            foreach (var item in paragraphNodes)
            {
                sb.Append($"<p>{item.InnerHtml.Trim().Replace("\r\n", string.Empty)}</p>");
            }

            return sb.ToString();
        }

        public IEnumerable<RoomCategoryModel> GetRoomCategories()
        {
            var listCategoryRoom = new List<RoomCategoryModel>();

            var tableRows = _htmlDocument.DocumentNode.SelectNodes("//table[@id=\"maxotel_rooms\"]//tbody//tr");
            foreach (var row in tableRows)
            {
                var tableCells = row.Descendants("td").ToArray();
                var cellCapacity = tableCells[0].Descendants("i").FirstOrDefault();
                var strCapacity = cellCapacity.GetAttributeValue("title", "n/a");

                var capacity = int.Parse(strCapacity.Replace("Standard occupancy:", string.Empty).Trim());
                var plusKid = tableCells[0].Descendants("span").Where(c => c.HasClass("plus_kids")).FirstOrDefault() != null;

                var roomType = tableCells[1].InnerText.Replace("\n", string.Empty);

                var roomCategory = new RoomCategoryModel
                {
                    Capacity = capacity,
                    PlusKid = plusKid,
                    RoomType = roomType
                };

                listCategoryRoom.Add(roomCategory);
            }

            return listCategoryRoom;
        }

        public IEnumerable<AlternativeHotelModel> GetAlternativeHotels()
        {
            var listAlternativeHotels = new List<AlternativeHotelModel>();

            var tableCells = _htmlDocument.DocumentNode.SelectNodes("//table[@id=\"althotelsTable\"]//tbody//tr//td");

            foreach (var cell in tableCells)
            {
                var hotelName = cell.Descendants("a").Where(c => c.HasClass("althotel_link")).FirstOrDefault().InnerText.Trim();
                var hotelDescription = cell.Descendants("span").Where(c => c.HasClass("hp_compset_description")).FirstOrDefault().InnerText.Trim();

                var strHotelClassification = cell.Descendants("i").Where(c => c.HasClass("b-sprite")).FirstOrDefault().GetAttributeValue("title", "0");
                var classification = 0;

                if (strHotelClassification.IndexOf("Estimated") > -1)
                {
                    var strClassificationNumber = strHotelClassification.Substring(strHotelClassification.IndexOf("/") + 1, 1);
                    classification = int.Parse(strClassificationNumber);
                }
                else
                    classification = int.Parse(strHotelClassification.Replace("-star hotel", string.Empty));

                var strHotelReviewPoints = cell.Descendants("span").Where(c => c.HasClass("average")).FirstOrDefault().InnerText;
                var hotelReviewPoints = double.Parse(strHotelReviewPoints);

                var strHotelNumberReviews = cell.Descendants("strong").Where(c => c.HasClass("count")).FirstOrDefault().InnerText;
                var numberReviews = int.Parse(strHotelNumberReviews);

                var alternativeHotel = new AlternativeHotelModel
                {
                    Name = hotelName,
                    Description = hotelDescription,
                    Classification = classification,
                    ReviewPoints = hotelReviewPoints,
                    NumberOfReviews = numberReviews
                };

                listAlternativeHotels.Add(alternativeHotel);
            }

            return listAlternativeHotels;
        }
    }
}
