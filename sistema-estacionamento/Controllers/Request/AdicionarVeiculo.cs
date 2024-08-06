namespace sistema_estacionamento.Controllers.Request
{
    namespace EstacionamentoAPI.Controllers.Requests
    {
        public class AdicionarVeiculo
        {
            public string Placa { get; set; }
            public string Modelo { get; set; }
            public string Cor { get; set; }
        }
    }
}