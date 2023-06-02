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
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) ON DELETE SET DEFAULT DEFAULT(1),
[ImagePath] NVARCHAR(MAX) NOT NULL DEFAULT('https://res.cloudinary.com/dljzepmxr/image/upload/v1685702588/No_imagve_xwmo1u.jpg')
)
GO
INSERT INTO Categories([Name])
VALUES ('Other'),('Flour products'),('Drinks'),('Desserts'),('Milk products'),('Meat products')
GO
INSERT INTO Products([CategoryId],[Name],[Price],[Quantity],[ImagePath])
VALUES (2,'Bread',0.7,50,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685531482/bine-zavod-coreyi-680-gr_vgmbms.jpg'),
(2,'Lavash',1,20,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625921/Lavas_h4ekuh.jpg'),
(2,'Cookies',0.6,30,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625624/eti-petibor-400-gr-klasik_kf3zzu.jpg'),
(3,'Cola',2,20,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625805/coca-cola-500-ml-pet_iozcml.jpg'),
(3,'Fanta',2,20,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625623/fanta-500-ml-pet_pqjk4t.jpg'),
(3,'Sprite',2,20,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625624/sprite-lemon-and-lime_product-image_niycqv.jpg'),
(4,'Puding',1.5,50,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625623/Puding_fawysa.jpg'),
(4,'Suffle',4,50,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625625/Sufle_jpcujo.jpg'),
(4,'Cake',10,10,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625623/Cake_iq5qya.jpg'),
(5,'Milk',1.3,15,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625624/Sut_xreiah.jpg'),
(5,'Yogurt',0.7,20,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625626/Yoqurd_axozla.jpg'),
(5,'Ayran',1.7,20,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625625/Ayran_ywbxho.png'),
(6,'Sausage',10,15,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625624/Sosis_hf692k.jpg'),
(6,'Meat',15,30,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625625/Et_yudxpa.jpg'),
(6,'Fish',12,15,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625622/Baliq_jsodku.jpg')
