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
            //o construtor deverá receber como parâmetro o número de linhas e colunas do tabuleiro do jogador, e também o nome completo do jogador.
            //Todos os atributos devem ser inicializados: i) O tabuleiro deve ser instanciado e todas as posições devem receber o símbolo de água ii)
            //A pontuação deve iniciar com zero; iii) o número de tiros dados (numTirosDados) deve iniciar com zero, iv) o vetor com as posições dos tiros dados (posTirosDados) deve ser instanciado, v)
            //o nickname deve ser gerado (utilize o método GerarNickname).

            this.pontuacao = 0;
            this.numTirosDados = 0;

            GerarNickName(nomeCompleto);
            this.tabuleiro = new char [linha, coluna];
            for (int l = 0; l > tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c > tabuleiro.GetLength(1); c++)
                {
                    tabuleiro[l, c] = 'A';
                }
            }
            this.posTirosDados = new Posicao[100];
        }
        
        public void GerarNickName(string nomeCompleto)
        {
            //este método deve receber o nome completo do jogador como parâmetro (parâmetro do método: string) e deve gerar o seu nickname.

        }
        public bool EscolherAtaque(Posicao p)
        {
            //Validações: 1) Se for informada uma posição fora dos limites do tabuleiro,
            //deverá ser solicitada uma nova posição de disparo. 2) Se for informada uma posição de disparo que já foi utilizada anteriormente
            //(verifique no vetor posTirosDados), o programa deverá solicitar uma nova posição de disparo.
            if(p.Linha < 0 || p.Linha >100 || p.Coluna < 0 || p.Coluna > 100)
            {
                return false;
            }
            for (int i = 0; i < posTirosDados.Length; i++)
            {
                if (p == posTirosDados[i])
                {
                    return false;
                }
            }
            for (int i = 0; i < posTirosDados.Length; i++)
            {
                if (posTirosDados[i] == null)
                {
                    posTirosDados[i] = p;
                }
            }
            numTirosDados++;
            return true;
            
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

        public void ImprimirTabuleiroJogador() {
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
                        Console.Write(tabuleiro[l, c]);
                    }
                    Console.Write("\t");
                }
                Console.WriteLine();
            }

        }

        public bool AdicionarEmbarcacao(Embarcacao e, Posicao p)
        {
            //recebe como parâmetro uma Embarcacao e sua posição inicial (tipo Posicao).
            //A Embarcacao deve ser adicionada no tabuleiro caso seja possível adicioná-la a partir da posição informada,
            //isto é, a embarcação inteira deve caber no tabuleiro. Caso seja possível adicionar a embarcação,
            //o método deverá retornar verdadeiro, caso contrário retornará falso (Não devem ser adicionadas duas embarcações na mesma posição).
            for (int i = 0; i < e.Tamanho; i++)
            {
                if ((p.Coluna + i) < 9)
                {
                    return false;
                }
                else if (tabuleiro[p.Linha, p.Coluna + i] != 'A')
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




    }
}
