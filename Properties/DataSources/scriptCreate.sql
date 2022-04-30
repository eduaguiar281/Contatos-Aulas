CREATE TABLE Categorias (Id int not null identity(1,1) primary key,
                         Descricao varchar(50) not null);
GO


CREATE TABLE Contatos (Id int not null identity(1,1) primary key,
                       Celular varchar(20), 
					   Telefone varchar(20) not null, 
					   Nome varchar(50) not null,  
					   Endereco varchar(50) not null, 
					   NumeroCasa varchar(20), 
					   Email varchar(60), 
					   DataCadastro datetime2, 
					   Ativo bit not null default(1), 
					   IdCategoria int,
					   CONSTRAINT FK_ContatosCategorias FOREIGN KEY (IdCategoria)
                       REFERENCES Categorias(Id))

GO