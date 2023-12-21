using System.Diagnostics;

namespace DesafioFundamentos.Models
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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // IMPLEMENTADO!!!
            Console.WriteLine("Digite a placa do veículo para estacionar: (###-####)");
            string placa = Console.ReadLine().ToUpper();
            
            try
            {
                VerificaFormatoDaPlaca(placa);
                veiculos.Add(placa);
                Console.WriteLine("Veículo adicionado!");
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Formato inváldo!");
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione uma tecla para adicionar veiculo com uma placa válida:");
                Console.ReadLine();
                AdicionarVeiculo();
            }
            catch(Exception e)
            {
                Console.WriteLine("Formato inváldo!");
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione uma tecla para adicionar veiculo com uma placa válida:");
                Console.ReadLine();
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover: (###-####)");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // IMPLEMENTADO!!!
            decimal valorTotal = 0;
            string placa = Console.ReadLine().ToUpper();

            try
            {
                VerificaFormatoDaPlaca(placa);
                // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // IMPLEMENTADO!!!
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int totalDeHorasEstacionado = Convert.ToInt32(Console.ReadLine());
                if(totalDeHorasEstacionado > 0)
                {
                    valorTotal = precoInicial + (precoPorHora * totalDeHorasEstacionado);
                }
                else
                {
                    throw new  FormatException("Número de horas inválido");
                }
                                

                // TODO: Remover a placa digitada da lista de veículos
                // IMPLEMENTADO!!!

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine($"Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente: {placa}");
                RemoverVeiculo();
            }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Formato inváldo!");
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione uma tecla para remover veiculo com uma placa válida:");
                Console.ReadLine();
                RemoverVeiculo();
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione uma tecla para remover veiculo com horas váldadas de estacionamento:");
                Console.ReadLine();
                RemoverVeiculo();
            }
            catch(Exception e)
            {
                Console.WriteLine("Formato inváldo!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Pressione uma tecla para remover veiculo com uma placa válida:");
                Console.ReadLine();
                RemoverVeiculo();
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                //IMPLEMENTADO!!!

                for (int contador = 0; contador < veiculos.Count; contador++)
                {
                    Console.WriteLine($"Veículo n° {contador + 1}: {veiculos[contador]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private string VerificaFormatoDaPlaca(string placa){
        
            string[] placaSemHifen = placa.Split("-");
            string[] primeiraStrDaPLaca = placaSemHifen[0].Split("");
            string[] segundaStrDaPLaca = placaSemHifen[1].Split("");

            if(placaSemHifen[0].Length != 3 )
            {
                throw new Exception("Placa deve conter três(3) digitos antes do hífen(-)");
            }
            if(placaSemHifen[1].Length != 4)
            {
                throw new Exception("Placa deve conter quatro(4) digitos depois do hífen(-)");
            }
            else
            {
                return placa;
            }
        }
    }
}
