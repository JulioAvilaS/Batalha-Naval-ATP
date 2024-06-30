using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            maquina.AdicionarEmbarcacao();

            
                for (int n = 0; n < 3; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Submarino {n + 1}:");
                    Console.WriteLine("Informe a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                    
                    Embarcacao embarcacao = new Embarcacao("Submarino", 1); 
                    Posicao p = new Posicao(linha - 1, coluna - 1);

                   
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--;
                    }
                }
                Console.WriteLine("Seu tabuleiro:");
                player.ImprimirTabuleiroJogador();

                for (int n = 0; n < 2; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Hidroavião {n + 1}:");
                    Console.WriteLine("Informe a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                   
                    Embarcacao embarcacao = new Embarcacao("Hidroavião", 2);
                    Posicao p = new Posicao(linha - 1, coluna - 1);

                    
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; 
                    }

                }
                Console.WriteLine("Seu tabuleiro:");
                player.ImprimirTabuleiroJogador();
                for (int n = 0; n < 2; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Cruzador {n + 1}:");
                    Console.WriteLine("Informe a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                    
                    Embarcacao embarcacao = new Embarcacao("Cruzador", 3);
                    Posicao p = new Posicao(linha -1, coluna-1);

                   
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; 
                    }

                }
                Console.WriteLine("Seu tabuleiro:");
                player.ImprimirTabuleiroJogador();
                for (int n = 0; n < 1; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Encouraçado {n + 1}:");
                    Console.WriteLine("Informe a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                    
                    Embarcacao embarcacao = new Embarcacao("Encouraçado", 4); 
                    Posicao p = new Posicao(linha - 1, coluna - 1);

                
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; 
                    }

                }
                Console.WriteLine("Seu tabuleiro:");
                player.ImprimirTabuleiroJogador();
                for (int n = 0; n < 1; n++)
                {
                    Console.WriteLine($"\nEscolha a posição do Porta-aviões {n + 1}:");
                    Console.WriteLine("Informe a linha:");
                    int linha = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe a coluna:");
                    int coluna = int.Parse(Console.ReadLine());

                   
                    Embarcacao embarcacao = new Embarcacao("Porta-aviões", 5);
                    Posicao p = new Posicao(linha - 1, coluna - 1);

                   
                    bool adicionado = player.AdicionarEmbarcacao(embarcacao, p);
                    if (adicionado)
                    {
                        Console.WriteLine("\nEmbarcação adicionada com sucesso!");
                    }
                    else if (!adicionado)
                    {
                        Console.WriteLine("\nNão foi possível adicionar a embarcação. Tente novamente.");
                        n--; 
                    }

                }
                Console.WriteLine("Seu tabuleiro:");
                player.ImprimirTabuleiroJogador();

           
            do {


                bool acertou;

                
                do
                {
                    bool valid;
                    Posicao tiro;

                    do
                    {
                        
                        

                        Console.WriteLine($"\nVez do jogador {player.Nickname}");
                        Console.WriteLine("Informe a linha do tiro:");
                        int linhaTiro = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe a coluna do tiro:");
                        int colunaTiro = int.Parse(Console.ReadLine());

                        tiro = new Posicao(linhaTiro -1, colunaTiro -1);
                        valid = player.EscolherAtaque(tiro);

                        if (!valid)
                        {
                            Console.WriteLine("\nPosição inválida!");
                        }

                    } while (!valid);

                   
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

                    Console.WriteLine("Tabuleiro do jogador máquina atualizado com o último tiro");
                    maquina.ImprimirTabuleiroAdversario();


                    



                }
                while (player.Pontuacao < 22 && acertou);


               
                acertou = true;

                while (maquina.Pontuacao < 22 && player.Pontuacao < 22 && acertou) 
                {
                    
                    

                   
                    Console.WriteLine("Vez do jogador computador: \n");
                    Posicao tiroComputador = maquina.EscolherAtaque();

                  
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

                    Console.WriteLine($"\nTabuleiro do jogador {player.Nickname} atualizado com o ultimo tiro:");
                    player.ImprimirTabuleiroAdversario();


                   

                }
                

            } while (maquina.Pontuacao < 22 && player.Pontuacao < 22);

            if (player.Pontuacao == 22)
            {
                Console.WriteLine($"O jogador {player.Nickname} ganhou!!!");
                try
                {
                    Console.WriteLine($"\nParabéns, {player.Nickname}! Você venceu o jogo de Batalha Naval!");

                    StreamWriter sw = new StreamWriter("jogadas.txt", true, Encoding.UTF8);

                   
                    for (int i = 0; i < player.NumTirosDados; i++)
                    {
                        sw.WriteLine($"Tiro {i + 1}: ({player.PosTirosDados[i].Linha + 1}, {player.PosTirosDados[i].Coluna + 1})");
                    }

                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            else if (maquina.Pontuacao == 22)
            {
                Console.WriteLine($"O jogador computador ganhou!!!");
                try
                {
                    Console.WriteLine($"\nParabéns, {player.Nickname}! Você venceu o jogo de Batalha Naval!");

                    StreamWriter sw = new StreamWriter("jogadas.txt", true, Encoding.UTF8);

                   
                    for (int i = 0; i < player.NumTirosDados; i++)
                    {
                        sw.WriteLine($"Tiro {i + 1}: ({maquina.PosTirosDados[i].Linha + 1}, {maquina.PosTirosDados[i].Coluna + 1})");
                    }

                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }

           
            Console.WriteLine("Fim do jogo!");
            Console.ReadLine();
        }
    }
}
