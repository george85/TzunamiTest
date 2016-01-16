using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Abstract;

namespace TzunamiTest.Concrete
{
    public class AverageFilesSizeQuery : UserQuery
    {
        private string _filesType;
        public AverageFilesSizeQuery(string filesType, IEnumerable<FileInfo> files)
            : base(files)
        {
            _filesType = filesType;
        }
        public override string Execute()
        {
            var files = _files;
            if (!string.IsNullOrWhiteSpace(_filesType))
                files = _files.Where(file => file.Extension.TrimStart('.') == _filesType);
            var result = files.Average(file => file.Length / 1024 / 1024).ToString("0.00");
            return result;
        }
    }
}
