using ListaDeCompraDapper.Model.Cliente;
using ListaDeCompraDapper.Model.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Command.Data_Validation
{
    public class ProductValidation : IGenericDataValidation<Product>
    {
        private readonly Product Product;
        public ProductValidation(Product product)
        {
            Product = product;
        }
        public async Task<GenericCommandResult> ValidateAll()
        {
            bool ValidData = true;
            List<String> ValidationError = new List<string>();

            #region Data Validation
            
            if (String.IsNullOrEmpty(Product.Nome))
            {
                ValidationError.Add("O nome do produto é inválido");
                ValidData = false;
            }
            if (String.IsNullOrEmpty(Product.Descricao))
            {
                ValidationError.Add("A descrição do produto é inválida");
                ValidData = false;
            }
            if (Product.Id_cliente == null)
            {
                ValidationError.Add("Nenhum id de cliente associado ao produto");
                ValidData = false;
            }
            #endregion

            if (ValidData == true)
            {
                return new GenericCommandResult(true, "Valores inseridos válidos", null);
            }
            else
            {
                return new GenericCommandResult(false, "um ou mais valores inseridos não são válidos", ValidationError);
            }
        }
    }
}
