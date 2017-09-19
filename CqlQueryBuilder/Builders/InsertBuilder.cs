using System;
using System.Linq.Expressions;
using CqlQueryBuilder.Base;

namespace CqlQueryBuilder.Builders
{
    public class InsertBuilder<T> : QueryBase
    {
        public InsertBuilder(string query) : base(query)
        {
        }

        public InsertBuilder<T> Values(params Expression<Func<T, object>>[] fields)
        {
            var values = QueryHelper.InsertValues<T>(fields);
            this.AddQuery(values);
            return new InsertBuilder<T>(this.Query);
        }
    }
}