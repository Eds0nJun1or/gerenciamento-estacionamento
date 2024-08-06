using SistemaEstacionamento.Models;

namespace SistemaEstacionamento.Services
{
    public class FuncionarioService
    {
        private static List<Funcionario> _funcionarios = new List<Funcionario>();
        private static int _nextId = 1;

        public Funcionario Create(Funcionario funcionario)
        {
            funcionario.Id = _nextId++;
            _funcionarios.Add(funcionario);
            return funcionario;
        }

        public List<Funcionario> GetAll()
        {
            return _funcionarios;
        }

        public Funcionario GetById(int id)
        {
            return _funcionarios.FirstOrDefault(f => f.Id == id);
        }

        public bool Update(int id, Funcionario funcionario)
        {
            var index = _funcionarios.FindIndex(f => f.Id == id);
            if (index == -1)
            {
                return false;
            }
            funcionario.Id = id;
            _funcionarios[index] = funcionario;
            return true;
        }

        public bool Delete(int id)
        {
            var index = _funcionarios.FindIndex(f => f.Id == id);
            if (index == -1)
            {
                return false;
            }
            _funcionarios.RemoveAt(index);
            return true;
        }
    }
}