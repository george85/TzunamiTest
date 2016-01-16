using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Abstract;

namespace TzunamiTest.Presentation
{
    public class CountPrinter : ResultPrinter
    {
        string _fileType;
        public CountPrinter(string fileType, bool isCompleted) : base(isCompleted)
        {
            _fileType = fileType;
        }
        public override void Display(string result)
        {
            Console.WriteLine("Result : {0} files found with '{1}' extension{2}",result, _fileType, IsPartial);
        }
    }
}
