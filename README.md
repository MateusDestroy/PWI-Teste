# 📌 Projeto Chat API

## 🎯 Objetivo
O projeto tem como finalidade a criação de uma **API para chat**, acompanhada de um pequeno exemplo de telas que demonstram como a API poderia ser utilizada em um Front-End.  
Essas telas servem para ilustrar o funcionamento da API dentro de uma aplicação.

---


## 🛠️ Tecnologias Utilizadas
- **IDE:** Visual Studio Code  
- **Linguagem:** C#  
- **Banco de Dados:** SQL Server Express + SSMS (versão mais recente)  
- **SDK:** .NET 7.0.410  
- **Aprendizado:** Materiais da [DIO - Formação .NET Developer](https://web.dio.me/track/formacao-dotnet-developer/course/entity-framework-e-crud/learning/6c1b5e87-f9ef-40fe-8173-385608a66647?autoplay=1)  


---

## 🚀 Pré-requisitos para Rodar
Antes de executar o projeto, verifique:
1. Instale o **.NET SDK 7.0.410** (ou a versão utilizada no projeto).  
2. Confirme que o **SQL Server Express** e o **SSMS** estão atualizados.  
3. Configure a **connection string** no arquivo `appsettings.Development.json` para apontar para seu banco de dados.  

---


### 🖼️ Exemplo de tela para API
https://www.figma.com/design/ZJVaUswEk9FrMnghKbDRmQ/Untitled?node-id=0-1&m=dev&t=AbMVfLVrPvDId42Z-1


---


### ⚠️ Erros Comuns

1. Caso tenha problema de subir a api e ela não rodar direito, verifique a versão do SDK.
2. Caso tenha executardo e esteja dando **not found**, tente usar esse comando **dotnet(dotnet watch -lp https)** || mensagem de erro = caso seja **not found** - **warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3] Failed to determine the https port for redirect**.
3. Verifique se a conexão como banco está certa.
4. Tenha certeza que todos os pacontes estão instalados corretamente.

   
---


## 🗄️ Migrations

Primeiro criei minha pasta **Entities** para fazer minhas entidades à serem criadas e transfomadas no nosso banco de dados.

Logo depois utilizei uma pequena função do **dotnet** para fazer a transfomação das minhas **Entities** em informações para subir para meu banco de dados,
eu usei o **dotnet-ef migrations add Pwi** e assim transformei as informações para serem lidas e executadas para fazer o meu banco de dados com minhas tabelas e colunas prontas

Para subir todas essa informações para o banco de dados, eu usei o comando **dotnet-ef database update** e assim todas as informações forma passadas
para o SqlServer


---

### ▶️ Executando o Projeto
```bash
pacotes necessário, caso não tenha na sua maquina:
dotnet tool install --global dotnet-ef

pacote a nivel de projeto, necessario adicionar para rodar o projeto - dependecia do EntityFrameworkCore:
dotnet add package Microsoft.EntityFrameworkCore.Design

pacote a nivel de projeto, necessario adicionar para rodar nosso banco de dados - depdencia do EntityFrameworkCore:
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet restore
dotnet build - para build do projeto
dotnet watch run - para não ter que matar nossa aplicação para realizar teste ao fazer alteração
dotnet run
