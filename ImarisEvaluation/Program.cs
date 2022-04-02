using System;
using System.IO;

namespace Analyser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please specify working directory as parameter");
#if DEBUG
                Console.WriteLine("press any key ...");
                Console.ReadKey();
#endif
                return;
            }

            string BaseFolder = args[0];

            if (!Directory.Exists(BaseFolder))
            {
                Console.WriteLine(string.Format("Working directory {0} does not exist", BaseFolder));
#if DEBUG
                Console.WriteLine("press any key ...");
                Console.ReadKey();
#endif
                return;
            }

            DataAnalyser.AnalyseData(BaseFolder);
        }
    }
}
