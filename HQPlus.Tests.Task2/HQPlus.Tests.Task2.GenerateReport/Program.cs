using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using HQPlus.Tests.Task2.ExcelGenerator;

namespace HQPlus.Tests.Task2.GenerateReport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/*-------------------------------------------------*/");
            Console.WriteLine("/*      HQ Plus Selection Tests By Joao Prado      */");
            Console.WriteLine("/*   Task 2 - Generate Excel From JSON From File   */");
            Console.WriteLine("/*-------------------------------------------------*/");
            Console.WriteLine();
            Console.WriteLine();

            string folder = Directory.GetCurrentDirectory();
            string fileName = "task 2 - hotelrates.json";

            string filePath = Path.Combine(folder, fileName);

            var reportGenerator = new ExcelGenerator.HotelRatesToExcel();
            reportGenerator.GenerateExcelReport(filePath).GetAwaiter().GetResult();

            Console.ReadLine();
        }
    }
}
