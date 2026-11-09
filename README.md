# Vendinha - Plataforma de Desenvolvimento de Sistemas

Projeto desenvolvido como parte da **P2 da disciplina de Plataforma de Desenvolvimento de Sistemas**.

### Ferramentas utilizadas
- .NET Core/8+ com C#.
- Visual Studio
    #### Extensões / Pacotes NuGet:
- Live Share
- Microsoft.Data.Sqlite
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite

## Integrantes

- Eduardo Lopes Alves
- Rafael Generoso Ponzetto

## Como executar o projeto

Para executar a aplicação, siga os passos abaixo:

1. Abra a solução do projeto no **Visual Studio**.
2. No **Gerenciador de Soluções**, localize a pasta `vendinha-backend`.
3. Execute `vendinha-backend.slnx`
4. Certifique-se de que o projeto `vendinha-backend.Desktop` esteja selecionado como projeto de inicialização.
6. Após configurar, execute o projeto.

A aplicação será iniciada após a compilação do projeto.

## Script SQL

```sql
CREATE TABLE IF NOT EXISTS clientes (
	cpf TEXT PRIMARY KEY,
	nome TEXT NOT NULL,
	email TEXT NULL,
	datanascimento TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS dividas (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	clientecpf TEXT NOT NULL,
	valor REAL NOT NULL CHECK (valor > 0),
	paga INTEGER NOT NULL DEFAULT 0 CHECK (paga IN (0, 1)),
	datacriacao TEXT NOT NULL,
	datapagamento TEXT NULL,
	FOREIGN KEY (clientecpf) REFERENCES clientes(cpf)
);

CREATE INDEX IF NOT EXISTS idx_dividas_clientecpf
	ON dividas(clientecpf);

CREATE UNIQUE INDEX IF NOT EXISTS ux_dividas_aberta_por_cliente
	ON dividas(clientecpf) WHERE paga = 0;
```

### Observações adicionais
- Para realizar alterações e manipular dívidas do cliente:
  1. Clique com o botão direito do mouse na linha do grid;
  2. Escolha a opção desejada (ex: Editar cliente, Dívidas etc...)
- Dívidas dadas como `pagas` não podem ser revertidas.

