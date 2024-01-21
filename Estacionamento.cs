using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Sistema_de_estacionamento
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();

            string placa = "";
            while (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa = Console.ReadLine();

                if (string.IsNullOrEmpty(placa))
                {
                    Console.WriteLine("Placa inválida. Por favor, tente novamente.");
                    placa = ""; // Redefine a placa para vazia para continuar o loop
                }
                else
                {
                    Regex placaRegex = new Regex(@"^[a-zA-Z]{3}[0-9][a-zA-Z0-9][0-9]{2}$");
                    if (!placaRegex.IsMatch(placa))
                    {
                        Console.WriteLine("Placa inválida. Por favor, tente novamente.");
                        placa = "";

                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadLine(); 
                        
                    }
                }
            }
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.Clear();

            string placa = "";

            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                string input = "";
                while (!decimal.TryParse(input, out decimal horas))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    input = Console.ReadLine();
                    
                    if (!decimal.TryParse(input, out horas))
                    {
                        Console.WriteLine("Por favor, digite uma hora válida.");
                        input = "";

                        Console.WriteLine("Pressione uma tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                    } 
                    else
                    {
                        decimal valorTotal = precoInicial + (precoPorHora * horas);
       
                        veiculos.Remove(placa);

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                placa = ""; // Redefine a placa para vazia para continuar o loop

                Console.WriteLine("\nPressione uma tecla para continuar");
                Console.ReadLine();
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i+1}º vaga: {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}