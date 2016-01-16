using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzunamiTest.Concrete;

namespace TzunamiTest.Utils
{
    static class QueryParser
    {
        public static QueryInfo Parse(string queryString)
        {
            var query = new QueryInfo{Name = "", Param = ""}; 
            if(string.IsNullOrWhiteSpace(queryString))
            {
                return query;
            }
            var indexOfSpace =  queryString.IndexOf(' ');

            query.Name = queryString;
            if(indexOfSpace != -1)
            {
                var name = queryString.Substring(0, indexOfSpace);
                var param = queryString.Substring(indexOfSpace + 1);           
                query.Param = param;
                query.Name = name;
            }
            return query;
        }
    }
}
