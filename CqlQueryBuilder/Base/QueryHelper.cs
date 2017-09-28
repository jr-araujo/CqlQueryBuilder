using CqlQueryBuilder.Utils;
using System;
using System.Linq.Expressions;
using System.Text;

namespace CqlQueryBuilder.Base
{
    public static class QueryHelper
    {
        private const string InsertStatement = "INSERT INTO ";

        public static string Select<T>()
        {
            var table = QueryCreate.GetTableName<T>();
            return $"SELECT * FROM {table}";
        }

        public static string GenerateInsertStatement<T>(T type) =>
            new StringBuilder()
                .Append(InsertStatement)
                .Append(typeof(T).GetMappedTableName())
                .Append($" ({typeof(T).GetListOfMappedPropertiesWithComma()}) ")
                .Append("VALUES ")
                .Append("(" + type.GetAllValuesOfPropertiesWithComma() + ")")
                .ToString();

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