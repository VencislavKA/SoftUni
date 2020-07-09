using System;
using databasetest.Context;

namespace databasetest
{
     public class Program
    {
        static void Main(string[] args)
        {
            var db = new Context1();
            db.Database.EnsureCreated();
        }
    }
}
