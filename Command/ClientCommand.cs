using System.Collections.Generic;
using System.Threading.Tasks;
using ListaDeCompraDapper.Command.Data_Validation;
using ListaDeCompraDapper.Model.Cliente;
using ListaDeCompraDapper.Repository;

namespace ListaDeCompraDapper.Command
{
    public class ClientCommand : IClientCommand
    {
        private readonly IClientRepository ClientRepository;
        private IGenericDataValidation<Client> Validation;
        private readonly Client Client;

        public ClientCommand(IClientRepository clientRepository)
        {
            ClientRepository = clientRepository;
        }

        public async Task<GenericCommandResult> GetClient(string email)
        {
            Client result = await ClientRepository.GetClientRepo(email);
            if (result != null)
            {
                return new GenericCommandResult(true, "Consulta retornada com sucesso", result);
            }
            else
            {
                return new GenericCommandResult(false, "Consulta não retornou valor", result);
            }
                
        }
        public async Task<GenericCommandResult> SaveClient(Client Client)
        {
            Validation = new ClientValidation(Client);
            var IsValid = await Validation.ValidateAll();

            (int id, bool success) res = await ClientRepository.SaveClientRepo(Client);

            if (IsValid.Success)
            {
                if (res.success == false)
                {
                    List<string> error = new List<string>();
                    error.Add($"O email {Client.email} já está cadastrado no sistema.");
                    return new GenericCommandResult(false, "Cliente já cadastrado no sistema.", error);
                }
                else
                {
                    return new GenericCommandResult(true, "Cliente Cadastrado com sucesso.", res.id);
                }
            }
            else
            {
                return new GenericCommandResult(false, "Os dados do cliente não são válidos", IsValid.Data);
            }
        }

    }
}
