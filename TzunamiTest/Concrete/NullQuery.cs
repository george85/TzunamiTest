using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Abstract;

namespace TzunamiTest.Concrete
{
    public class NullQuery : UserQuery
    {
       
        public override string Execute()
        {
            return "Wrong input. Please try again.\n";
        }
    }
}
