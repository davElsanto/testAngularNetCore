create table Solicitudes (
    Id int not null,
    UsuarioId int,
    DescripcionSolicitud nvarchar(50) not null,
    Justificativo nvarchar(50) not null,
    Estado nvarchar(50),
    DetalleGestion nvarchar(50),
    FechaIngreso datetime,
    FechaActualizacion datetime,
    FechaGestion datetime,
    PRIMARY KEY(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
)