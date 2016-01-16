using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TzunamiTest.Presentation;

namespace TzunamiTest
{
    class Program
    {      
        static void Main(string[] args)
        {
            string pathToProcess = "";
            if (args.Length > 0)
            {
                FolderScanner scanner;
                pathToProcess = args[0];
                if (Directory.Exists(pathToProcess))
                    scanner = new FolderScanner(pathToProcess);
                else
                    scanner = new FolderScanner();
                Task.Factory.StartNew(() => scanner.Start());
            }
            Console.WriteLine("Processing {0}....", pathToProcess);
            Console.WriteLine("Please, enter query or exit to close application\n");          
            RequestHandler.Handle();
        }
    }
}
