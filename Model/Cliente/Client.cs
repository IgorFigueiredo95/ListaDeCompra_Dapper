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
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Email = email;
        }
        public Client(string nome, string sobrenome, string endereco, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Email = email;
        }


        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }
}
