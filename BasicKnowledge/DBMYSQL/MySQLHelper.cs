using DBInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMYSQL
{
    class MySQLHelper : IDBHelper
    {
        public MySQLHelper() {
            Console.WriteLine("MySQL Helper Init");
        }
        public void Delete()
        {
            Console.WriteLine("This is MySQL Delete");
        }

        public void Query()
        {
            Console.WriteLine("This is MySQL Query");
        }
    }
}
