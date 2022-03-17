using ListaDeCompraDapper.Model.Cliente;
using ListaDeCompraDapper.Model.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductRepo(Client client);
        public Task<int> SaveProductRepo(Product product);
    }
}
