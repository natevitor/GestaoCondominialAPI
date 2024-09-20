Pedro Henrique Endo de Oliveira - RM551446
Igor Ribeiro Anccilotto -RM550415
Matheus Colossal - RM 99572
Joao Vitor Souza Nunes - RM 550381
Enzo Oliveira Bernardo - RM 551356



Gestão Condominial API
Descrição
A API de Gestão Condominial é uma aplicação desenvolvida em ASP.NET Core Web API que permite a administração e gerenciamento de condomínios e seus moradores. A API inclui funcionalidades para gerenciar informações sobre condomínios, moradores, pagamentos, faturas, manutenções e serviços.

Arquitetura
A API foi desenvolvida utilizando a arquitetura monolítica. Optamos por essa abordagem devido à simplicidade e ao menor overhead de comunicação entre componentes, o que facilita o desenvolvimento e a manutenção para um projeto com escopo inicial definido.

Arquitetura Monolítica
Vantagens:

Simplicidade na implementação e na manutenção.
Menor complexidade na comunicação entre componentes.
Desvantagens:

Potencial dificuldade em escalar componentes individualmente.
Maior risco de impacto de falhas em toda a aplicação.
Requisitos
.NET 7.0 ou superior
Oracle Database
Entity Framework Core
Swagger/OpenAPI
Instalação
Clone o Repositório:

bash
Copiar código
git clone https://github.com/natevitor/GestaoCondominialAPI.git
cd seu-repositorio
Restaurar Dependências:

bash
Copiar código
dotnet restore
Configurar o Banco de Dados:

Certifique-se de ter um banco de dados Oracle configurado e atualizado com as tabelas necessárias. Atualize a string de conexão no arquivo appsettings.json:

json
Copiar código
{
  "ConnectionStrings": {
    "DefaultConnection": "User Id=RM550381;Password=221103;Data Source=//Oracle.fiap.com.br:1521/ORCL;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

Criar o Banco de Dados:

Execute o script SQL fornecido para criar as tabelas no banco de dados Oracle. Certifique-se de que as tabelas são criadas com as restrições corretas.

Executar a Aplicação:

bash
dotnet run

Endpoints

Condomínios
GET /api/condominios
Obtém a lista de todos os condomínios.
GET /api/condominios/{id}
Obtém detalhes de um condomínio específico.
POST /api/condominios
Cria um novo condomínio.
PUT /api/condominios/{id}
Atualiza um condomínio existente.
DELETE /api/condominios/{id}
Remove um condomínio.


Moradores
GET /api/moradores
Obtém a lista de todos os moradores.
GET /api/moradores/{id}
Obtém detalhes de um morador específico.
POST /api/moradores
Cria um novo morador.
PUT /api/moradores/{id}
Atualiza um morador existente.
DELETE /api/moradores/{id}
Remove um morador.


Pagamentos
GET /api/pagamentos
Obtém a lista de todos os pagamentos.
GET /api/pagamentos/{id}
Obtém detalhes de um pagamento específico.
POST /api/pagamentos
Cria um novo pagamento.
PUT /api/pagamentos/{id}
Atualiza um pagamento existente.
DELETE /api/pagamentos/{id}
Remove um pagamento.
Faturas

Design Patterns
Singleton Pattern: Utilizado para o gerenciador de configurações, garantindo que uma única instância seja utilizada durante a execução da aplicação.