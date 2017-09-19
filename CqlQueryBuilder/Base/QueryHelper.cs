using System;
using System.Linq.Expressions;

namespace CqlQueryBuilder.Base
{
    public static class QueryHelper
    {
        public static string Select<T>()
        {
            var table = QueryCreate.GetTableName<T>();
            return $"SELECT * FROM {table}";
        }

        public static string Insert<T>()
        {
            var table = QueryCreate.GetTableName<T>();
            var fields = QueryCreate.GetPropertiesName<T>();
            return $"INSERT INTO {table} ({fields})";
        }


        public static string Insert<T>(params Expression<Func<T, object>>[] parameters)
        {
            var table = QueryCreate.GetTableName<T>();
            var fields = $"{QueryCreate.GetParametersName(parameters)}";
            return $"INSERT INTO {table} ({fields})";
        }

        public static string InsertValues<T>(params Expression<Func<T, object>>[] parameters)
        {
            return $"VALUES ({QueryCreate.GetValuesByParametersName(parameters)})";
        }

        public static string Delete<T>()
        {
            var table = QueryCreate.GetTableName<T>();
            return $"DELETE FROM {table}";
        }

        public static string Update<T>()
        {
            var table = QueryCreate.GetTableName<T>();
            return $"UPDATE {table}";
        }

        public static string Limit(int limit)
        {
            return $"LIMIT {limit}";
        }

        public static string AllowFiltering()
        {
            return "ALLOW FILTERING";
        }

        public static string OrderBy(object parameter, bool asc)
        {
            var orderby = $"ORDER BY {parameter} ";
            return asc ? orderby + "ASC" : orderby + "DESC";
        }

        public static string Where<T>(Expression<Func<T, bool>> parameters)
        {
            var query = QueryCreate.ToCql<T>(parameters);
            return $"WHERE {query}";
        }

        public static string Set<T>(params Expression<Func<T, object>>[] parameters)
        {
            return null;
        }
    }
}