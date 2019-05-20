using System;
using System.IO;

namespace genfiles
{
    class Program
    {
        public static readonly int TargetHandleCount = 1024;

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Usage();
                return;
            }

            long totalKbCount = Int32.Parse(args[0]) * 1024;
            var rootDir = args[1];

            var minKChars = args.Length >= 3 ? Int32.Parse(args[2]) * 1000 : 100000;
            var maxKChars = args.Length >= 3 ? Int32.Parse(args[2]) * 1000 : 250000;

            var currentKbCount = 0.0;
            var wordSource = new WordlistStore(@"wordsets\engwords.txt");
            var textGen = new TextGenerator(wordSource.GetWordlst(), 500);
            var dirGen = new DirCreator(textGen, rootDir, Console.WriteLine);
            var pdfGen = new PdfGenerator(textGen, Console.WriteLine);
            var charCountGen = new RandomCharCountGenerator(minKChars, maxKChars, 0);

            while (currentKbCount < totalKbCount)
            {
                var dir = dirGen.GetNextSubdirectory();
                for (int i = 0; i < Program.TargetHandleCount / 2; i++)
                {
                    var fullPath = String.Empty;
                    while (String.IsNullOrEmpty(fullPath))
                    {
                        var fileName = $"{textGen.GetRandomWord()}.pdf";
                        var testFullPath = Path.Combine(dir, fileName);
                        if (!File.Exists(testFullPath)) fullPath = testFullPath;
                    }
                    var length = pdfGen.GenerateRandomPdf(fullPath, charCountGen.GetCharCount());
                    currentKbCount += length;
                }
                Console.WriteLine($"{((currentKbCount * 100) / totalKbCount):0.00}% done.");
            }
            Console.ReadLine();
        }

        public static void Usage()
        {
            Console.WriteLine("To launch this script, use the following form:");
            Console.WriteLine("  genfiles Mb-count root-directory <min-kchars> <max-kchars");
        }

    }
}
