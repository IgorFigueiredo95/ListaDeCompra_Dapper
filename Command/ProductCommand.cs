using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaDeCompraDapper.Model.Produto;
using ListaDeCompraDapper.Model.Cliente;
using ListaDeCompraDapper.Repository;
using ListaDeCompraDapper.Command.Data_Validation;

namespace ListaDeCompraDapper.Command
{
    public class ProductCommand : IProductCommand
    {
        private readonly IProductRepository ProductRepository;
        private IGenericDataValidation<Product> Validation;
        public ProductCommand(IProductRepository productRepository)
        {  
            ProductRepository = productRepository;
        }

        public async Task<GenericCommandResult> GetProduct(Client Client)
        {
            var result = await ProductRepository.GetProductRepo(Client);
            if (result != null)
            {
                return new GenericCommandResult(true, "Produtos localizados com sucesso", result);
            }
            return new GenericCommandResult(false, "Nenhum produto encontrado", result);
        }
        public async Task<GenericCommandResult> SaveProduct(Product Product, Client Client)
        {
            Product.Id_cliente = Client.Id;
            Validation = new ProductValidation(Product);
            var IsValid = await Validation.ValidateAll();

            if (IsValid.Success)
            {
                int resultId = await ProductRepository.SaveProductRepo(Product);
                
                    return new GenericCommandResult(true, "Cadastrado com sucesso", resultId);
            }
            else
            {
                return new GenericCommandResult(false, "Os dados do Produto não são válidos", IsValid.Data);
            }
        }
    }
}
