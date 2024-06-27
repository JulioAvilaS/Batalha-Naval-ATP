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
            string nomeCompleto = Console.ReadLine();
           
            JogadorHumano player = new JogadorHumano(10, 10, nomeCompleto);
            JogadorComputador maquina = new JogadorComputador(10, 10);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Escolha a posição do ");
            }















        }
    }
}
