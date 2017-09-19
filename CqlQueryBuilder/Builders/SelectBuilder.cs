using System;
using System.Linq.Expressions;
using CqlQueryBuilder.Base;
using CqlQueryBuilder.Builders.Contracts;

namespace CqlQueryBuilder.Builders
{
    public class SelectBuilder<T> : QueryBase, ISelectBuilder<T>, IWhereBuilder<SelectBuilder<T>, T>, IAllowFiltering<SelectBuilder<T>> where T : class
    {
        public SelectBuilder(string query) : base(query)
        {

        }

        public SelectBuilder<T> Limit(int limit)
        {
            this.AddQuery(QueryHelper.Limit(limit));
            return new SelectBuilder<T>(this.Query);
        }

        public SelectBuilder<T> OrderByAsc(Expression<Func<T, object>> parameter)
        {
            var param = QueryCreate.GetParametersName(parameter);
            this.AddQuery(QueryHelper.OrderBy(param, true));
            return new SelectBuilder<T>(this.Query);
        }

        public SelectBuilder<T> OrderByDesc(Expression<Func<T, object>> parameter)
        {
            throw new NotImplementedException();
        }

        public SelectBuilder<T> Where(Expression<Func<T, bool>> parameters)
        {
            this.AddQuery(QueryHelper.Where(parameters));
            return new SelectBuilder<T>(this.Query);
        }

        public SelectBuilder<T> AllowFilter()
        {
            this.AddQuery(QueryHelper.AllowFiltering());
            return new SelectBuilder<T>(this.Query);
        }
    }
}