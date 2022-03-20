using Dapper;
using ListaDeCompraDapper.Model.Cliente;
using ListaDeCompraDapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.DB
{
    public class ClientRepository : IClientRepository //após implementar a interface, a abstração (o bruto do código) é criado
    {
        private readonly Context Context;
        public ClientRepository(Context context)
        {
            Context = context;
        }

        public async Task<Client> GetClientRepo(string email)//Executa um metodo assincrono que retorna uma task do tipo cliente
        {
            string sqlSelectClient = "SELECT * FROM CLIENTE WHERE email = @Email";
            var result = await Context.GetConnection().QueryAsync<Client>(sqlSelectClient, new { Email = email });

            return result.FirstOrDefault();
        }

        public async Task<(int id, bool success)> SaveClientRepo(Client client)// em caso de success = false, o id retornado é o do user já cadastrado
        {
            string SqlInsert = "INSERT INTO CLIENTE(nome,sobrenome,endereco,email) OUTPUT INSERTED.id values (@name, @surname, @address, @email)";// o "OUTPUT INSERTED.id" entre o INSERT e VALUES faz a query retornar o id da Row inserida
            string Sqlselect = "SELECT id FROM CLIENTE WHERE email = @email";// Kevão, eu realizado nessa classe uma nova consulta ao banco de dados diretamente ou utilizo o metodo já criado "getclient", minha pergunta é devido ao conceito DRY

            try
            {
                using (var connection = Context.GetConnection())
                {

                    var isExistValidation = await GetClientRepo(client.Email);
                    // conforme conversado com Kevão, pode chamar o metodo. Valida se já não foi cadastrado anteriormente
                    var transaction = connection.BeginTransaction();

                    if (isExistValidation == null)
                    {
                        var result = await connection.QueryAsync<int>(SqlInsert, new { name = client.Nome, surname = client.Sobrenome, address = client.Endereco, email = client.Email }, transaction);//, transaction: insertTransaction É usado Execute async pois ele retorna o número de colunas afetadas. o Query async espera retornar a pesquisa desejada. Simplificando, query Async é para select e execute é para insert, delete e update
                        transaction.Commit();

                        return (result.FirstOrDefault(), true);
                    }
                    else
                    {
                        return (isExistValidation.Id, false) ;
                    }

                }

            }
            catch (Exception ex)
            {
                Context.GetConnection().BeginTransaction().Rollback();//faz o rollback da mudança no database, *muito importante*
                throw new Exception(ex.Message); // desenhar uma exception personalizada para esse caso.
            }
        }
    }
}
