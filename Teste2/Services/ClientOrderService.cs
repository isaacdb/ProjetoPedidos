using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste2.Data;
using Teste2.Models;

namespace Teste2.Services
{
    public class ClientOrderService
    {
        private readonly Teste2Context _context;
        public ClientOrderService(Teste2Context context)
        {
            _context = context;
        }
        public List<ClientOrder> FindAll()
        {
            return _context.ClientOrder.OrderBy(x => x.DateClientOrder).ToList();
        }
    }
}
