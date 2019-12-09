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
            var serviceProvider = new ServiceCollection()
                        .AddSingleton<IHotelRatesToExcel, HotelRatesToExcel>()
                        .BuildServiceProvider();

            Console.WriteLine("/*-------------------------------------------------*/");
            Console.WriteLine("/*      HQ Plus Selection Tests By Joao Prado      */");
            Console.WriteLine("/*   Task 2 - Generate Excel From JSON From File   */");
            Console.WriteLine("/*-------------------------------------------------*/");
            Console.WriteLine();
            Console.WriteLine();

            string folder = Directory.GetCurrentDirectory();
            string fileName = "task 2 - hotelrates.json";

            string filePath = Path.Combine(folder, fileName);

            Console.WriteLine("Instatiating Report Service.");
            var hotelRatesToExcel = serviceProvider.GetService<IHotelRatesToExcel>();

            Console.WriteLine("Creating report file");
            hotelRatesToExcel.GenerateExcelReport(filePath).GetAwaiter().GetResult();

            Console.WriteLine($"Report file created at \r\n{folder}/output/");
            Console.WriteLine("End processing, press any key to exit.");
            Console.ReadLine();
        }
    }
}
