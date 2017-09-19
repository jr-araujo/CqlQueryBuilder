using System;

namespace CqlQueryBuilder.Base
{

    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }
        public TableAttribute(string name)
        {
            this.Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsPrimaryKey { get; set; }

        public ColumnAttribute(string name, bool isPrimaryKey)
        {
            this.Name = name;
            this.IsPrimaryKey = isPrimaryKey;
        }
    }
}