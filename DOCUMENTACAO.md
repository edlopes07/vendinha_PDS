# Documentação da Aplicação

## 1. Apresentação do Sistema

A aplicação tem como objetivo ser uma ferramenta para auxiliar no
monitoramento e gerenciamento de dívidas de pequenas vendinhas.

O sistema permite cadastrar clientes, registrar dívidas associadas a
eles e marcar essas dívidas como pagas, facilitando o controle
financeiro e a organização dos registros.

## 2. Tecnologias Utilizadas

### 2.1 Extensões e Bibliotecas

-   **Microsoft.Data.Sqlite** --- `versão 10.0.14`
-   **Microsoft.EntityFrameworkCore** --- `versão 10.0.14`
-   **Microsoft.EntityFrameworkCore.Sqlite** --- `versão 10.0.14`

### 2.2 Ferramentas e Tecnologias

-   **Visual Studio** --- ambiente de desenvolvimento.
-   **C#** --- linguagem de programação.
-   **SQLite** --- sistema de gerenciamento de banco de dados.

## 3. Funcionalidades

A aplicação disponibiliza as seguintes funcionalidades:

-   **Cadastrar clientes:** permite adicionar novos clientes ao sistema.
-   **Remover clientes:** permite excluir clientes cadastrados.
-   **Editar clientes:** permite atualizar as informações dos clientes.
-   **Adicionar dívidas:** permite registrar novas dívidas associadas
    aos clientes.
-   **Pagar dívidas:** permite marcar uma dívida como paga.

## 4. Regras de Negócio

-   Cada cliente deve possuir um CPF único.
-   Dívidas pagas não podem ser reabertas.
-   Um cliente não pode possuir mais de uma dívida em aberto
    simultaneamente.
-   O CPF informado deve possuir 11 dígitos e apenas números.
-   O cliente deve ter de 15 a 100 anos de idade.
-   O valor da dívida deve ser maior que `R$ 00,00`
