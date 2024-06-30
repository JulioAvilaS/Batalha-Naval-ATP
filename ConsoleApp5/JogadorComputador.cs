using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp5
{
    internal class JogadorComputador
    {

        private char[,] tabuleiro;
        private int pontuacao;
        private int numTirosDados;
        private Posicao[] posTirosDados;
        private Random random;
        

        public JogadorComputador(int linha, int coluna)
        {
           

            this.pontuacao = 0;
            this.numTirosDados = 0;

            
            this.tabuleiro = new char[linha, coluna];
            for (int l = 0; l < tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLength(1); c++)
                {
                    tabuleiro[l, c] = 'A';
                }
            }
            this.posTirosDados = new Posicao[100];
            this.random = new Random();
        }
        
        public Posicao EscolherAtaque()
        {
            
            bool confirm;
            int linha, coluna;
            Posicao p = new Posicao(0,0);
            do
            {
                confirm = false;

                linha = random.Next(10);
                coluna = random.Next(10);

                p = new Posicao(linha, coluna);

                for (int i = 0; i < posTirosDados.Length; i++)
                {
                    if (p.Linha == posTirosDados[i].Linha && p.Coluna == posTirosDados[i].Coluna)
                    {
                        confirm = true;
                    }
                }
            } while (confirm);
            numTirosDados++;
            posTirosDados[numTirosDados] = p;
            return p;
        }
        public bool ReceberAtaque(Posicao p)
        {
            if (tabuleiro[p.Linha, p.Coluna] == 'A')
            {
                tabuleiro[p.Linha, p.Coluna] = 'X';
                return false;
            }
            else if (tabuleiro[p.Linha, p.Coluna] == 'X' || tabuleiro[p.Linha, p.Coluna] == 'T')
            {
                return false;
            }
            else
            {
                tabuleiro[p.Linha, p.Coluna] = 'T';
                return true;
            }
        }

        public void ImprimirTabuleiroJogador()
        {
           
            for (int l = 0; l < tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLength(1); c++)
                {
                    Console.Write(tabuleiro[l, c] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void ImprimirTabuleiroAdversario()
        {
          
            for (int l = 0; l < tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLength(1); c++)
                {
                    if (tabuleiro[l, c] != 'X' && tabuleiro[l, c] != 'A' && tabuleiro[l, c] != 'T')
                    {
                        Console.Write("A");
                    }
                    else
                    {
                        Console.Write(tabuleiro[l, c]);
                    }
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }

            public void AdicionarEmbarcacao()
            {
              
                StreamReader arq = new StreamReader("frotaComputador.txt", Encoding.UTF8);

                string linha;

                linha = arq.ReadLine();

                while (linha != null)
                {
                   
                    int primeiroP = linha.IndexOf(';');
                    int ultimoP = linha.LastIndexOf(';');

                   
                    string nome = linha.Substring(0, primeiroP);
                    int linhaInicial = int.Parse(linha.Substring(primeiroP + 1, ultimoP - primeiroP - 1));
                    int colunaInicial = int.Parse(linha.Substring(ultimoP + 1));

                    int tamanho = 0;

                    if (nome == "Submarino")
                    {
                        tamanho = 1;
                    }
                    else if (nome == "Hidroavião")
                    {
                        tamanho = 2;
                    }
                    else if (nome == "Cruzador")
                    {
                        tamanho = 3;
                    }
                    else if (nome == "Encouraçado")
                    {
                        tamanho = 4;
                    }
                    else if (nome == "Porta-aviões")
                    {
                        tamanho = 5;
                    }

                   
                    for (int i = 0; i < tamanho; i++)
                    {
                        tabuleiro[linhaInicial, colunaInicial + i] = nome[0]; 
                    }

                    linha = arq.ReadLine();
                }
                arq.Close();
            

            }



        public int NumTirosDados
        {
            get { return numTirosDados; }
            set { numTirosDados = value; }
        }
        public int Pontuacao
        {
            get { return pontuacao; }
            set { pontuacao = value; }
        }
        public Posicao[] PosTirosDados {
            get {return posTirosDados;}
            set {  posTirosDados = value;}

        }


    }
}
