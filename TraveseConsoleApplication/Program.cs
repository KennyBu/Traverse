using System;
using System.Linq;
using ConsoleApplication.Helpers;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            const string defaultPath = @"C:\test";

            try
            {
                var searchPath = args.Length == 0 ? defaultPath : args[0];
                
                var fileSystem = new FileSearcher();
                var searcher = new Searcher(fileSystem);
                var files = searcher.Find(searchPath);

                if (!files.Any())
                {
                    Console.WriteLine("I'm sorry no files where found.");
                }
                
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("An Error Occurred: {0}", exception.Message);
            }
            
            Console.WriteLine("");
            Console.WriteLine("Press Any Key To Exit...");
            Console.Read();
        }
    }
}
