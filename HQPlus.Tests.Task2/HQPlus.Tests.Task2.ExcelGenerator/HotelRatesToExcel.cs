using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using HQPlus.Tests.Task2.Model;
using ClosedXML.Excel;

namespace HQPlus.Tests.Task2.ExcelGenerator
{
    public class HotelRatesToExcel : IHotelRatesToExcel
    {
        public async Task<string> GenerateExcelReport(string filePath)
        {
            var jsonString = await ReadHotelRatesJson(filePath);

            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            var hotelRates = JsonSerializer.Deserialize<HotelRates>(jsonString, options);

            var hotelName = hotelRates.hotel.name;

            var fontColor = "#486891";
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet(hotelName);
                worksheet.Row(1).Style.Font.FontColor = XLColor.FromHtml(fontColor);
                worksheet.Row(1).Style.Border.BottomBorder = XLBorderStyleValues.Hair;
                worksheet.Row(1).Style.Border.BottomBorderColor = XLColor.FromHtml(fontColor);
                worksheet.Row(1).Cell(1).SetValue("ARRIVAL_DATE");
                worksheet.Row(1).Cell(2).SetValue("DEPARTURE_DATE");
                worksheet.Row(1).Cell(3).SetValue("PRICE");
                worksheet.Row(1).Cell(4).SetValue("CURRENCY");
                worksheet.Row(1).Cell(5).SetValue("RATENAME");
                worksheet.Row(1).Cell(6).SetValue("ADULTS");
                worksheet.Row(1).Cell(7).SetValue("BREAKFAST_INCLUDED");

                int i = 2;
                foreach(var rate in hotelRates.hotelRates)
                {
                    var bgColor = i % 2 == 0 ? "#DCE6F0" : "#FFFFFF";
                    worksheet.Row(i).Style.Fill.BackgroundColor = XLColor.FromHtml(bgColor);
                    worksheet.Row(i).Style.Font.FontColor = XLColor.FromHtml(fontColor);

                    worksheet.Row(i).Cell(1).SetValue($"{rate.targetDay:dd.MM.yyyy}");
                    worksheet.Row(i).Cell(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    worksheet.Row(i).Cell(2).SetValue($"{rate.targetDay.AddDays(rate.los):dd.MM.yyyy}");
                    worksheet.Row(i).Cell(2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    worksheet.Row(i).Cell(3).SetValue($"{rate.price.numericFloat:N2}");
                    worksheet.Row(i).Cell(4).SetValue(rate.price.currency);
                    worksheet.Row(i).Cell(5).SetValue(rate.rateName);
                    worksheet.Row(i).Cell(6).SetValue(rate.adults);
                    worksheet.Row(i).Cell(7).SetValue(rate.rateTags[0].shape ? 1 : 0);

                    i++;
                }

                worksheet.RangeUsed().SetAutoFilter(true);
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs($"./output/report_{hotelRates.hotel.hotelID}.xlsx");
            }

            return "";
        }

        private async Task<string> ReadHotelRatesJson(string filePath)
        {
            var fileContent = await File.ReadAllTextAsync(filePath);
            return fileContent;
        }
    }
}
