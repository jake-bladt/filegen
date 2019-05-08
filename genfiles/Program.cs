using System;

namespace genfiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Usage();
                return;
            }

            var rootDir = args[0];


            Console.WriteLine("Hello World!");
        }


        public static void Usage()
        {
            Console.WriteLine("To launch this script, use the following form:");
            Console.WriteLine("  genfiles root-directory");
        }

    }
}
