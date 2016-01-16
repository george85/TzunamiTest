using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzunamiTest.Abstract
{
    public abstract class UserQuery
    {
         protected IEnumerable<FileInfo> _files;
         protected UserQuery()
         {

         }
         public UserQuery(IEnumerable<FileInfo> files)
         {
             _files = files;
         }
       abstract public string Execute();
       

    }
}
