using System.Text.RegularExpressions;

namespace EstacionamentoAPI.Models
{
    public class Estacionamento
    {
        private List<string> veiculos = new List<string>();

        public void AdicionarVeiculo(string placa)
        {
            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa.ToUpper());
            }
            else
            {
                throw new ArgumentException("Placa inválida");
            }
        }

        public bool RemoverVeiculo(string placa, int horas, out decimal valorTotal)
        {
            valorTotal = 0;
            placa = placa.ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                valorTotal = CalcularValorEstacionamento(horas);
                veiculos.Remove(placa);
                return true;
            }

            return false;
        }

        public List<string> ListarVeiculos()
        {
            return veiculos;
        }

        private bool ValidarPlaca(string placa)
        {
            string regexPlacaAntiga = "^[A-Z]{3}[0-9]{4}$";
            string regexPlacaNova = "^[A-Z]{4}[0-9]{3}$";

            return Regex.IsMatch(placa, regexPlacaAntiga) || Regex.IsMatch(placa, regexPlacaNova);
        }

        private decimal CalcularValorEstacionamento(int horas)
        {
            if (horas <= 2)
            {
                return 4;
            }
            else
            {
                return 4 + (horas - 2) * 1;
            }
        }
    }
}
