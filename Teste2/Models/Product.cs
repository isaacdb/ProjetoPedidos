using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

        public Product()
        {
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public void AddProductOrder (ProductOrder pOrder)
        {
            ProductOrders.Add(pOrder);
        }
    }
}
