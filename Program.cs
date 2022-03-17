using ListaDeCompraDapper.Command;
using ListaDeCompraDapper.DB;
using ListaDeCompraDapper.Model.Produto;
using ListaDeCompraDapper.Model.Cliente;
using System;
using System.Collections.Generic;
using ListaDeCompraDapper.View;
using System.Threading.Tasks;

namespace ListaDeCompraDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client;
            int tes;

            while (true)
            {
                client = NotLogged().Result;
                Console.Clear();
               tes = Logged(client).Result;

            }

        }
        public static async Task<Client> NotLogged()
        {
            Context context = new Context();
            string[] NotLoggedOptions = { "Criar usuário", "Acessar usuário", "Saber mais sobre o programa", "Sair" };
            string[] SaveClientPrompt = { "Informe o seu email", "Informe o seu primeiro nome", "Informe seu sobrenome", "Informe o seu endereço" };
            string Prompt = "Selecione utilizando as setas do teclado a opção desejada e tecle ENTER";

            Menu Menu = new Menu(NotLoggedOptions, Prompt);
            RecordMenu CadClientMenu = new RecordMenu(SaveClientPrompt);
            ClientCommand ClientCommand = new ClientCommand(new ClientRepository(context));

            int selectedOption = Menu.Run();

            Client LoggedUser;

            while (true)
            {
                if (selectedOption == 0)// criar cliente
                {
                    List<string> data = CadClientMenu.Run();
                    Client Client = new Client(data[1], data[2], data[3], data[0]);
                    var result = await ClientCommand.SaveClient(Client);

                    if (result.Success == false)//para refatoração, transformar em metodo de exibição de erros.
                    {
                        Console.WriteLine("Não foi possível cadastrar o usuário.\n");

                        foreach (var item in (List<string>)result.Data)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(item);
                        }
                        Console.ResetColor();

                        Console.WriteLine("\nPressione ENTER para tentar novamente ou ESC para voltar ao menu principal. ");

                        ConsoleKey pressed;// para refatoração, transformar em metodo de aguardar certas keys.

                        do
                        {
                            pressed = Console.ReadKey(true).Key;

                            if (pressed == ConsoleKey.Enter)
                            {
                                selectedOption = 0;
                                Console.Clear();
                                data.Clear();
                            }
                            else if (pressed == ConsoleKey.Escape)
                            {
                                data.Clear();
                                Console.Clear();
                                selectedOption = Menu.Run();
                            }
                        } while (pressed != ConsoleKey.Enter && pressed != ConsoleKey.Escape);



                    }
                    else if (result.Success == true)// para refatoração, TALVEZ transformar em metodo de exibição de sucesso e usar metodo de aguardar certas keys.
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nCliente Cadastrado com sucesso\n");
                        Console.ResetColor();
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey(true);
                        Console.Clear();
                        LoggedUser = Client;
                        break;

                    }
                }
                else if (selectedOption == 1)
                {
                    string[] PromptEmail = { "Insira o e-mail do usuário que deseja acessar a lista de compras:" };
                    RecordMenu GetClientMenu = new RecordMenu(PromptEmail);
                    List<string> email = GetClientMenu.Run();
                    var result = await ClientCommand.GetClient(email[0]);

                    if (result.Success == false)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nCliente não encontrado, verifique se o e-mail foi inserido corretamente.");
                        Console.ResetColor();
                        Console.WriteLine("\nPressione ENTER para tentar novamente, TAB para cadastrar um novo cliente ou ESC para voltar ao menu principal. ");

                        ConsoleKey pressedKey;

                        do
                        {
                            pressedKey = Console.ReadKey(true).Key;

                            if (pressedKey == ConsoleKey.Enter)
                            {
                                selectedOption = 1;
                                Console.Clear();
                            }
                            else if (pressedKey == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                selectedOption = Menu.Run();
                            }
                            else if (pressedKey == ConsoleKey.Tab)
                            {
                                selectedOption = 0;
                                Console.Clear();

                            }
                        } while (pressedKey != ConsoleKey.Enter && pressedKey != ConsoleKey.Escape && pressedKey != ConsoleKey.Tab);
                    }
                    else
                    {
                        Client Client = (Client)result.Data;

                        LoggedUser = Client;
                        break;
                    }

                }
                else if (true)
                {
                    Console.Clear();
                    KnowMore();
                    Console.Clear();
                    selectedOption = Menu.Run();
                }
                else if (selectedOption == 3)//sair
                {
                    Environment.Exit(0);
                }
            }
            return LoggedUser;
        }
        public static async Task<int> Logged(Client Client)
        {
            string[] LoggedOptions = { "Consultar lista de compras", "Cadastrar produto", "Deslogar do usuário", "Sair" };
            string Prompt = "Selecione utilizando as setas do teclado a opção desejada e tecle ENTER";
            string[] CadProdPrompt = { "Informe o nome do produto:", "Informe uma descrição para o item:" };
            Context loggedContext = new Context();
            ProductCommand productCommand = new ProductCommand(new ProductRepository(loggedContext));
            Menu loggedMenu = new Menu(LoggedOptions, Prompt, Client.email);
            int loggedSelectedOption = loggedMenu.Run();



            while (true)
            {
                if (loggedSelectedOption == 0)//consultar lista
                {

                    var result = await productCommand.GetProduct(Client);
                    List<Product> itens = (List<Product>)result.Data;
                    ListProductMenu listProductMenu = new ListProductMenu(itens, Prompt, Client.email);
                    Console.Clear();

                    if (itens.Count == 0)
                    {
                        Menu emptyMenu = new Menu(new string[] {"Nenhum produto cadastrado para o usuário"}, "Pressione ENTER para continuar", Client.email);
                        emptyMenu.Run();
                        Console.Clear();
                        loggedSelectedOption = loggedMenu.Run();
                    }
                    else
                    {
                        listProductMenu.Run();
                        Console.Clear();
                        loggedSelectedOption = loggedMenu.Run();// desenvolver metodos CRUD a partir daqui.
                    }

                }
                else if (loggedSelectedOption == 1)//cadastrar produto
                {
                    RecordMenu CadProdMenu = new RecordMenu(CadProdPrompt);
                    List<string> data = CadProdMenu.Run();
                    var result = await productCommand.SaveProduct(new Product(data[0], data[1], Client.id), Client);

                    if (result.Success == false)//para refatoração, transformar em metodo de exibição de erros.
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(result.Message);
                        Console.ResetColor();
                        foreach (var item in (List<string>)result.Data)
                        {
                            Console.WriteLine($"{item}\n");
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\n {result.Message}");
                        Console.ResetColor();
                        Console.WriteLine("\nPressione ENTER para continuar");

                        ConsoleKey KeyPressed;// para refatoração, transformar em metodo de aguardar certas keys.
                        do
                        {
                            KeyPressed = Console.ReadKey(true).Key;

                            if (KeyPressed == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                loggedSelectedOption = loggedMenu.Run();
                            }

                        } while (KeyPressed != ConsoleKey.Enter);
                    }

                }
                else if (loggedSelectedOption == 2)//deslogar usuário
                {
                    Console.Clear();
                    return 0;
                }
                else if (loggedSelectedOption == 3)//sair
                {
                    Environment.Exit(0);
                }
            }

        }
        public static void KnowMore()
        {

            Console.WriteLine(" Este é o meu primeiro projeto para o GitHub.\n A ideia deste programa era trabalhar conceitos como repository pattern, persistência de dados através do micro ORM Dapper, boas praticas básicas(nomeação de variáveis, métodos e estruturação do código), além de compreender o uso de interfaces na prática.\n O código atual não representa a versão final, o objetivo é refatorar este código conforme irei aprendendo novo conceitos e boas praticas na área de SOLID e clean code.\n");
            Console.WriteLine("Pressione ENTER para continuar");
            ConsoleKey pressed;// refatorar e mover para o metodo próprio de aguardar pressionado botão específico.
            do
            {
               pressed = Console.ReadKey(true).Key;

            } while (pressed != ConsoleKey.Enter);
        }
    }
}

