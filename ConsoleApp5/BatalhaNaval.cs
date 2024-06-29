using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class BatalhaNaval
    {
        static void Main(string[] args)
        {
            // Solicita o nome do jogador
            Console.WriteLine("Olá, jogador! Para iniciar o jogo, primeiro informe o seu nome completo:");
            string nomeCompleto = Console.ReadLine();

            // Criação dos jogadores
            JogadorHumano player = new JogadorHumano(10, 10, nomeCompleto); // Cria jogador humano
            JogadorComputador maquina = new JogadorComputador(10, 10); // Cria jogador computador

            // Loop para adicionar embarcações ao jogador humano
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Escolha a posição da {i + 1}ª embarcação:");
                Console.WriteLine("Informe a linha:");
                int linha = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a coluna:");
                int coluna = int.Parse(Console.ReadLine());

                // Criação da embarcação
                Embarcacao embarcacao = new Embarcacao("Navio", 1); // Exemplo de embarcação com nome "Navio" e tamanho 1
                Posicao p = new Posicao(linha,coluna);

                // Adiciona a embarcação ao jogador humano
                bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                if (adicionado)
                {
                    Console.WriteLine("Embarcação adicionada com sucesso!");
                }
                else if (!adicionado)
                {
                    Console.WriteLine("Não foi possível adicionar a embarcação. Tente novamente.");
                    i--; // Decrementa para tentar adicionar a mesma embarcação novamente
                }
            }

            bool acertou;

            // Exemplo de jogo: loop de tiros
            do
            {
                bool valid;
                Posicao tiro;

                do
                {        
                        Console.WriteLine("Vez do jogador humano:");
                        Console.WriteLine("Informe a linha do tiro:");
                        int linhaTiro = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe a coluna do tiro:");
                        int colunaTiro = int.Parse(Console.ReadLine());

                        tiro = new Posicao(linhaTiro, colunaTiro);
                        valid = player.EscolherAtaque(tiro);

                    if(!valid)
                    {
                        Console.WriteLine("Posição inválida!");
                    }

                }

                while (!valid);

                    // Realiza o ataque do jogador humano
                    acertou = maquina.ReceberAtaque(tiro);
                    if (acertou)
                    {
                        Console.WriteLine("Você acertou um navio!");
                    player.Pontuacao++;
                    }
                    else
                    {
                        Console.WriteLine("Tiro na água.");
                    }

                player.NumTirosDados++;

                    // Exibe tabuleiros após o tiro do jogador humano
                    Console.WriteLine("Seu tabuleiro:");
                    player.ImprimirTabuleiroJogador();
                    Console.WriteLine("Tabuleiro do adversário:");
                    maquina.ImprimirTabuleiroAdversario();

            }
            while (player.Pontuacao < 22 && acertou); // Exemplo de limite de 22 tiros

            do
            {
                // Vez do jogador computador
                Console.WriteLine("Vez do jogador computador:");
                Posicao tiroComputador = maquina.EscolherAtaque();

                // Realiza o ataque do jogador computador
               acertou = player.ReceberAtaque(tiroComputador);
                if (acertou)
                {
                    Console.WriteLine("O computador acertou um navio!");
                    maquina.Pontuacao++;
                }
                else
                {
                    Console.WriteLine("Tiro do computador na água.");
                }

                maquina.NumTirosDados++;

                // Exibe tabuleiros após o tiro do jogador computador
                Console.WriteLine("Seu tabuleiro:");
                player.ImprimirTabuleiroJogador();
                Console.WriteLine("Tabuleiro do adversário:");
                maquina.ImprimirTabuleiroAdversario();
            } 
            while (maquina.Pontuacao < 22 && acertou);


            // Fim do jogo
            Console.WriteLine("Fim do jogo!");
            Console.ReadLine();
        }
    }
}
