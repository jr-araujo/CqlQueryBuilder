using System;
using CqlQueryBuilder.Console.Model;
using System.Linq;

namespace CqlQueryBuilder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ids = new[] {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};

            var query = QueryBuilder.Update<Product>().Set(p => p.Name == "jr")
                .Where(p => p.Id == Guid.NewGuid())
                .Build();
        }
    }
}
