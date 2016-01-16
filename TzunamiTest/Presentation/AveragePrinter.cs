using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Abstract;

namespace TzunamiTest.Presentation
{
    public class AveragePrinter: ResultPrinter
    {
        private string _filesType;
        public AveragePrinter(string filesType, bool isCompleted) : base(isCompleted)
        {
            _filesType = filesType;
        }
        public override void Display(string result)
        {
          string output = string.Format("The average file size is : {0}Mb{1}", result, IsPartial);
          Console.WriteLine(output);
        }
    }
}
