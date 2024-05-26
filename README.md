# DotLanche :hamburger:

## Descrição do Projeto

O DotLanche é uma aplicação para gerenciamento de clientes e pedidos em um sistema de lanchonete. A aplicação é construída usando .NET e utiliza um banco de dados PostgreSQL. O projeto inclui arquivos de configuração do Docker para facilitar o desenvolvimento e a implantação.

## Objetivos

- Gerenciar clientes, produtos e pedidos.
- Facilitar o controle de estoque.
- Automatizar processos de venda e registro de clientes.
- Fornecer uma interface de API para interagir com o sistema.

## Estrutura do Projeto

- **DotLanches.Api**: Contém a API da aplicação.
- **DotLanches.Application**: Contém as regras de negócio e serviços da aplicação.
- **DotLanches.Domain**: Contém as entidades e exceções do domínio.
- **DotLanches.Infra**: Contém a camada de infraestrutura, como repositórios e configuração do banco de dados.

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Configuração do Ambiente

1. Clone o repositório
   ```sh
   git clone https://github.com/lanchesjaamp/dotlanche.git
   cd dotlanche

2. Execute a Aplicação com Docker Compose
   ```sh
   docker-compose build
   docker-compose up

3. Abra no navegador a API pela rota http://localhost:8080/swagger/index.html
