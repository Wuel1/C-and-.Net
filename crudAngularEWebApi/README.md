# CRUD para Gestão de Pessoas com C#, .NET, Entity Framework, SQL Server, Angular e Bootstrap

Este projeto é um CRUD (Create, Read, Update, Delete) simples para gestão de pessoas. Cada pessoa possui as informações de nome, último nome e idade. O projeto foi desenvolvido utilizando tecnologias modernas, incluindo C#, .NET, Entity Framework, SQL Server, Angular e Bootstrap. A aplicação é composta por uma API backend e uma interface frontend.

---

## Estrutura do Projeto

### Backend API (C# e .NET)
- **Framework**: .NET Core
- **ORM**: Entity Framework Core
- **Banco de Dados**: SQL Server
- **Documentação**: Swagger

#### Estrutura de Pastas
- **Controllers**: Contém os controladores da API (ex.: `PessoasController.cs`, `WeatherForecastController.cs`).
- **Migrations**: Rastreia alterações no esquema do banco de dados (ex.: arquivos de migração como `creationDB`).
- **Models**: Contém os modelos de dados (ex.: `Pessoa.cs`, `ContextDB.cs`).
- **Properties**: Arquivos de configuração da aplicação.

#### Execução
Para executar a API backend, navegue até a pasta da API e execute:
```bash
dotnet watch run
```
A API será iniciada e ficará ouvindo por requisições. A documentação Swagger estará disponível em `http://localhost:<porta>/swagger`.

### Frontend (Angular)
- **Framework**: Angular
- **Framework de UI**: Bootstrap

#### Estrutura de Pastas
- **Components**: Componentes Angular, como `pessoas.component.html` e `pessoas.component.ts`.
- **Services**: Contém arquivos de serviço para integração com a API (ex.: `pessoa.service.ts`).

#### Execução
Para executar o frontend Angular, navegue até a pasta `AppAngular` e execute:
```bash
ng serve
```
A aplicação estará disponível em `http://localhost:4200`.

---

## Funcionalidades
- Operações de criar, ler, atualizar e deletar para entidades "Pessoa".
- Integração de formulários Angular para entrada de dados no frontend.
- Design responsivo com Bootstrap.
- Integração com API usando serviços Angular.
- Documentação interativa da API com Swagger.

---

## Requisitos Prévios
### Backend
- SDK do .NET Core
- Instância do SQL Server

### Frontend
- Node.js e npm (para Angular CLI)

---

## Instruções de Configuração
### Backend
1. Clone o repositório.
2. Navegue até o diretório da API.
3. Execute o seguinte comando para aplicar as migrações e configurar o banco de dados:
   ```bash
   dotnet ef database update
   ```
4. Inicie a API usando:
   ```bash
   dotnet watch run
   ```

### Frontend
1. Navegue até o diretório `AppAngular`.
2. Instale as dependências:
   ```bash
   npm install
   ```
3. Inicie a aplicação Angular:
   ```bash
   ng serve
   ```

---

## Tecnologias Utilizadas
- **Backend**:
  - .NET Core
  - Entity Framework Core
  - SQL Server
  - Swagger
- **Frontend**:
  - Angular
  - Bootstrap
  

## Capturas de Tela



---

## Autores
[Wandson Emanuel]
