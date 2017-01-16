# TesteOwinSecurity
Implementação de uma Api Rest com autenticação OAuth utilizando Microsoft.Owin.Security e Asp.NET Identity, acessado por um cliente AngularJS.

# Sumário

- [Requisitos](#requisitos)
- [Como executar](#como-executar)
- [Funcionalidades](#funcionalidades)
- [Tecnologias](#tecnologias)

### Requisitos

* Visual Studio 2015

* SQL Server Express


## Como executar

```bash
git clone --depth 1 https://github.com/RafaelLiendo/TesteOwinSecurity.git
```

####Execute os projetos "AngularClient" e "RestApi" simultaneamente. [Instruções aqui.](https://msdn.microsoft.com/en-us/library/ms165413.aspx)


#####*Observações*: 
* Não é necessário instalar as dependências via npm ou instalar o node.js, pois o Visual Studio 2015 executa esta tarefa automaticamente.
* Não é necessário excutar o comando "Update-Database" do migrations, pois a aplicação já excuta esta tarefa automaticamente.




### Funcionalidades

* Autenticação baseada em Tokens

* Tokens no formato JWT

* Expiração de Token (1 min)

* Login com Facebook

* Inicialização do Banco de Dados Automática.

* Documentação da API com Swagger.

### Tecnologias

* Asp.NET Web API

* Asp.NET Identity.

* Entity Framework

* Entity Framework Migrations

* AngularJS

