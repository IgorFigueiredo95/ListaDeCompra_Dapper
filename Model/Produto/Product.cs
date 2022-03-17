using Dapper;
using ListaDeCompraDapper.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.Model.Produto
{
    public class Product
    {
        public Product(string nome, string descricao, int id_cliente)
        {
            Nome = nome;
            Descricao = descricao;
            Id_cliente = id_cliente;
            DataAdicionado = DateTime.Now;
        }
        public Product(string nome, string descricao, int id_cliente, DateTime dataAdicionado)
        {
            Nome = nome;
            Descricao = descricao;
            Id_cliente = id_cliente;
            DataAdicionado = dataAdicionado;
        }


        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Id_cliente { get; set; }
        public DateTime DataAdicionado { get; set; }


    }
}
