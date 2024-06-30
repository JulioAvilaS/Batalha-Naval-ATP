using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Embarcacao
    {
        private string nome;
        private int tamanho;


       
        public Embarcacao(string nome, int tamanho)
        {
            this.nome = nome;
            this.tamanho = tamanho;
        }
        public string Nome
        {
            get {return this.nome;} 
            set { this.nome = value;}   

        }
        public int Tamanho
        {
            get { return this.tamanho;}
            set { this.tamanho = value;}
        }

        

    }
}
