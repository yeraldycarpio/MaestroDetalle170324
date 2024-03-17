CREATE DATABASE PruebaTecHYCMDB;

CREATE TABLE Fiador(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),
    Correo VARCHAR(100),
    Ocupacion VARCHAR(100),
    Ingreso_mensual DECIMAL(10, 2),
    FechaNacimiento DATE
	);

	use PruebaTecHYCMDB;
CREATE TABLE ReferenciasFamiliares (
    id INT PRIMARY KEY IDENTITY(1,1),
    IdFiador INT,
    Nombre VARCHAR(100),
    Relacion VARCHAR(100),
    Telefono VARCHAR(20),
    Direccion VARCHAR(200),
    FOREIGN KEY (IdFiador) REFERENCES Fiador(Id)  ON DELETE CASCADE
	);

