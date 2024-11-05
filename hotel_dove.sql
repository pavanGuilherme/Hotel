USE master;
GO

-- Criação do Banco de Dados
CREATE DATABASE hotel_dove;
GO

USE hotel_dove;
GO

--Tabela Países
CREATE TABLE dbo.paises (
    pais_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    pais VARCHAR(56) NOT NULL,
    ddi VARCHAR(3) NULL,
    ativo BIT NOT NULL,
    data_cadastro DATETIME NOT NULL,
    data_ult_alt DATETIME NOT NULL,
    sigla VARCHAR(20) NOT NULL
);
GO

--Tabela Estados
CREATE TABLE dbo.estados (
    estado_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    pais_ID INT NOT NULL,
    estado VARCHAR(56) NOT NULL,
    uf VARCHAR(2) NOT NULL,
    ativo BIT NOT NULL,
    data_cadastro DATETIME NOT NULL,
    data_ult_alt DATETIME NOT NULL,
    FOREIGN KEY (pais_ID) REFERENCES dbo.paises(pais_ID)
);
GO

-- Tabela cidades
CREATE TABLE dbo.cidades (
    cidade_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    estado_ID INT NOT NULL,
    cidade VARCHAR(100) NOT NULL,
    ddd VARCHAR(6) NULL,
    ativo BIT NOT NULL,
    data_cadastro DATETIME NOT NULL,
    data_ult_alt DATETIME NOT NULL
	FOREIGN KEY (estado_ID) REFERENCES dbo.estados(estado_ID)
);
GO

-- Tabela condicaoPagamento
CREATE TABLE dbo.condicaoPagamento (
    CondPagamento_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    condicaoPagamento VARCHAR(50) NOT NULL,
    desconto DECIMAL(10, 2) NULL,
    juros DECIMAL(10, 2) NULL,
    multa DECIMAL(10, 2) NULL,
    ativo BIT NOT NULL,
    data_cadastro DATE NOT NULL,
    data_ult_alt DATE NOT NULL
);
GO

-- Tabela formaPagamento
CREATE TABLE dbo.formaPagamento (
    formaPagamento_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    formaPagamento VARCHAR(50) NOT NULL,
    ativo BIT NOT NULL,
    dataCadastro DATE NOT NULL,
    dataUltAlt DATE NOT NULL
);
GO

-- Tabela parcelas
CREATE TABLE dbo.parcelas (
    parcela_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    numeroParcela INT NOT NULL,
    dias INT NOT NULL,
    porcentagem DECIMAL(5, 2) NOT NULL,
    condPagamento_ID INT NOT NULL,
    formaPagamento_ID INT NOT NULL
	FOREIGN KEY (condPagamento_ID) REFERENCES dbo.condicaoPagamento(condPagamento_ID),
	FOREIGN KEY (formaPagamento_ID) REFERENCES dbo.formaPagamento(formaPagamento_ID)
);
GO


--Tabela Forncedor
CREATE TABLE dbo.fornecedor (
    fornecedor_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    tipo_pessoa BIT NOT NULL,
    fornecedor_razao_social VARCHAR(255) NOT NULL,
    apelido_nome_fantasia VARCHAR(255) NOT NULL,
    endereco VARCHAR(255) NOT NULL,
    bairro VARCHAR(255) NOT NULL,
    numero INT NOT NULL,
    cep VARCHAR(20) NOT NULL,
    complemento VARCHAR(255) NULL,
    email VARCHAR(255) NULL,
    telefone VARCHAR(20) NULL,
    celular VARCHAR(20) NULL,
    nome_contato VARCHAR(255) NULL,
    cpf_cnpj VARCHAR(20) NOT NULL,
    rg_ie VARCHAR(20) NULL,
    data_cadastro DATETIME NOT NULL,
    data_ult_alt DATETIME NOT NULL,
    ativo BIT NOT NULL,
	CondPagamento_ID INT NOT NULL,
    cidade_id INT NOT NULL,
    FOREIGN KEY (cidade_id) REFERENCES dbo.cidades(cidade_ID),
	FOREIGN KEY (CondPagamento_ID) REFERENCES dbo.condicaoPagamento(CondPagamento_ID)
);
GO

CREATE TABLE dbo.produto (
    produto_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    produto VARCHAR(200) NOT NULL,
    unidade VARCHAR(5) NOT NULL,
    saldo INT NOT NULL,
    custo_medio DECIMAL(10,4) NULL,
    preco_venda DECIMAL(10,2) NULL,
    preco_ult_compra DECIMAL(10,4) NULL,
    data_ult_compra DATE NULL,
    observacao VARCHAR(200) NULL,
    ativo BIT NOT NULL,
    data_cadastro DATE NOT NULL,
    data_ult_alt DATE NOT NULL,
    fornecedor_ID INT NOT NULL,
    FOREIGN KEY (fornecedor_ID) REFERENCES dbo.fornecedor(fornecedor_ID),


);
GO

