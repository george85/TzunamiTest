using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Abstract;

namespace TzunamiTest.Concrete
{
    public class SearchFilesByNameQuery : UserQuery
    {
        private string _fileName;
        public SearchFilesByNameQuery(string fileName, IEnumerable<FileInfo> files)
            : base(files)
        {
            _fileName = fileName;
        }
        public override string Execute()
        {
            var paths = _files.Where(file => file.Name == _fileName).Select(file => file.FullName);

            return string.Join(";", paths);
        }
    }
}
