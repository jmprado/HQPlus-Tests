using System;
using System.Threading.Tasks;

namespace HQPlus.Tests.Task2.ExcelGenerator
{
    public interface IHotelRatesToExcel
    {
        /// <summary>
        /// Generate excel file from hotelrates.json and return the xslx file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<string> GenerateExcelReport(string jsonFilePath);
    }
}
