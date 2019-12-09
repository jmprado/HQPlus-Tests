using System;
using System.IO;
using HQPlus.Tests.Task2.ExcelGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace HQPlus.Tests.Task2.GenerateReport
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Directory.GetCurrentDirectory();
            string fileName = "task 2 - hotelrates.json";

            string filePath = Path.Combine(folder, fileName);

            var serviceProvider = new ServiceCollection()
                        .AddSingleton<IHotelRatesToExcel>(provider => new HotelRatesToExcel(filePath))
                        .BuildServiceProvider();

            Console.WriteLine("/*-------------------------------------------------*/");
            Console.WriteLine("/*      HQ Plus Selection Tests By Joao Prado      */");
            Console.WriteLine("/*   Task 2 - Generate Excel From JSON From File   */");
            Console.WriteLine("/*-------------------------------------------------*/");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Getting Report Service.");
            var hotelRatesToExcel = serviceProvider.GetService<IHotelRatesToExcel>();

            Console.WriteLine("Creating report file");
            hotelRatesToExcel.GenerateExcelReport(filePath).GetAwaiter().GetResult();

            Console.WriteLine($"Report file created at:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"{folder}/output");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("End processing, press any key to exit.");
            Console.ReadLine();
        }
    }
}
