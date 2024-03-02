# EscuelaTicket

### Base de datos SQL Server
```
CREATE DATABASE EscuelaTicket;
GO

USE EscuelaTicket;
GO

CREATE TABLE Usuarios (
    IDUsuario INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Contraseña NVARCHAR(50)
);

CREATE TABLE Problemas (
    IDProblema INT PRIMARY KEY,
    IDUsuario INT FOREIGN KEY REFERENCES Usuarios(IDUsuario),
    Problema NVARCHAR(MAX),
    Estado NVARCHAR(50)
);

CREATE TABLE ProblemasFrecuentes (
    IDProblemaFrecuente INT PRIMARY KEY,
    Problema NVARCHAR(MAX),
    Solucion NVARCHAR(MAX)
);
```
