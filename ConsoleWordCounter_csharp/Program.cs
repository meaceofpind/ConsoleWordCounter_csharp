namespace WordCounter
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text:");
            string? text = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Invalid string. Enter text again");
                text = Console.ReadLine();
            }

            int wordCount = 0, index = 0, charCount = 0;

            // skip whitespace until first word
            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;

            while (index < text.Length)
            {
                // check if current char is part of a word
                while (index < text.Length && !char.IsWhiteSpace(text[index]))
                {
                    index++;
                    charCount++;
                }
                wordCount++;

                // skip whitespace until next word
                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;
            }

            Console.WriteLine("{0:0.##} words, {1:0.##} characters", wordCount,charCount);

        }
    }
}