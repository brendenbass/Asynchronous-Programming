using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous_Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 200000;
            char selectedChar = 'r';

            Task<string> t = ConcatenateCharsAsync(selectedChar, count);

            Console.WriteLine("In Progress.");
            Thread.Sleep(333);
            Console.Clear();
            Console.WriteLine("In Progress..");
            Thread.Sleep(333);
            Console.Clear();
            Console.WriteLine("In Progress...");

            Console.WriteLine($"The length of the result completed is {t.Result.Length}.");
        }

        public static string ConcatenateChars(char charToConcatenate, int count)
        {
            string concatenatedString = String.Empty;

            for (int i = 0; i < count; i++)
            {
                concatenatedString += charToConcatenate;
            }
            return concatenatedString;
        }

        public async static Task<string> ConcatenateCharsAsync(char charToConcatenate, int count)
        {
            return await Task.Factory.StartNew(() =>
            {
                return ConcatenateChars(charToConcatenate, count);
            });
        }
    }
}
