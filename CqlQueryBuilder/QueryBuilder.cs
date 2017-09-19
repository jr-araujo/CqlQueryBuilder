using System;
using System.Linq.Expressions;
using CqlQueryBuilder.Base;
using CqlQueryBuilder.Builders;

namespace CqlQueryBuilder
{
    public static class QueryBuilder
    {
        public static SelectBuilder<T> Select<T>() where T : class
        {
            var query = QueryHelper.Select<T>();
            return new SelectBuilder<T>(query);
        }

        public static SelectBuilder<T> Select<T>(params Expression<Func<T, object>>[] parameters) where T : class
        {
            throw new NotImplementedException();
        }

        public static DeleteBuilder<T> Delete<T>() where T : class
        {
            var query = QueryHelper.Delete<T>();
            return new DeleteBuilder<T>(query);
        }

        public static InsertBuilder<T> Insert<T>() where T : class
        {
            var query = QueryHelper.Insert<T>();
            return new InsertBuilder<T>(query);
        }

        public static InsertBuilder<T> Insert<T>(params Expression<Func<T, object>>[] parameters) where T : class
        {
            var query = QueryHelper.Insert(parameters);
            return new InsertBuilder<T>(query);
        }

        public static UpdateBuilder<T> Update<T>() where T : class
        {
            var query = QueryHelper.Update<T>();
            return new UpdateBuilder<T>(query);
        }
    }
}
