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
            //o construtor deverá receber como parâmetro o número de linhas e colunas do tabuleiro do jogador. Todos os atributos devem ser inicializados: i)
            //O tabuleiro deve ser instanciado e todas as posições devem receber o símbolo de água; ii) A pontuação deve iniciar com zero; iii)
            //o número de tiros dados (numTirosDados) deve iniciar com zero, iv) o vetor com as posições dos tiros dados (posTirosDados) deve ser instanciado.

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
            // este método retornará a Posicao de um tiro (tipo de retorno do método: Posicao).. O programa 
            //deverá gerar aleatoriamente a posição de um tiro(Utilize o método Next da classe Random). O método deverá
            //também, adicionar o tiro dado no vetor posTirosDados. Validações: Caso a posição gerada aleatoriamente esteja
            //fora dos limites do tabuleiro ou já tenha sido utilizada anteriormente(verifique no vetor posTirosDados), o
            //programa deverá gerar uma nova posição de disparo.
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

        public void ImprimirTabuleiroJogador()
        {
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
              //Deve ler o arquivo de texto e definir a posição de cada barco de acordo com este mesmo arquivo.

              //indexOf(';');
              //lastIndexOf(';');
            
                // Lê o arquivo de texto e define a posição de cada barco de acordo com o arquivo
                StreamReader arq = new StreamReader("frotaComputador.txt", Encoding.UTF8);

                string linha;

                linha = arq.ReadLine();

                while (linha != null)
                {
                    // Encontra a posição dos pontos e vírgulas na linha
                    int primeiroP = linha.IndexOf(';');
                    int ultimoP = linha.LastIndexOf(';');

                    // Extrai o nome da embarcação e suas coordenadas
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

                    // Se passou pelas verificações, adiciona a embarcação ao tabuleiro
                    for (int i = 0; i < tamanho; i++)
                    {
                        tabuleiro[linhaInicial, colunaInicial + i] = nome[0];  // Coloca a primeira letra do nome da embarcação
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
