using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste2.Data;
using Teste2.Models;

namespace Teste2.Services
{
    public class ClientService
    {
        private readonly Teste2Context _context;
        public ClientService (Teste2Context context)
        {
            _context = context;
        }

        public List<Client> FindAll()
        {
            return _context.Client.OrderBy(x => x.Name).ToList();
        }
    }
}
