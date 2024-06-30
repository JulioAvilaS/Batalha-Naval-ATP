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
            Console.WriteLine("Olá, jogador! Para iniciar o jogo, primeiro informe o seu nome completo: \n");
            string nomeCompleto = Console.ReadLine();

            // Criação dos jogadores
            JogadorHumano player = new JogadorHumano(10, 10, nomeCompleto); // Cria jogador humano
            JogadorComputador maquina = new JogadorComputador(10, 10); // Cria jogador computador


            maquina.AdicionarEmbarcacao();
            maquina.ImprimirTabuleiroJogador();

            // Loop para adicionar embarcações ao jogador humano
                for (int n = 0; n < 3; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Submarino {n + 1}:");
                    Console.WriteLine("\nInforme a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nInforme a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                    // Criação da embarcação
                    Embarcacao embarcacao = new Embarcacao("Submarino", 1); // Exemplo de embarcação com nome "Navio" e tamanho 1
                    Posicao p = new Posicao(linha - 1, coluna - 1);

                    // Adiciona a embarcação ao jogador humano
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; // Decrementa para tentar adicionar a mesma embarcação novamente
                    }
                }
                Console.WriteLine("\nSeu tabuleiro:");
                player.ImprimirTabuleiroJogador();

                for (int n = 0; n < 2; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Hidroavião {n + 1}:");
                    Console.WriteLine("\nInforme a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nInforme a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                    // Criação da embarcação
                    Embarcacao embarcacao = new Embarcacao("Hidroavião", 2); // Exemplo de embarcação com nome "Navio" e tamanho 1
                    Posicao p = new Posicao(linha - 1, coluna - 1);

                    // Adiciona a embarcação ao jogador humano
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; // Decrementa para tentar adicionar a mesma embarcação novamente
                    }

                }
                Console.WriteLine("\nSeu tabuleiro:");
                player.ImprimirTabuleiroJogador();
                for (int n = 0; n < 2; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Cruzador {n + 1}:");
                    Console.WriteLine("\nInforme a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nInforme a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                    // Criação da embarcação
                    Embarcacao embarcacao = new Embarcacao("Cruzador", 3); // Exemplo de embarcação com nome "Navio" e tamanho 1
                    Posicao p = new Posicao(linha -1, coluna-1);

                    // Adiciona a embarcação ao jogador humano
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; // Decrementa para tentar adicionar a mesma embarcação novamente
                    }

                }
                Console.WriteLine("\nSeu tabuleiro:");
                player.ImprimirTabuleiroJogador();
                for (int n = 0; n < 1; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Encouraçado {n + 1}:");
                    Console.WriteLine("\nInforme a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nInforme a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                    // Criação da embarcação
                    Embarcacao embarcacao = new Embarcacao("Encouraçado", 4); // Exemplo de embarcação com nome "Navio" e tamanho 1
                    Posicao p = new Posicao(linha - 1, coluna - 1);

                    // Adiciona a embarcação ao jogador humano
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; // Decrementa para tentar adicionar a mesma embarcação novamente
                    }

                }
                Console.WriteLine("\nSeu tabuleiro:");
                player.ImprimirTabuleiroJogador();
                for (int n = 0; n < 1; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Porta-aviões {n + 1}:");
                    Console.WriteLine("\nInforme a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nInforme a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                    // Criação da embarcação
                    Embarcacao embarcacao = new Embarcacao("Porta-aviões", 5); // Exemplo de embarcação com nome "Navio" e tamanho 1
                    Posicao p = new Posicao(linha - 1, coluna - 1);

                    // Adiciona a embarcação ao jogador humano
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; // Decrementa para tentar adicionar a mesma embarcação novamente
                    }

                }
                Console.WriteLine("Seu tabuleiro:");
                player.ImprimirTabuleiroJogador();

            //Jogo rodando
            do {


                bool acertou;

                //loop de tiros jogador humano
                do
                {
                    bool valid;
                    Posicao tiro;

                    do
                    {
                        Console.WriteLine("\nTabuleiro do jogador máquina:");
                        maquina.ImprimirTabuleiroAdversario();

                        Console.WriteLine($"\nVez do jogador {player.Nickname}");
                        Console.WriteLine("\nInforme a linha do tiro:");
                        int linhaTiro = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nInforme a coluna do tiro:");
                        int colunaTiro = int.Parse(Console.ReadLine());

                        tiro = new Posicao(linhaTiro -1, colunaTiro -1);
                        valid = player.EscolherAtaque(tiro);

                        if (!valid)
                        {
                            Console.WriteLine("\nPosição inválida!");
                        }

                    } while (!valid);

                    // Realiza o ataque do jogador humano
                    acertou = maquina.ReceberAtaque(tiro);
                    if (acertou)
                    {
                        Console.WriteLine("\nVocê acertou um navio!");
                        player.Pontuacao++;
                    }
                    else
                    {
                        Console.WriteLine("\nTiro na água.");
                    }

                    player.NumTirosDados++;

                    // Exibe tabuleiros após o tiro do jogador humano
                    
                    

                }
                while (player.Pontuacao < 22 && acertou); // Exemplo de limite de 22 tiros


                //loop de ataque do jogador maquina
                do
                {
                    Console.WriteLine($"\nTabuleiro do jogador {player.Nickname}:");
                    player.ImprimirTabuleiroAdversario();

                    // Vez do jogador computador
                    Console.WriteLine("Vez do jogador computador: \n");
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
                    
                }
                while (maquina.Pontuacao < 22 && acertou);

            } while (maquina.Pontuacao < 22);

            if (player.Pontuacao == 22)
            {
                Console.WriteLine($"O jogador {player.Nickname} ganhou!!!");
            }
            else if (maquina.Pontuacao == 22)
            {
                Console.WriteLine($"O jogador computador ganhou!!!");
            }

            // Fim do jogo
            Console.WriteLine("Fim do jogo!");
            Console.ReadLine();
        }
    }
}
