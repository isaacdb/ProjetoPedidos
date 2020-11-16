using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste2.Data;
using Teste2.Models;
namespace Teste2.Services
{
    public class ProductService
    {
        private readonly Teste2Context _context;
        public ProductService(Teste2Context context)
        {
            _context = context;
        }
        public List<Product> FindAll()
        {
            return _context.Product.OrderBy(x => x.Id).ToList();
        }
    }
}
