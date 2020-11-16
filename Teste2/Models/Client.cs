using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste2.Models
{    public enum KindPerson : int
    {
        Juridica,
        Fisica
    }
    public class Client
    {
        public int Id { get; set; }
        public KindPerson KindPerson { get; set; }
        public string Identify { get; set; }
        public string Name { get; set; }
        public DateTime BithDate { get; set; }
        public ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();

        public Client()
        {
        }

        public Client(KindPerson kindPerson, string identify, string name, DateTime bithDate)
        {
            KindPerson = kindPerson;
            Identify = identify;
            Name = name;
            BithDate = bithDate;
        }
        public void AddOrder(ClientOrder order)
        {
            ClientOrders.Add(order);
        }
        public void RemoveOrder(ClientOrder order)
        {
            ClientOrders.Remove(order);
        }
        public double TotalOrders()
        {
            return ClientOrders.Sum(s => s.TotalClientOrder());
        }
    }
}
