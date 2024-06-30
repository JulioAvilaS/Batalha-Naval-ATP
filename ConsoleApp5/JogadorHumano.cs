using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class JogadorHumano
    {
        private char[,] tabuleiro;
        private int pontuacao;
        private int numTirosDados;
        private Posicao[] posTirosDados;
        private string nickname;
        
        public JogadorHumano( int linha, int coluna, string nomeCompleto)
        {
           

            this.pontuacao = 0;
            this.numTirosDados = 0;

            GerarNickName(nomeCompleto);
            this.tabuleiro = new char [linha, coluna];
            for (int l = 0; l < tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLength(1); c++)
                {
                    tabuleiro[l, c] = 'A';
                }
            }
            this.posTirosDados = new Posicao[100];
        }
        
        public void GerarNickName(string nomeCompleto)
        {
            
            string parte;
            string[] palavra;
            string usuario;
            string iniciais = "";
            char inicial;


            nomeCompleto = nomeCompleto.ToUpper();

            palavra = nomeCompleto.Split(' ');


            usuario = palavra[0];


            for (int i = 1; i < palavra.Length; i++)
            {
                parte = palavra[i];
                inicial = parte[0];
                iniciais += inicial;
            }


            nickname = usuario + iniciais;

            Console.WriteLine("Seu nickname é: " + nickname);
        }
        public bool EscolherAtaque(Posicao p)
        {
           
            if(p.Linha < 0 || p.Linha >= 10 || p.Coluna < 0 || p.Coluna >= 10)
            {
                return false;
            }
            for (int i = 0; i < numTirosDados; i++)
            {
                if (posTirosDados[i].Linha == p.Linha && posTirosDados[i].Coluna == p.Coluna)
                {
                    return false;
                }
            }
            posTirosDados[numTirosDados] = p;
            numTirosDados++;
            return true;
            
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

        public void ImprimirTabuleiroJogador() {
           
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
                    if (tabuleiro[l,c] != 'X' && tabuleiro[l, c] != 'A' && tabuleiro[l, c] != 'T')
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

        public bool AdicionarEmbarcacao(Embarcacao e, Posicao p)
        {
            
            if (p.Coluna + e.Tamanho > 10)  
            {
                return false;
            }

           
            for (int i = 0; i < e.Tamanho; i++)
            {
                if (tabuleiro[p.Linha, p.Coluna + i] != 'A')  
                {
                    return false;
                }
            }

            for (int i = 0; i < e.Tamanho; i++)
            {
                tabuleiro[p.Linha, p.Coluna + i] = e.Nome[0];  
            }

            return true;
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; } 
        }
        public int NumTirosDados
        {
            get { return numTirosDados; }
            set {  numTirosDados = value;}
        }
        public int Pontuacao
        {
            get { return pontuacao; }
            set { pontuacao = value; }
        }
        public Posicao[] PosTirosDados
        {
            get { return posTirosDados; }
            set { posTirosDados = value; }

        }




    }
}
