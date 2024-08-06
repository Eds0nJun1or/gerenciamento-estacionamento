# Sistema de Estacionamento

Este é um sistema de gerenciamento de estacionamento desenvolvido em ASP.NET Core. Ele permite adicionar, listar, e remover veículos, bem como gerenciar funcionários. A aplicação também calcula o valor do estacionamento com base no tempo de permanência e em horários de pico.

## Funcionalidades

- Adicionar veículo
- Listar veículos
- Remover veículo
- Verificar vagas disponíveis
- Gerenciar funcionários (criar, listar, atualizar, e excluir)

## Tecnologias Utilizadas

- ASP.NET Core
- C#
- Swagger para documentação da API

## Estrutura do Projeto

```plaintext
SistemaEstacionamento/
│
├── Controllers/
│   ├── Requests/
│   │   ├── AdicionarVeiculo.cs
│   │   └── RemoverVeiculo.cs
│   ├── EstacionamentoController.cs
│   └── FuncionarioController.cs
│
├── Models/
│   ├── Estacionamento.cs
│   ├── Funcionario.cs
│   └── Veiculo.cs
│
├── Services/
│   ├── EstacionamentoService.cs
│   └── FuncionarioService.cs
│
├── sistema_estacionamento.csproj
├── Program.cs
└── appsettings.json
```

## Configuração e Execução

1. **Clone o repositório:**
   ```sh
   git clone <https://github.com/Eds0nJun1or/gerenciamento-estacionamento>
   cd SistemaEstacionamento
   ```

2. **Instale as dependências:**
   Certifique-se de ter o .NET SDK instalado. Então, restaure as dependências do projeto:
   ```sh
   dotnet restore
   ```

3. **Execute a aplicação:**
   ```sh
   dotnet run
   ```

4. **Acesse a documentação da API:**
   A documentação da API estará disponível em `https://localhost:<porta>/swagger` quando a aplicação estiver em execução.

## Endpoints da API

### Veículos

- **Adicionar Veículo**
  ```http
  POST /Estacionamento/Adicionar
  ```
  **Request Body:**
  ```json
  {
    "placa": "string",
    "modelo": "string",
    "cor": "string"
  }
  ```

- **Listar Veículos**
  ```http
  GET /Estacionamento/Listar
  ```

- **Remover Veículo**
  ```http
  DELETE /Estacionamento/Remover
  ```
  **Request Body:**
  ```json
  {
    "placa": "string"
  }
  ```

- **Vagas Disponíveis**
  ```http
  GET /Estacionamento/VagasDisponiveis
  ```

### Funcionários

- **Criar Funcionário**
  ```http
  POST /Funcionario
  ```
  **Request Body:**
  ```json
  {
    "nome": "string",
    "senha": "string"
  }
  ```

- **Listar Funcionários**
  ```http
  GET /Funcionario
  ```

- **Obter Funcionário por ID**
  ```http
  GET /Funcionario/{id}
  ```

- **Atualizar Funcionário**
  ```http
  PUT /Funcionario/{id}
  ```
  **Request Body:**
  ```json
  {
    "nome": "string",
    "senha": "string"
  }
  ```

- **Excluir Funcionário**
  ```http
  DELETE /Funcionario/{id}
  ```

## Como Contribuir

1. Fork este repositório.
2. Crie um branch para sua feature (`git checkout -b feature/fooBar`).
3. Commit suas alterações (`git commit -am 'Add some fooBar'`).
4. Push para o branch (`git push origin feature/fooBar`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---
