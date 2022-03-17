using ListaDeCompraDapper.Model.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Repository
{
    public interface IClientRepository
    {
        public Task<Client> GetClientRepo(string email);
        public Task<(int id, bool success)> SaveClientRepo(Client client);
    }
}
