﻿using System;
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
        public DateTime momento { get; set; }

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

        public Vaga(string nome, Veiculo veiculo, DateTime momento) : this(nome, veiculo)
        {
            this.momento = momento;
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

        public DateTime GetMomento()
        {
            return momento;
        }

        public void SetMomento()
        {
            this.momento = DateTime.Now;
        }

        // Metodos
        public Vaga isVagaOcupada(Vaga vaga)
        {
            return vaga;
        }
        
        public override string ToString()
        {
            return "Vaga: " + this.nome
                + " | Placa: " + veiculo.GetPlaca()
                + " | Entrada: " + this.momento;
                
        }
    }
}
