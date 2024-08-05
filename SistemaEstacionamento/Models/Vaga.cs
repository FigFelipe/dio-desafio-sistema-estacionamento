using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento.Models
{
    internal class Vaga
    {
        // Atributos
        private string nome { get; set; }
        private Veiculo veiculo { get; set; }

        // Construtores
        public Vaga()
        {

        }

        public Vaga(string nome)
        {
            this.nome = nome;
            this.veiculo = new Veiculo("");
        }

        public Vaga(string nome, Veiculo veiculo)
        {
            this.nome = nome;
            this.veiculo = veiculo;
        }


        // Getters e Setters
        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        // Metodos
        public Vaga isVagaOcupada(Vaga vaga)
        {
            return vaga;
        }
        
        public override string ToString()
        {
            return "Vaga: " + this.nome
                + " | Placa: " + veiculo.GetPlaca();
                
        }
    }
}
