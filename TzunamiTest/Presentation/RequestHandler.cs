using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Factory;

namespace TzunamiTest.Presentation
{
    public class RequestHandler
    {
        public static void Handle()
        {
            
            var request = Console.ReadLine();
            while (request != "exit")
            {
                var queryFactory = new QueryFactory(request);               
                var result = queryFactory.Query.Execute();
                queryFactory.Printer.Display(result);
                request = Console.ReadLine();
            }
        }
    }
}
