using CqlQueryBuilder.TypeConversion;
using System.Collections.Generic;
using System.Linq;

namespace CqlQueryBuilder.Utils
{
    public static class ObjectExtensions
    {
        public static string GetAllValuesOfPropertiesWithComma(this object obj) =>
            string.Join(", ", obj.GetType().GetProperties()
                .Select(x => GetProperlyValue(x.GetValue(obj, null))));

        private static string GetProperlyValue(object value) =>
            TypeConverter.ConvertToDbType(value);

    }
}