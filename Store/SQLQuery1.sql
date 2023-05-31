CREATE DATABASE StoreDB
GO
USE StoreDB
GO
CREATE TABLE Categories (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)
GO
CREATE TABLE Products(
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
[Quantity] INT CHECK([Quantity]>0) NOT NULL DEFAULT(0),
[Price] MONEY CHECK([Price]>0) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) ON DELETE SET DEFAULT DEFAULT(6),
[ImagePath] NVARCHAR(MAX) NOT NULL
)
GO
INSERT INTO Categories([Name])
VALUES ('Flour products'),('Drinks'),('Desserts'),('Milk products'),('Meat products'),('Other')
GO
INSERT INTO Products([CategoryId],[Name],[Price],[Quantity])
VALUES (1,'Bread',0.7,50),
(1,'Lavash',1,20),
(1,'Cookies',0.6,30),
(2,'Cola',2,20),
(2,'Fanta',2,20),
(2,'Sprite',2,20),
(3,'Puding',1.5,50),
(3,'Suffle',4,50),
(3,'Cake',10,10),
(4,'Milk',1.3,15),
(4,'Yogurt',0.7,20),
(4,'Ayran',1.7,20),
(5,'Sausage',10,15),
(5,'Meat',15,30),
(5,'Fish',12,15)
