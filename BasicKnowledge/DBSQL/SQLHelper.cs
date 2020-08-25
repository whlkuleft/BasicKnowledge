using DBInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSQL
{
    public class SQLHelper : IDBHelper
    {
        public string Name { get; set; }
        public string FName;
        public SQLHelper() {
            Console.WriteLine("SQL Helper Init");
        }
        public void Delete()
        {
            Console.WriteLine("This is SQL Delete");
        }

        public void Query()
        {
            Console.WriteLine("This is SQL Query");
        }
    }
}
