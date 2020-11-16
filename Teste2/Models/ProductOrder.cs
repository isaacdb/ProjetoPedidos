using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste2.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ClientOrder ClientOrder { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int ClientOrderId { get; set; }

        public ProductOrder()
        {
        }

        public ProductOrder(int quantity, ClientOrder clientOrder, Product product)
        {
            Quantity = quantity;
            ClientOrder = clientOrder;
            Product = product;
            Product.AddProductOrder(this);
        }
        public double TotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
