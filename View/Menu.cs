using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.View
{
    public class Menu : Helper
    {
        private string[] Options;
        private int SelectIndex;
        private string Prompt;
        private string LoggedEmail = "";

        public Menu(string[] options, string prompt)
        {
            Options = options;
            Prompt = prompt;
            SelectIndex = 0;
        }
        public Menu(string[] options, string prompt, string email)
        {
            Options = options;
            Prompt = prompt;
            SelectIndex = 0;
            LoggedEmail = email;
        }

        private void DisplayMenu()
        {
            if (LoggedEmail == "")
                DisplayTitle();
            else
                DisplayTitle(LoggedEmail);

            Console.WriteLine($"{Prompt} \n");
            string selection;

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
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

            ConsoleKeyInfo KeyPressed;
            DisplayMenu();
            do
            {
                KeyPressed = Console.ReadKey(true);

                if (KeyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (SelectIndex == 0)
                        SelectIndex = Options.Length - 1;
                    else
                        SelectIndex--;
                }
                else if (KeyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (SelectIndex == Options.Length - 1)
                        SelectIndex = 0;
                    else
                        SelectIndex++;
                }

                Console.Clear();
                DisplayMenu();

            } while (KeyPressed.Key != ConsoleKey.Enter);

            return SelectIndex;

        }


    }
}

