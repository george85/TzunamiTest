using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Abstract;

namespace TzunamiTest.Presentation
{
   public class SearchPrinter : ResultPrinter
    {
       public SearchPrinter(bool isCompleted) : base(isCompleted)
       {

       }
        public override void Display(string result)
        {
            string output;
            if (string.IsNullOrWhiteSpace(result))
                output = string.Format("File nout found\n");
            else
            {
                output = string.Format("File was found in following folders:\n");
                foreach (var path in result.Split(';'))
                    output = string.Concat(output, path + "\n");
            }
            Console.WriteLine(output + IsPartial);
        }
    }
}
