using System;

namespace CqlQueryBuilder.Console.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public DateTime Registered { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Enabled { get; set; }
    }
}