-- Tabela clientes
CREATE TABLE dbo.cliente (
    cliente_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    data_nascimento DATE NOT NULL,
    telefone VARCHAR(15) NULL,
    cpf VARCHAR(14) NOT NULL,
    email VARCHAR(100) NOT NULL,
    rg VARCHAR(20) NULL,
    cep VARCHAR(10) NOT NULL,
    logradouro VARCHAR(100) NOT NULL,
    numero VARCHAR(10) NOT NULL,
    bairro VARCHAR(100) NOT NULL,
    ativo BIT NOT NULL,
    data_cadastro DATETIME NOT NULL,
    data_ult_alt DATETIME NOT NULL,
    apelido VARCHAR(100) NULL,
    celular VARCHAR(15) NULL,
    nome_contato VARCHAR(100) NULL,
    estado VARCHAR(100) NULL,
    pais VARCHAR(100) NULL,
    condicao VARCHAR(100) NULL,
    tipo_pessoa VARCHAR(10) NULL,
    complemento VARCHAR(50) NULL,
	CondPagamento_ID INT NOT NULL, 
	cidade_id INT NOT NULL,
	FOREIGN KEY (cidade_ID) REFERENCES dbo.cidades(cidade_ID),
	FOREIGN KEY (CondPagamento_ID) REFERENCES dbo.condicaoPagamento(CondPagamento_ID)

);
GO


-- Tabela contasPagar
CREATE TABLE dbo.contasPagar (
    numeroNota INT NOT NULL,
    serie INT NOT NULL,
    fornecedor_ID INT NOT NULL,
    dataEmissao DATE NOT NULL,
    FormaPagamento_ID INT NOT NULL,
    parcela INT NOT NULL,
    valorParcela DECIMAL(10, 2) NOT NULL,
    data_vencimento DATE NOT NULL,
    data_pagamento DATE NULL,
    juros DECIMAL(10, 2) NULL,
    multa DECIMAL(10, 2) NULL,
    desconto DECIMAL(10, 2) NULL,
    valor_pago DECIMAL(10, 2) NULL,
    data_cancelamento DATE NULL,
    observacao VARCHAR(200) NULL,
    data_cadastro DATE NOT NULL,
    data_ult_alt DATE NOT NULL,
    usuario VARCHAR(50) NOT NULL,
    PRIMARY KEY (numeroNota, serie, fornecedor_ID, parcela)
);
GO

-- Tabela contasReceber
CREATE TABLE dbo.contasReceber (
    numeroNota INT NOT NULL,
    serie INT NOT NULL,
    cliente_ID INT NOT NULL,
    data_emissao DATE NOT NULL,
    FormaPagamento_ID INT NOT NULL,
    parcela INT NOT NULL,
    valor_parcela DECIMAL(10, 2) NOT NULL,
    data_vencimento DATE NOT NULL,
    data_recebimento DATE NULL,
    juros DECIMAL(10, 2) NULL,
    multa DECIMAL(10, 2) NULL,
    desconto DECIMAL(10, 2) NULL,
    valor_recebido DECIMAL(10, 2) NULL,
    data_cancelamento DATE NULL,
    observacao VARCHAR(200) NULL,
    data_cadastro DATE NOT NULL,
    data_ult_alt DATE NOT NULL,
    usuario VARCHAR(50) NOT NULL,
	FOREIGN KEY (formaPagamento_ID) REFERENCES dbo.formaPagamento(formaPagamento_ID),
    PRIMARY KEY (numeroNota, serie, cliente_ID, parcela)
);
GO


-- Tabela fornecedor
CREATE TABLE dbo.fornecedores (
    fornecedor_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    tipo_pessoa BIT NOT NULL,
    fornecedor_razao_social VARCHAR(255) NOT NULL,
    apelido_nome_fantasia VARCHAR(255) NOT NULL,
    endereco VARCHAR(255) NOT NULL,
    bairro VARCHAR(255) NOT NULL,
    numero INT NOT NULL,
    cep VARCHAR(20) NOT NULL,
    complemento VARCHAR(255) NULL,
    email VARCHAR(255) NULL,
    telefone VARCHAR(20) NULL,
    celular VARCHAR(20) NULL,
    nome_contato VARCHAR(255) NULL,
    cpf_cnpj VARCHAR(20) NOT NULL,
    rg_ie VARCHAR(20) NULL,
    data_cadastro DATETIME NOT NULL DEFAULT GETDATE(),
    data_ult_alt DATETIME NOT NULL DEFAULT GETDATE(),
    ativo BIT NOT NULL,
    cidade_id INT NOT NULL
);
GO

