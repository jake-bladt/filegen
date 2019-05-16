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

            var kbCount = Int32.Parse(args[0]) * 1024;
            var rootDir = args[1];

            var wordSource = new WordlistStore(@"wordsets\engwords.txt");
            var textGen = new TextGenerator(wordSource.GetWordlst(), 500);
            var gen = new PdfGenerator(textGen);
            gen.GenerateRandomPdfs(rootDir, kbCount, Console.WriteLine);

            Console.ReadLine();
        }

        public static void Usage()
        {
            Console.WriteLine("To launch this script, use the following form:");
            Console.WriteLine("  genfiles Mb-count root-directory");
        }

    }
}
