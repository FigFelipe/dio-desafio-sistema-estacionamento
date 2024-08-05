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

        // Metodos
        public bool ValidarPlaca(string placa)
        {
            // O vetor de gabarito que verifica se a placa é valida ou nao.
            //
            // Se a posição [x] == letra, entao é marcado com a letra 'O'
            // Se a posição [x] == numero, entao é marcado com a letra 'X'
            //
            // Portanto, os 3 (três) primeiros caracteres devem ser 'letras' em sequência
            // - Formato correto: [L][L][l]
            // - Formato incorreto: [n][L][n] 
            char[] vetorGabaritoPlaca = new char[7];
            string gabaritoPlaca = null;

            // Placa padrão:   LLLN N NN --> 'ABC-1234'
            // Placa mercosul: LLLN L NN --> 'ABC1C34'

            bool conversaoCaractere = false;
            int resultado;

            int qtdHifenPlaca = 0;
            int qtdLetrasPlaca = 0;
            int qtdDigitosPlaca = 0;

            string placaSemHifen = null;

            if(placa.Length >= 7 && placa.Length <= 8 && !placa.Contains(" ")) // Formato completo 'ABC-1234'
            {
                int aux = 0;

                foreach(char c in placa)
                {
                    conversaoCaractere = int.TryParse(Convert.ToString(c), out resultado);

                    if(conversaoCaractere) // Se o elemento for do tipo 'numérico'
                    {
                        vetorGabaritoPlaca[aux] = 'n'; // Preenche o gabarito da placa

                        aux++;

                        qtdDigitosPlaca++;

                        placaSemHifen += c.ToString();
                    }
                    else // Se o elemento for do tipo 'caractere'
                    {
                        if (c == '-')
                        {
                            qtdHifenPlaca++;
                        }
                        else
                        {
                            vetorGabaritoPlaca[aux] = 'L'; // Preenche o gabarito da placa

                            aux++;

                            qtdLetrasPlaca++;

                            placaSemHifen += c.ToString();
                        }
                    }
                }

                placaSemHifen = placaSemHifen.ToUpper();
                placa = placa.ToUpper();

                Console.WriteLine($"\n    Placa - sem hifen: {placaSemHifen}");

                // Percorrer o vetor do gabarito placa
                foreach(char c in vetorGabaritoPlaca)
                {
                    gabaritoPlaca += c.ToString();
                }

                Console.WriteLine($"    Placa - gabarito:  {gabaritoPlaca}");

                Console.WriteLine($"\n    Placa - Qtd letras [L]:  {qtdLetrasPlaca}");
                Console.WriteLine($"    Placa - Qtd hifen(s):    {qtdHifenPlaca}");
                Console.WriteLine($"    Placa - Qtd digitos [n]: {qtdDigitosPlaca} \n");


                // Verificando se a placa é válida, conforme o gabarito placa
                if (vetorGabaritoPlaca[0] == 'L' &&
                    vetorGabaritoPlaca[1] == 'L' &&
                    vetorGabaritoPlaca[2] == 'L') { 
                
                    if (qtdLetrasPlaca == 3 && qtdDigitosPlaca == 4) // Se a placa é do padrão normal
                    {
                        Console.WriteLine($"    --> A placa '{placa}' é valida.");

                        return true;

                    }
                    else if (qtdLetrasPlaca == 4 && qtdDigitosPlaca == 3) // Se a placa é do padrão mercosul
                    {
                        if (vetorGabaritoPlaca[4] == 'L')
                        {
                            Console.WriteLine($"    --> A placa (mercosul) '{placaSemHifen}' é valida.");

                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"    --> A placa (mercosul) '{placaSemHifen}' é inválida.");

                            return false;

                        }

                    }
                    else
                    {
                        Console.WriteLine($"    --> A placa {placa} é invalida.");

                        return false;

                    }
                }

                else // Se não for conforme o gabarito, entao a placa é invalida.
                {
                    Console.WriteLine($"    --> A placa {placa} é invalida.");

                    return false;
                }

            }
            else
            {
                Console.WriteLine($"    --> A placa '{placa}' é invalida.");

                return false;
            }
            
        }

        public override string ToString()
        {
            return " Placa: " + placa;
        }
    }
}