-- Tabela funcionarios
CREATE TABLE dbo.funcionarios (
    funcionario_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nome VARCHAR(70) NOT NULL,
    sobrenome VARCHAR(50) NULL,
    endereco VARCHAR(150) NULL,
    bairro VARCHAR(100) NULL,
    numero INT NULL,
    cep VARCHAR(8) NULL,
    complemento VARCHAR(100) NULL,
    sexo VARCHAR(10) NULL,
    email VARCHAR(100) NULL,
    telefone VARCHAR(50) NULL,
    celular VARCHAR(50) NULL,
    data_nascimento DATE NULL,
    cpf VARCHAR(14) NULL,
    rg VARCHAR(14) NULL,
    cargo VARCHAR(50) NOT NULL,
    salario DECIMAL(10, 2) NOT NULL,
    pis VARCHAR(11) NOT NULL,
    data_admissao DATETIME NOT NULL,
    data_demissao DATE NULL,
    ativo BIT NOT NULL,
    data_cadastro DATE NOT NULL,
    data_ult_alt DATE NOT NULL,
    cidade_ID INT NULL,

	FOREIGN KEY (cidade_ID) REFERENCES dbo.cidades(cidade_ID)
);
GO

CREATE TABLE dbo.quartos (
    quarto_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    numero VARCHAR(10) NOT NULL,
    andar INT NOT NULL,
    tipo VARCHAR(20) NOT NULL,
    descricao VARCHAR(255) NULL,
    ativo BIT NOT NULL,
    data_cadastro DATETIME NOT NULL,
    data_ult_alt DATETIME NOT NULL,
    disponivel BIT NOT NULL,
    valor DECIMAL(10,2) NULL
);
GO

-- Tabela nota_compra
CREATE TABLE dbo.nota_compra (
    num_Nota INT NOT NULL,
    modelo INT NOT NULL,
    serie INT NOT NULL,
    fornecedor_ID INT NOT NULL,
    data_emissao DATE NOT NULL,
    data_chegada DATE NOT NULL,
    tipo_frete BIT NOT NULL,
    valor_frete DECIMAL(10, 2) NULL,
    valor_seguro DECIMAL(10, 2) NULL,
    outras_despesas DECIMAL(10, 2) NULL,
    total_produtos DECIMAL(10, 2) NOT NULL,
    total_pagar DECIMAL(10, 2) NOT NULL,
    Cond_Pagamento_ID INT NOT NULL,
    observacao VARCHAR(200) NULL,
    data_cancelamento DATE NULL,
    data_cadastro DATE NOT NULL,
    data_ult_alt DATE NOT NULL,
    PRIMARY KEY (num_Nota, modelo, serie, fornecedor_ID)
);
GO

-- Tabela hospede
CREATE TABLE dbo.hospede (
    hospede_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    sobrenome VARCHAR(100) NULL,
    sexo CHAR(1) NULL,
    ativo BIT NOT NULL,
    cep VARCHAR(10) NULL,
    logradouro VARCHAR(150) NULL,
    numero VARCHAR(10) NULL,
    complemento VARCHAR(100) NULL,
    bairro VARCHAR(100) NULL,
    cidade_id INT NOT NULL,
    estrangeiro BIT NULL,
    cpf VARCHAR(14) NULL,
    rg VARCHAR(20) NULL,
    passaporte VARCHAR(20) NULL,
    telefone VARCHAR(15) NULL,
    email VARCHAR(100) NULL,
    data_nascimento DATE NULL,
    pcd BIT NULL,
    observacao TEXT NULL,
    data_cadastro DATETIME NOT NULL,
    data_ult_alt DATETIME NULL
	FOREIGN KEY (cidade_ID) REFERENCES dbo.cidades(cidade_ID)

);
GO

CREATE TABLE dbo.reserva (
    reserva_ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    cliente_ID INT NOT NULL,
    nome_cliente VARCHAR(100) NOT NULL,
    cpf_cliente VARCHAR(14) NULL,
    celular_cliente VARCHAR(15) NULL,
    quarto_ID INT NOT NULL,
    numero_quarto VARCHAR(10) NOT NULL,
    andar INT NULL,
    valor_diaria DECIMAL(10,2) NOT NULL,
    valor_total DECIMAL(10,2) NOT NULL,
    data_checkin DATE NOT NULL,
    data_checkout DATE NOT NULL,
    num_dias INT NOT NULL,
    status_pagamento BIT NOT NULL,
    condPagamento_ID INT NULL,
    condicao_pagamento VARCHAR(100) NULL,
    status_reserva VARCHAR(50) NOT NULL,
    data_cancelamento DATE NULL,
    observacao VARCHAR(200) NULL,
    ativo BIT NOT NULL,
    data_cadastro DATETIME NOT NULL,
    data_ult_alt DATETIME NOT NULL,
	hospede_ID INT NULL,
	hospede_nome varchar(55) NULL, 
    FOREIGN KEY (cliente_ID) REFERENCES dbo.cliente(cliente_ID),
	FOREIGN KEY (hospede_ID) REFERENCES dbo.hospede(hospede_ID),
	FOREIGN KEY (condPagamento_ID) REFERENCES dbo.condicaoPagamento(condPagamento_ID), 
    FOREIGN KEY (quarto_ID) REFERENCES dbo.quartos(quarto_ID),
 
);
GO




