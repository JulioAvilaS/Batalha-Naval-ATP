using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class JogadorComputador
    {

        private char[,] tabuleiro;
        private int pontuacao;
        private int numTirosDados;
        private Posicao[] posTirosDados;
        

        public JogadorComputador(int linha, int coluna)
        {
            //o construtor deverá receber como parâmetro o número de linhas e colunas do tabuleiro do jogador. Todos os atributos devem ser inicializados: i)
            //O tabuleiro deve ser instanciado e todas as posições devem receber o símbolo de água; ii) A pontuação deve iniciar com zero; iii)
            //o número de tiros dados (numTirosDados) deve iniciar com zero, iv) o vetor com as posições dos tiros dados (posTirosDados) deve ser instanciado.

            this.pontuacao = 0;
            this.numTirosDados = 0;

            
            this.tabuleiro = new char[linha, coluna];
            for (int l = 0; l > tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c > tabuleiro.GetLength(1); c++)
                {
                    tabuleiro[l, c] = 'A';
                }
            }
            this.posTirosDados = new Posicao[100];
        }
        
        public Posicao EscolherAtaque()
        {
            // este método retornará a Posicao de um tiro (tipo de retorno do método: Posicao).. O programa 
            //deverá gerar aleatoriamente a posição de um tiro(Utilize o método Next da classe Random). O método deverá
            //também, adicionar o tiro dado no vetor posTirosDados. Validações: Caso a posição gerada aleatoriamente esteja
            //fora dos limites do tabuleiro ou já tenha sido utilizada anteriormente(verifique no vetor posTirosDados), o
            //programa deverá gerar uma nova posição de disparo.
            bool confirm = true;
            int linha, coluna;
            Posicao p = new Posicao(0,0);
            while (confirm) 
            { 
                confirm = false;
                Random l = new Random(10); 
                Random c = new Random(10);
                linha = l.Next();  coluna = c.Next();
                p = new Posicao(linha, coluna);
                for (int i = 0; i < posTirosDados.Length; i++)
                {
                    if ( p == posTirosDados[i])
                    {
                        confirm = true;
                    }                  
                } 
            }
            for (int i = 0; i < posTirosDados.Length; i++)
            {
                if (posTirosDados[i] == null)
                {
                    posTirosDados[i] = p;
                    return p;
                }
            }
            return p;
        }
        public bool ReceberAtaque(Posicao p)
        {
            //este método receberá a Posicao de um tiro como parâmetro (parâmetro do método: Posicao).
            //Deve-se atualizar o tabuleiro com este tiro, caso alguma embarcação seja atingida o método retornará verdadeiro, caso contrário retornará falso.
            if (tabuleiro[p.Linha, p.Coluna] == 'A')
            {
                tabuleiro[p.Linha, p.Coluna] = 'X';
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
            //imprime o tabuleiro para o jogador, mostrando inclusive o posicionamento de todas as embarcações
            for (int l = 0; l > tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c > tabuleiro.GetLength(1); c++)
                {
                    Console.Write(tabuleiro[l, c] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void ImprimirTabuleiroAdversario()
        {
            //imprime o tabuleiro para o adversário, isto é, não deve ser informado o
            //posicionamento das embarcações.
            for (int l = 0; l > tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c > tabuleiro.GetLength(1); c++)
                {
                    if (tabuleiro[l, c] != 'A' || tabuleiro[l, c] != 'X')
                    {
                        Console.Write('T');
                    }
                    else
                    {
                        Console.Write(tabuleiro[l, c] );
                    }
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }

        public void AdicionarEmbarcacao()
        {
            //Deve ler o arquivo de texto e definir a posição de cada barco de acordo com este mesmo arquivo.


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
    }
}
