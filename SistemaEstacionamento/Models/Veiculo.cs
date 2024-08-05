using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento.Models
{
    public class Veiculo
    {
        // Atributos
        private string placa { get; set; }

        // Construtor
        public Veiculo()
        {

        }


        public Veiculo(string placa)
        {
            this.placa = placa;
        }

        // Getters e Setters
        public string GetPlaca()
        {
            return placa;
        }

        public void SetPlaca(string placa)
        {
            this.placa = placa;
        }

        public override string ToString()
        {
            return " Placa: " + placa;
        }
    }
}
