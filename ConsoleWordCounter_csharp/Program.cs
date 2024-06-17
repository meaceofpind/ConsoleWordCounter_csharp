using System.Diagnostics.Metrics;
using System.Text;
using System.Text.RegularExpressions;

namespace WordCounter
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Read from text");
            Console.WriteLine("\t2 - Read from file");
            Console.Write("Your option? ");
            string? op = Console.ReadLine();
            string? text = String.Empty;

            if (op == null || !Regex.IsMatch(op, "[1|2]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else if (op =="1")
            {
                Console.WriteLine("Enter text:");
                text = Console.ReadLine();

                while (String.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Invalid string. Enter text again");
                    text = Console.ReadLine();
                }
            }
            else if(op =="2") 
            {
                Console.WriteLine("Enter path:");
                string? path = Console.ReadLine();

                while (String.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Invalid path. Enter text again");
                    path = Console.ReadLine();
                }
                try
                {
                    using StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
                    text = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while reading file: " + e.Message);
                }
            }           

            int[] count = Counter(text);

            Console.WriteLine("{0:0.##} words, {1:0.##} characters", count[0], count[1]);

        }

        static int[] Counter(string text)
        {
            int[] count = { 0, 0 };
            int index = 0;

            // skip whitespace until first word
            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;

            while (index < text.Length)
            {
                // check if current char is part of a word
                while (index < text.Length && !char.IsWhiteSpace(text[index]))
                {
                    index++;
                    count[1]++;
                }
                count[0]++;

                // skip whitespace until next word
                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;
            }

            return count;
        }
    }
}