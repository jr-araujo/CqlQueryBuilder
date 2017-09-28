using CqlQueryBuilder.Test.Model;
using System;
using Xunit;

namespace CqlQueryBuilder.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //var ids = new[] {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};

            var query = QueryBuilder.Update<Product>().Set(p => p.Name == "jr")
                .Where(p => p.Id == Guid.NewGuid())
                .GetCqlStatement();
        }
    }
}
