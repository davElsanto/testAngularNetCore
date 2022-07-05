create table Usuarios (
    Id int not null AUTO_INCREMENT,
    Nombre nvarchar(50) not null,
    Clave nvarchar(50) not null,
    EsAdmin BOOLEAN,
    PRIMARY KEY(Id)
)