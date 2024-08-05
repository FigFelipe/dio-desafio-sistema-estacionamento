using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento.Models
{
    public class Menu
    {
        // Instanciando um objeto tipo 'Estacionamento'
        static Estacionamento estacionamento = new Estacionamento();

        public static void ExibirMenu()
        {
            int opcaoMenu = 0;
            bool isOpcaoMenuValida = false;

            do
            {
                // Menu do sistema de estacionamento
                Console.WriteLine("  =====================================");
                Console.WriteLine("     SISTEMA DE ESTACIONAMENTO");
                Console.WriteLine("  =====================================\n");

                
                Console.WriteLine("     [1] - Cadastrar Veículo...");
                Console.WriteLine("     [2] - Remover Veículo...");
                Console.WriteLine("     [3] - Listar Veículos...");
                Console.WriteLine("     [4] - Configurar preços...");
                Console.WriteLine("     [5] - Encerrar aplicativo...");

                Console.Write("\n   Informe uma opção: ");
                opcaoMenu = Convert.ToInt32(Console.ReadLine());

                if (opcaoMenu <= 0 || opcaoMenu > 5)
                {
                    Console.Clear();

                    Console.WriteLine($"\n  --> [Erro] A opção '{opcaoMenu}' é inválida.\n");
                    isOpcaoMenuValida = false;
                }
                else
                {
                    isOpcaoMenuValida = true;
                }

            } while (!isOpcaoMenuValida);


            // Acesso aos métodos correspondentes
            switch(opcaoMenu)
            {
                case 1:
                    Console.Clear();
                    estacionamento.CadastrarVeiculo();
                    break;

                case 2:
                    Console.Clear();
                    estacionamento.RemoverVeiculo();
                    break;

                case 3:
                    Console.Clear();
                    estacionamento.ExibirVagasEstacionamento();
                    break;

                case 4:
                    Console.Clear();
                    estacionamento.DefinirPrecos();
                    break;
            }

        }

        private void Encerrar()
        {

        }
        
    }
}
