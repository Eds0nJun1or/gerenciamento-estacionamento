using sistema_estacionamento.Models;
using System.Text.RegularExpressions;

namespace SistemaEstacionamento.Services
{
    public class EstacionamentoService
    {
        private const int TotalVagas = 20;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public void AdicionarVeiculo(string placa, string modelo, string cor)
        {
            if (veiculos.Count >= TotalVagas)
            {
                throw new InvalidOperationException("Estacionamento lotado");
            }

            if (ValidarPlaca(placa))
            {
                var veiculo = new Veiculo
                {
                    Placa = placa.ToUpper(),
                    Modelo = modelo,
                    Cor = cor,
                    HorarioEntrada = DateTime.Now
                };
                veiculos.Add(veiculo);
            }
            else
            {
                throw new ArgumentException("Placa inválida");
            }
        }

        public bool RemoverVeiculo(string placa, out decimal valorTotal)
        {
            valorTotal = 0;
            var veiculo = veiculos.FirstOrDefault(v => v.Placa.ToUpper() == placa.ToUpper());
            if (veiculo != null)
            {
                veiculo.HorarioSaida = DateTime.Now;
                var horas = (veiculo.HorarioSaida.Value - veiculo.HorarioEntrada).TotalHours;
                valorTotal = CalcularValorEstacionamento(horas);
                veiculos.Remove(veiculo);
                return true;
            }
            return false;
        }

        public List<Veiculo> ListarVeiculos()
        {
            return veiculos;
        }

        public int VagasDisponiveis()
        {
            return TotalVagas - veiculos.Count;
        }

        private bool ValidarPlaca(string placa)
        {
            string regexPlacaAntiga = "^[A-Z]{3}[0-9]{4}$";
            string regexPlacaNova = "^[A-Z]{4}[0-9]{3}$";

            return Regex.IsMatch(placa, regexPlacaAntiga) || Regex.IsMatch(placa, regexPlacaNova);
        }

        private decimal CalcularValorEstacionamento(double horas)
        {
            var horaAtual = DateTime.Now.TimeOfDay;
            bool horarioDePico = (horaAtual >= new TimeSpan(8, 0, 0) && horaAtual <= new TimeSpan(9, 0, 0)) ||
                                 (horaAtual >= new TimeSpan(12, 0, 0) && horaAtual <= new TimeSpan(13, 0, 0)) ||
                                 (horaAtual >= new TimeSpan(18, 0, 0) && horaAtual <= new TimeSpan(19, 0, 0));

            if (horas <= 2)
            {
                return horarioDePico ? 5 : 4;
            }
            else
            {
                return (horarioDePico ? 5 : 4) + (decimal)((horas - 2) * (horarioDePico ? 2 : 1));
            }
        }
    }
}