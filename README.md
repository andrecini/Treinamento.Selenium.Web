# ASP.NET Core + Selenium

Esta aplicação foi feita com intuito de treinar a utilização do Selenium para gerar Evidências de Testes de Integração de forma automatizada.

## Tecnologias Utilizadas
- ASP.NET Core (.Net 7);
- FluentValidator;
- EntityFramework;
- Sellenium;
- XUnity;

## Descrição da Aplicação

A aplicação conta com um CRUD simples de Pessoas, como uma Lista de Contatos. Nela temos as seguintes telas:
- Listagem
- Cadastro
- Visualização/Edição

## Como rodar os Testes de Integração com Selenium?

Siga o Passo a Passo a seguir:
1. Clone o repositório;
2. Abra a solução e rode o projeto ASP.NET Core MVC;
3. Verifique a porta do localhost e deixe a aplicação rodadando;
4. Abra a solução em outra aba;
5. Abra o Projeto de Testes de Integração;
6. Vá na Classe SettingsHelper (na pasta Helpers) e verifique se a propriedade URL bate com o da aplicação executando da outra solução (caso não esteja, copie a url e troque na propriedade);
7. Rode os testes com o Test Explorer e Veja a mágica acontecer :)
  

  
