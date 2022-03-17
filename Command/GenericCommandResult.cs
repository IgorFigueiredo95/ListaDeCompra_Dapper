using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Command
{
    public class GenericCommandResult
    {
        public GenericCommandResult(bool success, string message, object data)//controla como o objeto  é construido
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }//O que retorna do banco é um objeto
        
    }
}
