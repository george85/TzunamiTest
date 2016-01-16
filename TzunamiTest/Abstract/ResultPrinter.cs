using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzunamiTest.Abstract
{
    public class ResultPrinter
    {
        private bool _isCompleted;

        public ResultPrinter(bool isCompleted)
        {
            _isCompleted = isCompleted;
        }
        protected string IsPartial
        {
            get
            {
                if (!_isCompleted)
                    return "\n(Partial response - process still ongoing)";
                else return "";
            }
        }
        public virtual void Display(string result)
        {
            Console.WriteLine("{0}{1}\n", result, IsPartial);
        }
    }
}
