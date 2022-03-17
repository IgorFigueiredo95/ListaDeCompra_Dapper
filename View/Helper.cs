using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.View
{
    public abstract class Helper
    {
        private string[] Title { get; } = {" __________________________________________________________________",
"| ┬  ┬┌─┐┌┬┐┌─┐  ┌┬┐┌─┐  ╔═╗┌─┐┌┬┐┌─┐┬─┐┌─┐┌─┐  ╔╦╗┌─┐┌─┐┌─┐┌─┐┬─┐ |",
"| │  │└─┐ │ ├─┤   ││├┤   ║  │ ││││├─┘├┬┘├─┤└─┐   ║║├─┤├─┘├─┘├┤ ├┬┘ |",
"| ┴─┘┴└─┘ ┴ ┴ ┴  ─┴┘└─┘  ╚═╝└─┘┴ ┴┴  ┴└─┴ ┴└─┘  ═╩╝┴ ┴┴  ┴  └─┘┴└─ |",
"|_______________________________________Github: IgorFigueiredo95___|",
"                                                                    "};//Ascii gerado em https://patorjk.com/software/taag/
        //após implementar o título ascii, aprendi que colocando um @ antes da string é possível inserir uma string de múltiplas linhas. evitando a complexida do método DisplayTitle
        //public string UserLogged { get; private set; }
        private string[] LoggedTitle { get; } ={" __________________________________________________________________",
"| ┬  ┬┌─┐┌┬┐┌─┐  ┌┬┐┌─┐  ╔═╗┌─┐┌┬┐┌─┐┬─┐┌─┐┌─┐  ╔╦╗┌─┐┌─┐┌─┐┌─┐┬─┐ |",
"| │  │└─┐ │ ├─┤   ││├┤   ║  │ ││││├─┘├┬┘├─┤└─┐   ║║├─┤├─┘├─┘├┤ ├┬┘ |",
"| ┴─┘┴└─┘ ┴ ┴ ┴  ─┴┘└─┘  ╚═╝└─┘┴ ┴┴  ┴└─┴ ┴└─┘  ═╩╝┴ ┴┴  ┴  └─┘┴└─ |",
"|_______________________________________Github: IgorFigueiredo95___|",
"                                                                    ",
"Logado como: {0}\n"};
        protected void DisplayTitle()
        {
            int index = 0;
            do
            {
                Console.WriteLine(Title[index]);
                index++;
            } while (index < Title.Length);
        }
        protected void DisplayTitle(string Email)
        {
            int index = 0;
            do
            {
                Console.WriteLine(LoggedTitle[index],Email);
                index++;
            } while (index < LoggedTitle.Length);
        }
        //        public void GenerateMaze() //ideia para próximo projeto https://www.dcode.fr/maze-generator
        //        {
        //            Console.WriteLine(@"
        //   ██████████████████████████████████████████████████████████
        //               █           █                 █        █     █
        //█  █  ████  █  ███████  ██████████  █  ██████████  ████  ████
        //█  █  █     █  █        █  █     █  █     █        █        █
        //█  █  ████  ████  ████  █  ████  ████  ████  ████  █  ███████
        //█  █  █  █     █  █                          █              █
        //████  █  ███████████████████  ██████████  ████  █  ██████████
        //█  █  █        █     █  █        █  █  █  █  █  █           █
        //█  █  █  ████  █  ████  █  █  ████  █  █  █  █  ████  ███████
        //█  █        █        █     █  █        █     █  █  █  █     █
        //█  ███████  ████  █  ████  █  █  ████████████████  █  █  █  █
        //█              █  █  █     █  █  █  █  █  █  █  █        █  █
        //████  ████  ███████  ███████  █  █  █  █  █  █  █  ███████  █
        //█     █        █     █     █  █  █  █  █  █     █     █     █
        //███████████████████  █  █  █  █  █  █  █  ████  ████  █  █  █
        //█     █  █     █     █  █  █                    █     █  █  █
        //█  ████  █  ███████  █  ██████████  █  ███████  ██████████  █
        //█           █  █              █  █  █  █  █        █        █
        //█  █  ████  █  █  █  █  █  █  █  █  ████  ███████  █  █  ████
        //█  █     █        █  █  █  █                    █  █  █     
        //██████████████████████████████████████████████████████████  
        //");
        //        }
    }
}
