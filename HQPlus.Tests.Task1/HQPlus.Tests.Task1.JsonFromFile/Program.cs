using System;
using System.IO;
using System.Text.Json;
using HQPlust.Tests.Task1.HtmlExtractor;

namespace HQPlus.Tests.Task1.DoJsonExtraction
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("/*---------------------------------------*/");
            Console.WriteLine("/* HQ Plus Selection Tests By Joao Prado */");
            Console.WriteLine("/*   Task 1A - Generate JSON From File   */");
            Console.WriteLine("/*---------------------------------------*/");
            Console.WriteLine();
            Console.WriteLine();

            string folder = Directory.GetCurrentDirectory();
            string fileName = "task1.html";

            var htmlExtractorFromFile = new HtmlExtractor(folder, fileName);
            var hotelModelA = htmlExtractorFromFile.GetHotelInformation();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var modelJson = JsonSerializer.Serialize(hotelModelA, options);

            Console.WriteLine("Extracted JSON from file:");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(modelJson);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Finished task 1A get JSON from file.");
            Console.WriteLine("Press any key to continue next task.");

            Console.ReadLine();

            Console.WriteLine("/*---------------------------------------*/");
            Console.WriteLine("/* HQ Plus Selection Tests By Joao Prado */");
            Console.WriteLine("/*  Task 1B - Generate JSON From String  */");
            Console.WriteLine("/*---------------------------------------*/");

            var htmlString = File.ReadAllText(Path.Combine(folder, fileName));
            var htmlExtractorFromString = new HtmlExtractor(htmlString);
            var hotelModelB = htmlExtractorFromString.GetHotelInformation(); 
            modelJson = JsonSerializer.Serialize(hotelModelB, options);

            Console.WriteLine();
            Console.WriteLine("Extracted JSON from string:");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(modelJson);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Finished task 1B get JSON from string.");
            Console.WriteLine("Press any key to continue next task.");

            Console.ReadLine();

            Console.WriteLine("/*---------------------------------------*/");
            Console.WriteLine("/* HQ Plus Selection Tests By Joao Prado */");
            Console.WriteLine("/*  Task 1C - Generate JSON From Stream  */");
            Console.WriteLine("/*---------------------------------------*/");
            Console.WriteLine();

            using (var fileStream = new FileStream(Path.Combine(folder, fileName), FileMode.Open, FileAccess.Read))
            {
                var htmlExtractorFromStream = new HtmlExtractor(fileStream);
                var hotelModelC = htmlExtractorFromStream.GetHotelInformation();
                modelJson = JsonSerializer.Serialize(hotelModelC, options);

                Console.WriteLine("Extracted JSON from stream:");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(modelJson);
                Console.WriteLine("--------------------------------------");                
            }

            Console.WriteLine("Finished task 1C get JSON from string.");
            Console.WriteLine("HQ Plus Task 1 finished.");
            Console.WriteLine("Press any key to exit. ");
            Console.ReadLine();
        }
    }
}
