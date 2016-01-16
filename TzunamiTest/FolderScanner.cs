using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzunamiTest
{
     public  class FolderScanner
    {
         private string _folderPath;
         private string _priorityExtension;
         public static BlockingCollection<FileInfo> PriorityFiles { get; private set; }
         public static BlockingCollection<FileInfo> Files { get; private set; }

         private readonly string  _searchPattern;
         public FolderScanner() : this("c:\\") 
         {
             
         }
        public FolderScanner(string folderPath )
        {
            Files = new BlockingCollection<FileInfo>();
            PriorityFiles = new BlockingCollection<FileInfo>();
            _folderPath = folderPath;
            _priorityExtension = Priority.Extension; // if needed may be placed in config file
            _searchPattern = string.Format("*.{0}", _priorityExtension);
        }

        public  void Start()
        {
            GetPriorityFiles();
            GetAllFiles();
           // System.Diagnostics.Stopwatch stopper = new System.Diagnostics.Stopwatch();
          //  stopper.Start();           
          //  stopper.Stop();
          //  Console.WriteLine("{0} time elapsed\n{1} files found", stopper.Elapsed, Files.Count());         
        }
        private void GetPriorityFiles()
        {
            GetFiles(_folderPath, (file) => PriorityFiles.Add(file), _searchPattern);
            PriorityFiles.CompleteAdding();
        }
        private void GetAllFiles()
        {
            GetFiles(_folderPath, (file) => Files.Add(file));
            Files.CompleteAdding();   
        }
        private  void GetFiles(string path,  Action<FileInfo> addFile, string pattern ="*")
        {
            try
            {
                var currentDirectoryFiles = new DirectoryInfo(path).EnumerateFiles(pattern, SearchOption.TopDirectoryOnly);
                foreach (FileInfo file in currentDirectoryFiles)
                    addFile(file);
                foreach (var directory in Directory.EnumerateDirectories(path))
                    GetFiles(directory, addFile, pattern);

            }
            catch (UnauthorizedAccessException) { }
        }
    }
}
