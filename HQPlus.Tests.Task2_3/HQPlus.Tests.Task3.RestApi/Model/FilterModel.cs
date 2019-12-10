using System;
using System.ComponentModel.DataAnnotations;
using HQPlus.Tests.Task3.RestApi.Validators;
using ExpressiveAnnotations.Attributes;

namespace HQPlus.Tests.Task3.RestApi.Model
{
    public class FilterModel
    {

        /// <summary>
        /// HotelId
        /// </summary>
        [Required(ErrorMessage = "Hotel Id required")]
        public int HotelId { get; set; }

        /// <summary>
        /// DateTime to filter arrival date
        /// </summary>
        public DateTime? ArrivalDate { get; set; }

        /// <summary>
        /// Filter operator with default value "="
        /// </summary>
        [RequiredIf("ArrivalDate != null", ErrorMessage = "Operator required if ArrivalDate is present.")]
        [StringRange(AllowableValues = new[] { "=", ">", "<", ">=", "<=" }, ErrorMessage = "Invalid operator use one of  [=, <, >, <=, >=].")]
        public string Operator { get; set; } = "=";
    }
}
