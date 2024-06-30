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
            //este método deve receber o nome completo do jogador como parâmetro (parâmetro do método: string) e deve gerar o seu nickname.
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
            //Validações: 1) Se for informada uma posição fora dos limites do tabuleiro,
            //deverá ser solicitada uma nova posição de disparo. 2) Se for informada uma posição de disparo que já foi utilizada anteriormente
            //(verifique no vetor posTirosDados), o programa deverá solicitar uma nova posição de disparo.
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
            //este método receberá a Posicao de um tiro como parâmetro (parâmetro do método: Posicao).
            //Deve-se atualizar o tabuleiro com este tiro, caso alguma embarcação seja atingida o método retornará verdadeiro, caso contrário retornará falso.
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
            //imprime o tabuleiro para o jogador, mostrando inclusive o posicionamento de todas as embarcações
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
            //imprime o tabuleiro para o adversário, isto é, não deve ser informado o
            //posicionamento das embarcações. 
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
            // Verifica se a embarcação cabe totalmente no tabuleiro a partir da posição p
            if (p.Coluna + e.Tamanho > 10)  // Verifica se a embarcação ultrapassa as colunas do tabuleiro
            {
                return false;
            }

            // Verifica se há alguma outra embarcação já posicionada nas posições onde a nova embarcação será colocada
            for (int i = 0; i < e.Tamanho; i++)
            {
                if (tabuleiro[p.Linha, p.Coluna + i] != 'A')  // Verifica se a posição já está ocupada
                {
                    return false;
                }
            }

            // Se passou pelas verificações, adiciona a embarcação ao tabuleiro
            for (int i = 0; i < e.Tamanho; i++)
            {
                tabuleiro[p.Linha, p.Coluna + i] = e.Nome[0];  // Coloca a primeira letra do nome da embarcação
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
