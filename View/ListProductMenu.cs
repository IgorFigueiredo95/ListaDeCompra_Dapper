using ListaDeCompraDapper.Model.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.View
{
    public class ListProductMenu: Helper
    {
        private List<Product> Products;
        private int SelectIndex;
        private string Prompt;
        private string LoggedEmail = "";

        public ListProductMenu(List<Product> products, string prompt, string email)
        {
            Products = products;
            Prompt = prompt;
            SelectIndex = 0;
            LoggedEmail = email;
        }

        private void DisplayMenu()
        {
                DisplayTitle(LoggedEmail);

            Console.WriteLine($"{Prompt} \n");
            string selection;
            var ProductsArray = Products.ToArray();
            for (int i = 0; i < ProductsArray.Length; i++)
            {
                string currentOption = $"{ProductsArray[i].Nome} {ProductsArray[i].Descricao} {ProductsArray[i].DataAdicionado}";
                if (i == SelectIndex)
                {
                    selection = "*";
                    Console.BackgroundColor = ConsoleColor.Gray;// altera cor do fundo
                    Console.ForegroundColor = ConsoleColor.Black;// alterar cor do texto

                }
                else
                {
                    selection = " ";
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($" {selection} {currentOption} ");
                Console.ResetColor();

            }
        }
        public int Run()
        {


            ConsoleKeyInfo LoggedKeyPressed;
            var ProductsArray = Products.ToArray();
            DisplayMenu();
            
            do
            {
                LoggedKeyPressed = Console.ReadKey(true);
                if (LoggedKeyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (SelectIndex == 0)
                        SelectIndex = ProductsArray.Length - 1;
                    else
                        SelectIndex--;
                }
                else if (LoggedKeyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (SelectIndex == ProductsArray.Length - 1)
                        SelectIndex = 0;
                    else
                        SelectIndex++;
                }
                Console.Clear();
                DisplayMenu();

            } while (LoggedKeyPressed.Key != ConsoleKey.Enter);

            return SelectIndex;

        }
    }
}
