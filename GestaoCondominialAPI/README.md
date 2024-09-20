Pedro Henrique Endo de Oliveira - RM551446
Igor Ribeiro Anccilotto -RM550415
Matheus Colossal - RM 99572
Joao Vitor Souza Nunes - RM 550381
Enzo Oliveira Bernardo - RM 551356



Gest�o Condominial API
Descri��o
A API de Gest�o Condominial � uma aplica��o desenvolvida em ASP.NET Core Web API que permite a administra��o e gerenciamento de condom�nios e seus moradores. A API inclui funcionalidades para gerenciar informa��es sobre condom�nios, moradores, pagamentos, faturas, manuten��es e servi�os.

Arquitetura
A API foi desenvolvida utilizando a arquitetura monol�tica. Optamos por essa abordagem devido � simplicidade e ao menor overhead de comunica��o entre componentes, o que facilita o desenvolvimento e a manuten��o para um projeto com escopo inicial definido.

Arquitetura Monol�tica
Vantagens:

Simplicidade na implementa��o e na manuten��o.
Menor complexidade na comunica��o entre componentes.
Desvantagens:

Potencial dificuldade em escalar componentes individualmente.
Maior risco de impacto de falhas em toda a aplica��o.
Requisitos
.NET 7.0 ou superior
Oracle Database
Entity Framework Core
Swagger/OpenAPI
Instala��o
Clone o Reposit�rio:

bash
Copiar c�digo
git clone https://github.com/natevitor/GestaoCondominialAPI.git
cd seu-repositorio
Restaurar Depend�ncias:

bash
Copiar c�digo
dotnet restore
Configurar o Banco de Dados:

Certifique-se de ter um banco de dados Oracle configurado e atualizado com as tabelas necess�rias. Atualize a string de conex�o no arquivo appsettings.json:

json
Copiar c�digo
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

Execute o script SQL fornecido para criar as tabelas no banco de dados Oracle. Certifique-se de que as tabelas s�o criadas com as restri��es corretas.

Executar a Aplica��o:

bash
dotnet run

Endpoints

Condom�nios
GET /api/condominios
Obt�m a lista de todos os condom�nios.
GET /api/condominios/{id}
Obt�m detalhes de um condom�nio espec�fico.
POST /api/condominios
Cria um novo condom�nio.
PUT /api/condominios/{id}
Atualiza um condom�nio existente.
DELETE /api/condominios/{id}
Remove um condom�nio.


Moradores
GET /api/moradores
Obt�m a lista de todos os moradores.
GET /api/moradores/{id}
Obt�m detalhes de um morador espec�fico.
POST /api/moradores
Cria um novo morador.
PUT /api/moradores/{id}
Atualiza um morador existente.
DELETE /api/moradores/{id}
Remove um morador.


Pagamentos
GET /api/pagamentos
Obt�m a lista de todos os pagamentos.
GET /api/pagamentos/{id}
Obt�m detalhes de um pagamento espec�fico.
POST /api/pagamentos
Cria um novo pagamento.
PUT /api/pagamentos/{id}
Atualiza um pagamento existente.
DELETE /api/pagamentos/{id}
Remove um pagamento.
Faturas

Design Patterns
Singleton Pattern: Utilizado para o gerenciador de configura��es, garantindo que uma �nica inst�ncia seja utilizada durante a execu��o da aplica��o.