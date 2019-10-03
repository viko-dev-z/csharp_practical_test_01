using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace A2_FileReader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press a key to start file reading...");
            Console.ReadKey();

            string path = "D:/text.txt";
            FileStream fileStream = new FileStream(path,
                                                   FileMode.Open);

            int bufferSize = 128;  // minimum is 128 , default is 4096
            StreamReader reader = new StreamReader(fileStream,
                                                   Encoding.UTF8,
                                                   true,
                                                   bufferSize);
            //string lineOfText = "";

            //while ((lineOfText = reader.ReadLine()) != null)
            //{
            //    await Task.Delay(10000);
            //    Console.WriteLine(lineOfText);
            //}

            Task<FullText> displayFullText = DisplayFullTextAsync(reader);

            var allTasks = new List<Task> { displayFullText };

            while (allTasks.Count > 0)
            {
                Task finished = await Task.WhenAny(allTasks);

                if (finished == displayFullText)
                {
                    Console.WriteLine("Dysplay Full Text Async is ready");
                }

                allTasks.Remove(finished);
            }
            Console.WriteLine("Breakfast is ready!");
        }

        private static async Task<FullText> DisplayFullTextAsync(StreamReader reader)
        {
            Console.WriteLine("Start displaying full text at once...");
            await Task.Delay(3000);
            Console.WriteLine(reader.ReadToEnd());
            Console.WriteLine("Display complete");
            return new FullText();
        }

    }

        //private static async Task<string> GetInputAsync()
        //{
        //    return await Task.Run(() => Console.ReadLine());
        //}

        //private static async Task<string> GetLinesAsync()
        //{
        //    return await Task.Run(() => Console.ReadLine());
        //}

        //public static IEnumerable<int> EnumLines(int count)
        //{
        //    int prev = 1;
        //    int curr = 1;

        //    for (int i = 0; i < count; i++)
        //    {
        //        yield return prev;
        //        int temp = prev + curr;
        //        prev = curr;
        //        curr = temp;
        //    }
        //}

  
}
