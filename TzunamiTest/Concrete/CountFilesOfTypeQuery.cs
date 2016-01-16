using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Abstract;

namespace TzunamiTest.Concrete
{
    public class CountFilesOfTypeQuery : UserQuery
    {
        private string _filesType;
        public CountFilesOfTypeQuery(string filesType, IEnumerable<FileInfo> files)
            : base(files)
        {
            _filesType = filesType;
        }
        public override string Execute()
        {
             var result = _files.Where(file => file.Extension.TrimStart('.') == _filesType).Count().ToString();
            return result;
        }
    }
}
