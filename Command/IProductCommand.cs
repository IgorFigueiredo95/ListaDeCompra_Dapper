using ListaDeCompraDapper.Model.Cliente;
using ListaDeCompraDapper.Model.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Command
{
   public interface IProductCommand
    {
        public Task<GenericCommandResult> GetProduct(Client Client);
        public Task<GenericCommandResult> SaveProduct(Product Product, Client Client);
    }
}
