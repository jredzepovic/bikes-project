use master;
go

create database RIS_Bicikli;
go

use RIS_Bicikli;
go

create table [Role] (
    Id int primary key identity(1, 1) not null,
    Name nvarchar(20) not null
);
go

create table [County] (
    Id int primary key identity(1, 1) not null,
    Name nvarchar(50) not null
);
go

create table [User] (
    Id int primary key identity(1, 1) not null,
    FirstName nvarchar(20) not null,
    LastName nvarchar(20) not null,
    OIB nchar(11) not null,
    Phone nchar(20) not null,
    CellPhone nchar(20) not null,
    Email nvarchar(40) not null,
    Address nvarchar(100) not null,
    Password char(64) not null,
    IdRole int not null,
    IdCounty int not null,
    CONSTRAINT FK_User_Role FOREIGN KEY (IdRole) REFERENCES [Role] (Id),
    CONSTRAINT FK_User_County FOREIGN KEY (IdCounty) REFERENCES [County] (Id)
);
go

create table [BikeType] (
    Id int primary key identity(1, 1) not null,
    Name nvarchar(20) not null
);
go

create table [BikeCondition] (
    Id int primary key identity(1, 1) not null,
    Name nvarchar(20)
);
go

create table [Bike] (
    Id int primary key identity(1, 1) not null,
    Name nvarchar(40) not null,
    TireSize nvarchar(20) null,
    Speeds int null,
    Weight decimal(18, 2) null,
    Color nvarchar(20) null,
    PublishDate datetime not null,
    Description nvarchar(max) null,
    Image varbinary(max) null,
    Price decimal(18, 2) not null,
    IdUser int not null,
    IdCounty int not null,
    IdBikeCondition int not null,
    IdBikeType int not null,
    CONSTRAINT FK_Bike_User FOREIGN KEY (IdUser) REFERENCES [User] (Id),
    CONSTRAINT FK_Bike_County FOREIGN KEY (IdCounty) REFERENCES [County] (Id),
    CONSTRAINT FK_Bike_BikeCondition FOREIGN KEY (IdBikeCondition) REFERENCES [BikeCondition] (Id),
    CONSTRAINT FK_Bike_BikeType FOREIGN KEY (IdBikeType) REFERENCES [BikeType] (Id)
);
go

create table [AdditionalEquipment] (
    Id int primary key identity(1, 1) not null,
    Name nvarchar(50) not null,
    Description nvarchar(max) null,
    Amount decimal(18, 2) null,
    IdBike int not null,
    CONSTRAINT FK_AdditionalEquipment_Bike FOREIGN KEY (IdBike) REFERENCES [Bike] (Id)
);
go

create table [AdvertType] (
    Id int primary key identity(1, 1) not null,
    Name nvarchar(20) not null
);
go

create table [Bike_AdvertType] (
    IdBike int not null,
    IdAdvertType int not null,
    CONSTRAINT PK_Bike_AdvertType PRIMARY KEY NONCLUSTERED (IdBike, IdAdvertType),
    CONSTRAINT FK_Bike FOREIGN KEY (IdBike) REFERENCES [Bike] (Id),
    CONSTRAINT FK_AdvertType FOREIGN KEY (IdAdvertType) REFERENCES [AdvertType] (Id)
);
go
