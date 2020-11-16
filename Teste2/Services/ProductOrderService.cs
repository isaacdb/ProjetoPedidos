using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste2.Data;
using Teste2.Models;
namespace Teste2.Services
{
    public class ProductOrderService
    {
        private readonly Teste2Context _context;
        public ProductOrderService(Teste2Context context)
        {
            _context = context;
        }
        public List<ProductOrder> FindAll()
        {
            return _context.ProductOrder.OrderBy(x => x.Id).ToList();
        }
    }
}
