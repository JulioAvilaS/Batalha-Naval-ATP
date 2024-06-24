using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class JogadorHumano
    {
        private char[] tabuleiro;
        private int pontuacao;
        private int numTirosDados;
        private Posicao[] posTirosDados;
        private string nickname;

        public JogadorHumano(ref int linha, ref int coluna, string nomeCompleto)
        {
            //o construtor deverá receber como parâmetro o número de linhas e colunas do tabuleiro do jogador, e também o nome completo do jogador.
            //Todos os atributos devem ser inicializados: i) O tabuleiro deve ser instanciado e todas as posições devem receber o símbolo de água ii)
            //A pontuação deve iniciar com zero; iii) o número de tiros dados (numTirosDados) deve iniciar com zero, iv) o vetor com as posições dos tiros dados (posTirosDados) deve ser instanciado, v)
            //o nickname deve ser gerado (utilize o método GerarNickname).
        }
        public void Propriedades()
        {
            0, 5
        }
        public void GerarNickName(string nomeCompleto)
        {
            //este método deve receber o nome completo do jogador como parâmetro (parâmetro do método: string) e deve gerar o seu nickname.
        }
        public Posicao EscolherAtaque()
        {
            //Validações: 1) Se for informada uma posição fora dos limites do tabuleiro,
            //deverá ser solicitada uma nova posição de disparo. 2) Se for informada uma posição de disparo que já foi utilizada anteriormente
            //(verifique no vetor posTirosDados), o programa deverá solicitar uma nova posição de disparo.
            return p;
        }
        public bool ReceberAtaque(Posicao p)
        {
            //este método receberá a Posicao de um tiro como parâmetro (parâmetro do método: Posicao).
            //Deve-se atualizar o tabuleiro com este tiro, caso alguma embarcação seja atingida o método retornará verdadeiro, caso contrário retornará falso.

            return false;
        }

        public void ImprimirTabuleiroJogador() {
            //imprime o tabuleiro para o jogador, mostrando inclusive o posicionamento de todas as embarcações

        }

        public void ImprimirTabuleiroAdversario()
        {
            //imprime o tabuleiro para o adversário, isto é, não deve ser informado o posicionamento das embarcações.
        }

        public bool AdicionarEmbarcacao(Posicao p)
        {
            //recebe como parâmetro uma Embarcacao e sua posição inicial (tipo Posicao).
            //A Embarcacao deve ser adicionada no tabuleiro caso seja possível adicioná-la a partir da posição informada,
            //isto é, a embarcação inteira deve caber no tabuleiro. Caso seja possível adicionar a embarcação,
            //o método deverá retornar verdadeiro, caso contrário retornará falso (Não devem ser adicionadas duas embarcações na mesma posição).
            return false;
        }
    }
}
