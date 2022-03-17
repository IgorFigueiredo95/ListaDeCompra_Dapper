using ListaDeCompraDapper.Model.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.View
{
    public class RecordMenu : Helper
    {
        private string[] PromptOptions;
        private List<string> PreviousAnswers;
        private string CurrentAnswer;

        public RecordMenu(string[] prompOptions)
        {
            PromptOptions = prompOptions;
            PreviousAnswers = new List<string>();
        }

        private void Display(List<string> answeredVal)
        {
            Console.Clear();
            DisplayTitle();
            for (int i = 0; i < answeredVal.Count; i++)// Verificar possibilidade de fazer método para controlar a seleção, usado mais de uma vez, lembre-se do DRYs
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(PromptOptions[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(answeredVal[i]);
            }
            Console.ResetColor();
        }
        public List<string> Run()
        {
            foreach (string currentQuestion in PromptOptions)
            {
                Display(PreviousAnswers);
                Console.WriteLine(currentQuestion);
                CurrentAnswer = Console.ReadLine();

                while (string.IsNullOrEmpty(CurrentAnswer))
                {
                    Display(PreviousAnswers);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nO valor informado é invalido. Insira um valor válido.");
                    Console.ResetColor();
                    Console.WriteLine($"\n{currentQuestion}");
                    CurrentAnswer = Console.ReadLine();

                }
                PreviousAnswers.Add(CurrentAnswer);
            }
            return PreviousAnswers;
        }
    }
}
