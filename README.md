# Desafio.InfoDengue.API
Criação de uma API em .Net 8. Desafio proposto como parte de uma avaliação técnica

## Tecnologias utilizadas
- .Net Core 8
- Entity Framework Core 8
- Sql Server
- Containeirzação de aplicação com Docker
- Fluent validation
- xUnit para testes unitários
- Refit para acesso de serviço externo

## Padrões utilizados
- DDD
- Repository Pattern
- CQRS Pattern
- Domain notification
- Result Pattern

## Arquitetura
A arquitetura utilizada é a de desenvolvimento em camadas, com foco no domínio da aplicação, utilizando DDD, com as seguintes camadas abaixo:

### API
- Camada de exposição das rotas de API disponíveis.

### Aplicacao
- Camada de aplicação, contendo os casos de uso da aplicação e ligação com os serviços do domínio.

### Dominio
- Camada de domínio e coração do sistema, contendo os casos de uso do sistemaas, entidades e interfaces de comunicação com outras camadas.

### Infraestrutura
- Camada de infra que provê recursos utilizados pelo sistema, tais como a comunicação com o banco de dados.

### Infraestrutura.Integracao
- Subprojeto de infra adicionado para organizar o que é necessário para a Integração com a API do Alerta Dengue, também chamado de Info Dengue.

## Primeiros passos

### Requisitos para rodar a aplicação
Para rodar a aplicação precisa dos seguintes requisitos instalados na máquina
- SDK do .Net Core 8

### Rodando a aplicação localmente
Para rodar localmente, você vai precisar ter instalado o Sql Server Express instalado ou algum servidor externo para o banco
1. Crie um banco de dados com o Sql Server com o nome de sua preferência

>
> :exclamation:
> Observação: Você pode restaurar o banco de dados a partir do dump no caminho do repositório 
> ([link](https://github.com/leosousa/Desafio.InfoDengue.API/blob/feature/v1/docs/bancoDados/InfoDengueDb.bak))
> ou pode deixar a aplicação rodar pela primeira vez que ela criará, caso o banco não esteja criado.
>
>

2. Ajuste a string de conexão no arquivo *appSetings.json* e *appSettings.Development.json* com o seu banco criado. 
Ajuste as variáveis {{SERVER}}, {{DATABASE}}, {{USER}} e {{PASSWORD}} conforme sua configuração. Use o exemplo abaixo para 
ajustar e colar no seu arquivo de configuração
```
  "ConnectionStrings": {
  "DefaultConnection": "Server={{SERVER}};Database={{DATABASE}};User ID={{USER}};Password={{PASSWORD}};TrustServerCertificate=True"
},,
```

3. Inicie a aplicação com o Visual Studio ou digite o comando abaixo na raiz do projeto
```
dotnet run --project "src/InfoDengue.API/InfoDengue.API.csproj"
```
4. Acesse a url
[http://localhost:5264/swagger/index.html](http://localhost:5264/swagger/index.html)