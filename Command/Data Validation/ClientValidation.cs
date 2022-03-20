using ListaDeCompraDapper.Model.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Command.Data_Validation
{
    public class ClientValidation : IGenericDataValidation<Client>
    {
        private readonly Client Client;

        public ClientValidation(Client client)
        {
            Client = client;
        }

        public async Task<GenericCommandResult> ValidateAll()
        {
            List<string> ValidationError = new List<string>();
            bool ValidData = true;

            #region Validation data

            if (String.IsNullOrEmpty(Client.Nome) || Client.Nome.Length >30)
            {
                ValidationError.Add("O nome inserido é inválido, informe outro nome.");
                ValidData = false;
            }

            if (String.IsNullOrEmpty(Client.Sobrenome) || Client.Sobrenome.Length > 30)
            {
                ValidationError.Add("O sobrenome inserido é inválido, informe outro sobrenome.");
                ValidData = false;
            }
            if (String.IsNullOrEmpty(Client.Endereco) || Client.Endereco.Length > 40)
            {
                ValidationError.Add("O Endereço inserido é inválido, informe outro Endereço.");
                ValidData = false;
            }

            string[] EmailValidation = Client.Email.Split('@');
           

            if (EmailValidation.Length == 1 || EmailValidation.Length > 2)// a validação não está completa, caracteres especiais passariam por essa validação
            {
                ValidationError.Add("O email inserido é inválido, informe outro email.");
                
                ValidData = false;
            }
            else if(Client.Email.Length > 40)
            {
                ValidationError.Add("O email inserido é muito grande, informe outro email.");

                ValidData = false;
            }
            #endregion

            if (ValidData == true)
            {
                return new GenericCommandResult(true, "Valores inseridos válidos", null);
            }
            else
            {
                return new GenericCommandResult(false, "um dos valores não é valido", ValidationError);
            }
        }
    }
}
