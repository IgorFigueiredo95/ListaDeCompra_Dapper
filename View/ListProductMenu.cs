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
        private const int ColumnSize = -30;
        private string[] Headers = new string[3];

        public ListProductMenu(List<Product> products, string prompt, string email, string[] headers)
        {
            Products = products;
            Prompt = prompt;
            SelectIndex = 0;
            LoggedEmail = email;
            Headers = headers;
        }

        private void DisplayMenu()
        {
                DisplayTitle(LoggedEmail);

            Console.WriteLine($"{Prompt} \n");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  |{Headers[0],ColumnSize} | {Headers[1],ColumnSize} | {Headers[2],ColumnSize+10}|");
            var ProductsArray = Products.ToArray();
            string selection;

            for (int i = 0; i < ProductsArray.Length; i++)
            {
                string prodName = ReturnValidSize(ProductsArray[i].Nome, ColumnSize);
                string prodDescription = ReturnValidSize(ProductsArray[i].Descricao, ColumnSize);

                string currentOption = $"{prodName,ColumnSize} | {prodDescription,ColumnSize} | {ProductsArray[i].DataAdicionado,ColumnSize+10}|";


                if (i == SelectIndex)
                {
                    selection = "=>";
                    Console.BackgroundColor = ConsoleColor.Gray;// altera cor do fundo
                    Console.ForegroundColor = ConsoleColor.Black;// alterar cor do texto

                }
                else
                {
                    selection = "  ";
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"{selection}|{currentOption}");
                Console.ResetColor();

            }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  |{"",ColumnSize} | {"",ColumnSize} | {"",ColumnSize+10}|");
            Console.ResetColor();
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
        private string ReturnValidSize(string data, int size)
        {
            size = Math.Abs(size);
            int sizeData = data.Length;
            string output="";
            if (sizeData > size)
            {
                for (int i = 0; i < size-3; i++)
                {
                    output += data[i];
                }
                output += "...";
            }
            else
            {
                output = data;
            }
            return output;
        }
        
    }
}
