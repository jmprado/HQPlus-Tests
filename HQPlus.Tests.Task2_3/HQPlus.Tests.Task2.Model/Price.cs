
namespace HQPlus.Tests.Task2.Model
{
    /// <summary>
    /// Price class
    /// </summary>
    public class Price
    {
        /// <summary>
        /// Currency used in rate
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// Float value of price
        /// </summary>
        public double numericFloat { get; set; }

        /// <summary>
        /// Integer representing price
        /// </summary>
        public int numericInteger { get; set; }
    }
}
