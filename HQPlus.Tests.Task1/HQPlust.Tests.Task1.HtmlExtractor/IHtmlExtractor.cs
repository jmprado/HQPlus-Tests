using HQPlus.Tests.Task1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HQPlust.Tests.Task1.HtmlExtractor
{
    public interface IHtmlExtractor
    {
        /// <summary>
        /// Extract data from HTML
        /// </summary>
        /// <param name="source"></param>
        /// <returns>HotelModel</returns>
        HotelModel GetHotelInformation();

        string GetHotelName();

        string GetHotelAddress();

        int GetHotelClassification();

        double GetReviewPoints();

        int GetHotelNumberOfReviews();

        string GetDescription();

        IEnumerable<RoomCategoryModel> GetRoomCategories();

        IEnumerable<AlternativeHotelModel> GetAlternativeHotels();
    }
}
