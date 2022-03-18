using Dapper;
using ListaDeCompraDapper.Model.Cliente;
using ListaDeCompraDapper.Model.Produto;
using ListaDeCompraDapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.DB
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context Context;

        public ProductRepository(Context context)
        {
            Context = context;
        }

        public async Task<List<Product>> GetProductRepo(Client client)
        {
            string SqlSelect = "SELECT nome, descricao, id_cliente, dataAdicionado  FROM PRODUTOS WHERE id_cliente = @idCliente";
            var result = await Context.GetConnection().QueryAsync<Product>(SqlSelect, new { idCliente = client.id });
            return result.ToList();
        }
        public async Task<int> SaveProductRepo(Product product)
        {
            string SqlInsert = "INSERT INTO PRODUTOS(nome, descricao, id_cliente, dataAdicionado) OUTPUT INSERTED.id VALUES (@nome, @descricao, @id_cliente, @dataAdicionado)";

            using (var connection = Context.GetConnection())
            {
                try
                {
                    var transaction = connection.BeginTransaction();
                    var result = await connection.QueryAsync<int>(SqlInsert, new { nome = product.Nome, descricao = product.Descricao, id_cliente = product.Id_cliente, dataAdicionado = product.DataAdicionado }, transaction);
                    transaction.Commit();

                    product.id = result.FirstOrDefault();
                    return product.id;
                }
                catch (Exception ex)
                {
                    Context.GetConnection().BeginTransaction().Rollback();
                    throw new Exception(ex.Message);

                }
            }
        }
    }
}
