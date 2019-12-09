using System;
using System.ComponentModel.DataAnnotations;
using HQPlus.Tests.Task3.Api.Validators;

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
        public DateTime? ArrivalDate { get; set; }

        /// <summary>
        /// Filter operator with default value "="
        /// </summary>
        [StringRange(AllowableValues = new[] { "=", ">", "<", ">=", "<=" }, ErrorMessage = "Invalid operator use one of  [=, <, >, <=, >=].")]
        public string? Operator { get; set; } = "=";
    }
}
