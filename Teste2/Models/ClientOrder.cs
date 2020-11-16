using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste2.Models
{
    public class ClientOrder
    {
        public int Id { get; set; }
        public DateTime DateClientOrder { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }

        public ClientOrder()
        {
        }

        public ClientOrder(DateTime dateClientOrder, Client client)
        {
            DateClientOrder = dateClientOrder;
            Client = client;
        }
        public double TotalClientOrder()
        {
            return ProductOrders.Sum(s => s.TotalPrice());
        }
    }
}
