namespace CqlQueryBuilder.Base
{
    public class QueryBase : IQuery
    {
        protected QueryBase(string query)
        {
            this.Query = query;
        }

        internal string Query { get; set; }

        public string Build()
        {
            return this.Query;
        }

        internal void AddQuery(string query)
        {
            this.Query += "\n" + query;
        }
    }
}