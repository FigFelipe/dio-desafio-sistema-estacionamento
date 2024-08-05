using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento.Models
{
    public class Estacionamento
    {
        Veiculo veiculo = new Veiculo();
        List<Veiculo> listaVeiculos = new List<Veiculo>();

        Vaga vaga = new Vaga();
        List<Vaga> listVagas = new List<Vaga>();

        public void CadastrarVeiculo()
        {
            bool isPlacaValida = false;
            string placaVeiculo = null; // Armazena a 'placa do veículo'

            do
            {
                Console.WriteLine("\n  ----------------------------------");
                Console.WriteLine("    Menu > [Cadastro de Veículos]");
                Console.WriteLine("  ----------------------------------\n");

                // Recebe do usuário a 'placa do veículo'
                Console.Write(" 1) Informe a placa do veículo (XXX-1234): ");
                placaVeiculo = Console.ReadLine();

                // Validação básica da placa informada
                // 1. Deve conter, ao menos, um caracter '-' (traço)
                // 2. Deve conter 8 (oito) caracteres de tamanho
                if (placaVeiculo.Contains("-") && placaVeiculo.Length.Equals(8))
                {
                    isPlacaValida = true;

                }
                else
                {
                    
                    isPlacaValida = false;

                    Console.Clear();
                    Console.WriteLine($"\n  --> [Erro] A placa '{placaVeiculo}' é inválida. Tente novamente.");
                    
                }


            } while (!isPlacaValida);

            // Instanciando atributos ao objeto 'veiculo'
            veiculo = new Veiculo(placaVeiculo);

            // Adicionando o objeto 'veiculo' á lista do tipo 'veiculo'
            listaVeiculos.Add(veiculo);

            foreach(Veiculo v in listaVeiculos)
            {
                Console.WriteLine($"    Placa: {v.GetPlaca()}");
            }

            // Selecionar a vaga
            SelecionarVaga();

            

            //Console.WriteLine($"\n  --> O veículo '{veiculo.GetPlaca()}' foi cadastrado com sucesso.");

            
            Console.WriteLine("\n  Pressione qualquer tecla para continuar...");
            Console.ReadLine();

            // Retorna ao menu principal
            Console.Clear();
            Menu.ExibirMenu();
        }


        public void SelecionarVaga()
        {
            string vagaSelecionada = null;
            bool isVagaOcupada = false;
            
            Console.Write("\nInforme a vaga à ser ocupada: ");
            vagaSelecionada = Console.ReadLine();

            // Exibe a qtd de objetos 'vaga' na 'lista de vagas'
            //Console.WriteLine($"\nListVaga.Count: {listVagas.Count}");

            // Cria um novo objeto 'vaga', como referencia
            vaga = new Vaga(vagaSelecionada);

            // Verifica a ja existencia do objeto 'vaga' na 'lista de vagas'
            isVagaOcupada = listVagas.Any(x => x.GetNome() == vagaSelecionada);

            Console.WriteLine($"\nisVagaOcupada '{vagaSelecionada}': {isVagaOcupada}");

            if (isVagaOcupada)
            {
                Console.WriteLine($"--> A vaga '{vaga.GetNome()}' já está ocupada. Informe uma outra vaga disponível.");
            }
            else
            {
                Console.WriteLine($"--> A vaga '{vaga.GetNome()}' está livre.");

                // Adiciona o carro á vaga livre
                vaga = new Vaga(vagaSelecionada, veiculo);

                listVagas.Add(vaga);
            }


            Console.WriteLine("\n--> Lista de 'vagas'");
            foreach (Vaga v in listVagas)
            {
                Console.WriteLine($"--> {v.ToString()}");
            }

        }

        
    }
}
