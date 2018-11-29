USE master;
GO

DROP DATABASE IF EXISTS QuakeLog;
GO

CREATE DATABASE QuakeLog;
GO

USE QuakeLog;
GO

/*OK*/
CREATE TABLE Game(
	Id INT NOT NULL,
	Nome VARCHAR(60)

	PRIMARY KEY(Id)
);
GO

/*OK*/
CREATE TABLE Jogador(
	Id INT NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Kills INT,

	PRIMARY KEY(Id)
);
GO

/*OK*/
CREATE TABLE JogadoresGame(
	IdGame INT NOT NULL,
	IdJogador INT NOT NULL,
	Kills INT NOT NULL,

	CONSTRAINT game_jogador_pk PRIMARY KEY(IdGame, IdJogador),
	CONSTRAINT fk_game FOREIGN KEY(IdGame) REFERENCES Game(Id),
	CONSTRAINT fk_jogador FOREIGN KEY(IdJogador) REFERENCES Jogador(Id)
);
GO

/*OK*/
CREATE TABLE CausaMorte(
	Id INT NOT NULL,
	Nome VARCHAR(50) NOT NULL,

	PRIMARY KEY(Id)
);
GO

/*OK*/
CREATE TABLE MortesJogo(
	Id INT IDENTITY(1,1) NOT NULL,
	IdGame INT NOT NULL,
	IdJogadorUm INT,
	IdJogadorDois INT NOT NULL,
	idCausaMorte INT NOT NULL,

	PRIMARY KEY(Id),
	CONSTRAINT fk_game_morte	FOREIGN KEY (IdGame) REFERENCES Game(Id),
	CONSTRAINT fk_jogador_um	FOREIGN KEY (IdJogadorUm) REFERENCES Jogador(Id),
	CONSTRAINT fk_jogador_dois	FOREIGN KEY (IdJogadorDois) REFERENCES Jogador(Id),
	CONSTRAINT fk_causa_morte	FOREIGN KEY (idCausaMorte) REFERENCES CausaMorte(Id)
);
GO