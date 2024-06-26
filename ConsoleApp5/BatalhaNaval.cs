using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp5
{
    internal class BatalhaNaval
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, jogador! Para iniciar o jogo, primeiro informe o seu nome completo:");
           
            JogadorHumano player = new JogadorHumano(10, 10, nomeCompleto);
        }
    }
}
