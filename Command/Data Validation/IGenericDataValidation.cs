using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Command.Data_Validation
{
    public interface IGenericDataValidation<T>
    {
        public Task<GenericCommandResult> ValidateAll();

    }
}
