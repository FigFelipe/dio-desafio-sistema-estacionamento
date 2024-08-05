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

        double precoInicial = 0.0;
        double precoPorHora = 0.0;

        public void CadastrarVeiculo()
        {
            string placaVeiculo = null;
            bool isPlacaValida = false;

            do
            {
                Console.WriteLine("\n  ----------------------------------");
                Console.WriteLine("    Menu > [Cadastro de Veículos]");
                Console.WriteLine("  ----------------------------------\n");

                Console.WriteLine("   Exemplo(s) de entrada(s) de placa(s):");

                Console.WriteLine("\n   Com uso do hífen (-):");
                Console.WriteLine("     --> ABC-1234");
                Console.WriteLine("     --> ABC-1C34 (padrão mercosul)");

                Console.WriteLine("\n   Sem o uso do hífen (-):");
                Console.WriteLine("     --> ABC1234");
                Console.WriteLine("     --> ABC1C34 (padrão mercosul)\n");




                // Recebe do usuário a 'placa do veículo'
                Console.Write(" 1) Informe a placa do veículo (padrão comum, ou mercosul): ");
                placaVeiculo = Console.ReadLine();

                // Validação da placa informada
                isPlacaValida = veiculo.ValidarPlaca(placaVeiculo);

                // Se a placa informada for válida
                if (isPlacaValida)
                {
                    // Consultar se o objeto 'placa' ja existe na lista de objetos 'listVeiculos'
                    ConsultarVeiculo(placaVeiculo);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\n  --> [Erro] A placa '{placaVeiculo}' é inválida. Tente novamente.");
                }


            } while (!isPlacaValida);

            Console.WriteLine("\n  Pressione qualquer tecla para continuar...");
            Console.ReadLine();

            // Retorna ao menu principal
            Console.Clear();
            Menu.ExibirMenu();
        }

        public void RemoverVeiculo()
        {
            string placa = null;
            string placaSemHifen = null;
           
            bool isPlacaValida = false;
            bool isVagaOcupada = false;

            Console.Clear();

            Console.WriteLine("\n  ----------------------------------");
            Console.WriteLine("    Menu > [Remover Veículo]");
            Console.WriteLine("  ----------------------------------\n");

            Console.Write("  Informe a placa do veículo: ");
            placa = Console.ReadLine();

            // Validar a placa recebida
            isPlacaValida = veiculo.ValidarPlaca(placa);

            if(isPlacaValida)
            {
                // Remover o hífen da placa recebida
                if (placa.Contains('-'))
                {
                    int indiceHifen = placa.IndexOf("-");

                    placaSemHifen = placa.Remove(indiceHifen, 1);
                }
                else
                {
                    placaSemHifen = placa;
                }

                placaSemHifen = placaSemHifen.ToUpper();


                // Verifica se na lista vagas existe a vaga obtida no 'deletarVaga'
                isVagaOcupada = listVagas.Any(x => x.GetNome() == vaga.GetNome());
                
                Console.WriteLine($"\n    isVagaOcupada: {isVagaOcupada}");
                
                if (isVagaOcupada)
                {
                    // Faz busca da placa informada na lista de veiculos
                    veiculo = listaVeiculos.Find(x => x.GetPlaca() == placaSemHifen);

                    // Faz a busca da vaga ocupada através da placa informada
                    vaga = listVagas.Find(x => x.ToString().Contains(veiculo.GetPlaca()));

                    Console.WriteLine($"\n  --> {veiculo}, {vaga}");


                    Console.WriteLine($"\n --> Encontrado o veiculo '{veiculo.GetPlaca()}' na vaga '{vaga.GetNome()}'");

                    // Faz o calculo do custo do estacionamento
                    CalcularCustoEstacionamento(vaga.GetMomento());

                    // Removendo o objetos das listas
                    listVagas.RemoveAll(x => x.GetNome() == vaga.GetNome());

                    listaVeiculos.Remove(veiculo);
                }
                else
                {
                    Console.WriteLine($"\n   --> Não foi possível encontrar o veículo '{placaSemHifen}'.");
                }

            }
            else
            {
                Console.WriteLine($"\n   --> A placa {placa} é invalida. Tente novamente.");
            }

            Console.WriteLine("\n Pressione qualquer tecla para retornar ao menu...");
            Console.ReadLine();

            Console.Clear();
            Menu.ExibirMenu();

        }

        public void ExibirVagasEstacionamento()
        {
            Console.WriteLine("\n   --> Lista de vagas...\n");

            foreach (var vaga in listVagas)
            {
                Console.WriteLine($"    {vaga}");
            }

            Console.WriteLine("\n Pressione qualquer tecla para retornar ao menu principal...");
            Console.ReadLine();

            Console.Clear();

            Menu.ExibirMenu();
        }

        public void DefinirPrecos()
        {
            int opcao = 0;

            do
            {
                Console.WriteLine("\n  ----------------------------------");
                Console.WriteLine("    Menu > [Configurar Preços]");
                Console.WriteLine("  ----------------------------------");

                Console.WriteLine($"\n  [1] Preço inicial:  R${precoInicial.ToString("#.##")}");
                Console.WriteLine($"\n  [2] Preço por Hora: R${precoPorHora.ToString("#.##")}");

                Console.Write("\n  Informe uma opção para definir o preço: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.Clear();
                    Console.Write("\n Defina o valor do 'Preço Inicial': R$");
                    precoInicial = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine($"\n --> O 'Preço Inicial' teve o valor modificado para R${precoInicial}");

                    Console.WriteLine("\n Pressione qualquer tecla para retornar ao menu principal...");
                    Console.ReadLine();
                    
                    Console.Clear();
                    Menu.ExibirMenu();
                }
                else if (opcao == 2)
                {
                    Console.Clear();
                    Console.Write("\n Defina o valor do 'Preço por Hora': R$");
                    precoPorHora = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine($"\n --> O 'Preço por Hora' teve o valor modificado para R${precoPorHora}");

                    Console.WriteLine("\n Pressione qualquer tecla para retornar ao menu principal...");
                    Console.ReadLine();

                    Console.Clear();
                    Menu.ExibirMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\n   --> A opção '{opcao}' é invalida. Tente novamente.");
                }

            } while(opcao <= 0 || opcao > 2);
            

        }

        public void CalcularCustoEstacionamento(DateTime entrada)
        {
            double precoTotal = 0.0;

            DateTime saida = DateTime.Now;

            TimeSpan diferencaHoras = saida - entrada;

            int totalSegundos = Convert.ToInt32(diferencaHoras.TotalSeconds);

            // Como é um ambiente de simulação,
            // o calculo base será realizado por segundo
            precoTotal = precoInicial + (precoPorHora *  totalSegundos);

            Console.WriteLine("\n    Resumo do estacionamento");
            Console.WriteLine($"    Tempo estacionado: {totalSegundos}s");
            Console.WriteLine($"    Custo = {precoInicial} + ({precoPorHora} * {totalSegundos})");
            Console.WriteLine($"\n   --> TOTAL: R${precoTotal}");

        }

        public bool ConsultarVeiculo(string placa)
        {
            bool isPlacaExists = false;
            string placaSemHifen = null;

            // Remover o hífen da placa recebida
            if (placa.Contains('-'))
            {
                int indiceHifen = placa.IndexOf("-");

                placaSemHifen = placa.Remove(indiceHifen, 1);
            }
            else
            {
                placaSemHifen = placa;
            }

            placaSemHifen = placaSemHifen.ToUpper();

            //Console.WriteLine($"\n  Placa sem hífen: {placaSemHifen}");

            // Realiza a consulta da placa na lista de veiculos
            isPlacaExists = listaVeiculos.Any(x => x.GetPlaca() == placaSemHifen);

            if(isPlacaExists)
            {
                Console.WriteLine($"\n    --> Não foi possível cadastrar o veiculo '{placaSemHifen}', pois o mesmo já está no estacionamento.");
            }
            else
            {
                Console.WriteLine($"\n    --> O veiculo '{placaSemHifen}' NÃO está no estacionamento.");

                // Atribuir a nova placa á um objeto veiculo
                veiculo = new Veiculo(placaSemHifen);

                // Adicionar o objeto veiculo à lista de veiculos
                listaVeiculos.Add(veiculo);

                // Selecionar uma vaga disponível
                SelecionarVaga(veiculo);
            }


            return true;
        }


        public void SelecionarVaga(Veiculo veiculo)
        {
            string vagaSelecionada = null;
            bool isVagaOcupada = false;
            
            Console.Write("\n2) Informe a vaga à ser ocupada: ");
            vagaSelecionada = Console.ReadLine();

            // Verifica a ja existencia do objeto 'vaga' na 'lista de vagas'
            isVagaOcupada = listVagas.Any(veiculo => veiculo.GetNome() == vagaSelecionada);

            Console.WriteLine($"\n    --> isVagaOcupada '{vagaSelecionada}': {isVagaOcupada}");

            if (!isVagaOcupada)
            {
                // Instancia uma nova vaga, com um nome e um veiculo
                vaga = new Vaga(vagaSelecionada, veiculo, DateTime.Now);

                listVagas.Add(vaga);

                Console.WriteLine($"\n    --> A vaga '{vagaSelecionada}' foi ocupada com o veiculo (placa): '{veiculo.GetPlaca()}'.");
            }
            else
            {
                Console.WriteLine($"      --> A vaga '{vagaSelecionada}' já está ocupada. Informe uma outra vaga.");
            }

        }
        
    }
}
