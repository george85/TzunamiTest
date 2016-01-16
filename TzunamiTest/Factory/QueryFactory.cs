using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Abstract;
using TzunamiTest.Concrete;
using TzunamiTest.Presentation;
using TzunamiTest.Utils;

namespace TzunamiTest.Factory
{
    public class QueryFactory
    {
        private UserQuery _query;
        private ResultPrinter _printer;
        public UserQuery Query
        {
            get
            { return _query; }
        }
        public ResultPrinter Printer
        {
            get
            {
                return _printer;
            }
        }
        public QueryFactory(string query)
        {
            var queryInfo = QueryParser.Parse(query);
            BlockingCollection<FileInfo> files;
            if (queryInfo.Param.Contains(Priority.Extension))
                files = FolderScanner.PriorityFiles;
            else
                files = FolderScanner.Files;
            var param = queryInfo.Param;
            switch (queryInfo.Name.ToLower())
            {
                case "count":
                    _query = new CountFilesOfTypeQuery(param, files);
                    _printer = new CountPrinter(param, files.IsAddingCompleted);
                    break;
                case "name":
                    _query = new SearchFilesByNameQuery(param, files);
                    _printer = new SearchPrinter(files.IsAddingCompleted);
                    break;
                case "size":
                    _query = new AverageFilesSizeQuery(param, files);
                    _printer = new AveragePrinter(param, files.IsAddingCompleted);
                    break;
                default:
                    _query = new NullQuery();
                    _printer = new ResultPrinter(files.IsAddingCompleted);
                    break;
            }
        }

       
    }
}
