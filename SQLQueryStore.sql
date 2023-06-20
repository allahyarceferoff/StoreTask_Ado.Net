CREATE DATABASE StoreDb
GO
USE StoreDb
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
VALUES ('Other'),('PHONE'),('NOTEBOOK'),('VACUUM CLEANER'),('CONDITIONER'),('WASH MACHINE')
GO
INSERT INTO Products([CategoryId],[Name],[Price],[Quantity],[ImagePath])
VALUES (2,'Iphone 12 Pro',1350,50,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687088393/iphone_12_qckw9g.jpg'),
(2,'Samsung S22  Ultra 256 Black',2799,20,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687251303/samsung_S22_Ultra_vg9gfx.jpg'),
(2,'Xiomi Note 12S  White',1280,30,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625624/eti-petibor-400-gr-klasik_kf3zzu.jpg'),
(2,'Huawei P30  32 GB SeaBlue',1799,20,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687251384/Huawei_P30_lbcurq.jpg'),
(2,'Blackberry Curve S850 16GB Black ',850,20,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687251758/balckberry_zjih3b.jpg'),


(3,'ACER  12H 256GB "15.6"',850,20,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687089028/acer_notebook_qcze6r.jpg'),
(3,'ASUS Zenbook "13.3" Special Edition 1TB ',3700,20,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687252623/1514e4ab-f9bc-46d0-9089-f7ade0e4993d_ftsq3q.png'),
(3,'Lenova  IDepad "16" 512GB ',2300,40,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687253173/90793470E5087F33F68A48349A9319FA_04_ec7qim.jpg'),
(3,'HP  Pavilion "15.6" 360GB ',1550,20,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687253783/c07394316_bqjuqj.png'),



(4,'Kenwood Vacuum Cleaner 220W',90,20,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687187238/kenwood_tozsoran_zdx2nu.jpg'),
(4,'Samsung Evo Vacuum Cleaner',75,50,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687252181/maxresdefault_h4ar8e.jpg'),

(5,'Mitsubishi Condinoiter',3830,15,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687188020/mitsubishi_con_uaogev.jpg'),
(5,'Panasononic AidCondinioter',2499,30,'https://res.cloudinary.com/dljzepmxr/image/upload/v1685625626/Yoqurd_axozla.jpg'),
(5,'LG Inventer',5200,20,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687188020/lg_odjare.jpg'),

(6,'SAMSUNG AddWash 8 kg 1400 Spin',1100,10,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687187416/samsung_paltaryuyan_oqpjur.jpg'),
(6,'Hisense 14 kg 1000 spin',1800,30,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687181318/hisense_paltaryuyan_dy9fa1.jpg'),
(6,'Bosch 5 kg 1200 spin',850,10,'https://res.cloudinary.com/djz1pz93s/image/upload/v1687252046/MCSA00795814_WAW32560ME_def_cdrylh.png')
