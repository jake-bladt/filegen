using System;

namespace genfiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Usage();
                return;
            }

            var kbCount = Int64.Parse(args[0]);
            var rootDir = args[1];

            var wordSource = new WordlistStore(@"wordsets\engwords.txt");
            var gen = new PdfGenerator(wordSource.GetWordlst());
            gen.GenerateRandomPdf(@"C:\code\notcode\gen.pdf", 10000);
        }

        public static void Usage()
        {
            Console.WriteLine("To launch this script, use the following form:");
            Console.WriteLine("  genfiles kb-count root-directory");
        }

    }
}
