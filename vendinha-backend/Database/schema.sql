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
