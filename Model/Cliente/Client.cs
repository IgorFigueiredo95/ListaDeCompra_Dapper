using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ListaDeCompraDapper.DB;
using ListaDeCompraDapper.Model.Produto;

namespace ListaDeCompraDapper.Model.Cliente
{
    public class Client
    {
        public Client(int id, string nome, string sobrenome, string endereco, string email)
        {
            this.id = id;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.endereco = endereco;
            this.email = email;
        }
        public Client(string nome, string sobrenome, string endereco, string email)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.endereco = endereco;
            this.email = email;
        }


        public int id { get; set; }
        public string nome{ get; set; }
        public string sobrenome { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
    }
}
