
using System.Collections.Generic;


namespace Teste2.Models.ViewModels
{
    public class ClientOrderFormViewModel
    {
        public ClientOrder ClientOrder { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
