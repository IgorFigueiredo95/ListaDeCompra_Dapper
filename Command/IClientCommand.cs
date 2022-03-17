using ListaDeCompraDapper.Model.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Command
{
    public interface IClientCommand
    { 
       public Task<GenericCommandResult> GetClient(string email);
       public Task<GenericCommandResult> SaveClient(Client Client);
    }
}
