/*
Navicat SQL Server Data Transfer

Source Server         : sqlserver
Source Server Version : 140000
Source Host           : .\SQLEXPRESS:1433
Source Database       : herbarium
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 140000
File Encoding         : 65001

Date: 2019-06-23 14:26:16
*/


-- ----------------------------
-- Table structure for city
-- ----------------------------
DROP TABLE [dbo].[city]
GO
CREATE TABLE [dbo].[city] (
[id] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(40) NULL ,
[points] nvarchar(50) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[city]', RESEED, 81)
GO

-- ----------------------------
-- Table structure for district
-- ----------------------------
DROP TABLE [dbo].[district]
GO
CREATE TABLE [dbo].[district] (
[id] int NOT NULL IDENTITY(1,1) ,
[cityid] int NULL ,
[name] nvarchar(50) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[district]', RESEED, 1944)
GO

-- ----------------------------
-- Table structure for family
-- ----------------------------
DROP TABLE [dbo].[family]
GO
CREATE TABLE [dbo].[family] (
[id] int NOT NULL IDENTITY(1,1) ,
[majorid] int NULL ,
[name] nvarchar(60) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[family]', RESEED, 2727)
GO

-- ----------------------------
-- Table structure for genus
-- ----------------------------
DROP TABLE [dbo].[genus]
GO
CREATE TABLE [dbo].[genus] (
[id] int NOT NULL IDENTITY(1,1) ,
[familyid] int NULL ,
[name] nvarchar(60) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[genus]', RESEED, 25839)
GO

-- ----------------------------
-- Table structure for grid
-- ----------------------------
DROP TABLE [dbo].[grid]
GO
CREATE TABLE [dbo].[grid] (
[id] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(5) NULL ,
[points] nvarchar(50) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[grid]', RESEED, 34)
GO

-- ----------------------------
-- Table structure for habitat
-- ----------------------------
DROP TABLE [dbo].[habitat]
GO
CREATE TABLE [dbo].[habitat] (
[id] int NOT NULL IDENTITY(1,1) ,
[name] varchar(300) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[habitat]', RESEED, 8695)
GO

-- ----------------------------
-- Table structure for log
-- ----------------------------
DROP TABLE [dbo].[log]
GO
CREATE TABLE [dbo].[log] (
[id] int NOT NULL IDENTITY(1,1) ,
[type] int NULL ,
[userid] int NULL ,
[datetime] datetime2(7) NULL DEFAULT (getdate()) ,
[logtext] nvarchar(500) NULL ,
[details] nvarchar(MAX) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[log]', RESEED, 8138)
GO

-- ----------------------------
-- Table structure for major
-- ----------------------------
DROP TABLE [dbo].[major]
GO
CREATE TABLE [dbo].[major] (
[id] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(40) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[major]', RESEED, 1011)
GO

-- ----------------------------
-- Table structure for map_plant_grid
-- ----------------------------
DROP TABLE [dbo].[map_plant_grid]
GO
CREATE TABLE [dbo].[map_plant_grid] (
[plantid] int NOT NULL ,
[gridid] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for map_user_auth
-- ----------------------------
DROP TABLE [dbo].[map_user_auth]
GO
CREATE TABLE [dbo].[map_user_auth] (
[userid] int NOT NULL ,
[user_authsid] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for neighborhood
-- ----------------------------
DROP TABLE [dbo].[neighborhood]
GO
CREATE TABLE [dbo].[neighborhood] (
[id] int NOT NULL IDENTITY(1,1) ,
[districtid] int NULL ,
[name] nvarchar(255) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[neighborhood]', RESEED, 72988)
GO

-- ----------------------------
-- Table structure for plant
-- ----------------------------
DROP TABLE [dbo].[plant]
GO
CREATE TABLE [dbo].[plant] (
[id] int NOT NULL IDENTITY(1,1) ,
[herbno] nvarchar(50) NULL ,
[speciesid] int NULL ,
[issynonym] bit NULL ,
[localname] nvarchar(80) NULL ,
[subsp] nvarchar(80) NULL ,
[variety] nvarchar(80) NULL ,
[endemism] bit NULL ,
[typeexample] nvarchar(80) NULL ,
[districtid] int NULL ,
[localite] nvarchar(255) NULL ,
[habitat] int NULL ,
[minimum] float(53) NULL ,
[maximum] float(53) NULL ,
[date] datetime NULL ,
[latitude] float(53) NULL ,
[longitude] float(53) NULL ,
[photo] varbinary(MAX) NULL ,
[collector] nvarchar(255) NULL ,
[diagnose] nvarchar(255) NULL ,
[explanation] nvarchar(3000) NULL ,
[coordinates] nvarchar(255) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[plant]', RESEED, 29001)
GO

-- ----------------------------
-- Table structure for species
-- ----------------------------
DROP TABLE [dbo].[species]
GO
CREATE TABLE [dbo].[species] (
[id] int NOT NULL IDENTITY(1,1) ,
[genusid] int NULL ,
[name] nvarchar(255) NULL ,
[link] nvarchar(40) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[species]', RESEED, 317916)
GO

-- ----------------------------
-- Table structure for speciesdetails
-- ----------------------------
DROP TABLE [dbo].[speciesdetails]
GO
CREATE TABLE [dbo].[speciesdetails] (
[id] int NOT NULL IDENTITY(1,1) ,
[speciesid] int NULL ,
[lifetime] nvarchar(255) NULL ,
[structure] nvarchar(255) NULL ,
[blooming] nvarchar(255) NULL ,
[habitat] nvarchar(255) NULL ,
[height] nvarchar(255) NULL ,
[endemism] bit NULL ,
[element] nvarchar(255) NULL ,
[turkeydist] nvarchar(255) NULL ,
[generaldist] nvarchar(255) NULL ,
[vilayets] nvarchar(255) NULL ,
[grids] nvarchar(255) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[speciesdetails]', RESEED, 4001)
GO

-- ----------------------------
-- Table structure for synonym
-- ----------------------------
DROP TABLE [dbo].[synonym]
GO
CREATE TABLE [dbo].[synonym] (
[id] int NOT NULL IDENTITY(1,1) ,
[speciesid] int NULL ,
[name] nvarchar(255) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[synonym]', RESEED, 516491)
GO

-- ----------------------------
-- Table structure for sysdiagrams
-- ----------------------------
DROP TABLE [dbo].[sysdiagrams]
GO
CREATE TABLE [dbo].[sysdiagrams] (
[name] sysname NOT NULL ,
[principal_id] int NOT NULL ,
[diagram_id] int NOT NULL IDENTITY(1,1) ,
[version] int NULL ,
[definition] varbinary(MAX) NULL 
)


GO

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE [dbo].[user]
GO
CREATE TABLE [dbo].[user] (
[id] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(50) NULL ,
[password] nvarchar(300) NULL ,
[date] datetime NULL ,
[lastlogin] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[user]', RESEED, 4)
GO

SET IDENTITY_INSERT [dbo].[user] ON
GO
INSERT INTO [dbo].[user] ([id], [name], [password], [date], [lastlogin]) VALUES (N'1', N'admin', N'', null, N'2019-06-23 14:29:30.103')
GO
GO
SET IDENTITY_INSERT [dbo].[user] OFF
GO


-- ----------------------------
-- Table structure for user_auths
-- ----------------------------
DROP TABLE [dbo].[user_auths]
GO
CREATE TABLE [dbo].[user_auths] (
[id] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(100) NULL ,
[parent] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[user_auths]', RESEED, 17)
GO

-- ----------------------------
-- View structure for v_localname
-- ----------------------------
DROP VIEW [dbo].[v_localname]
GO
CREATE VIEW [dbo].[v_localname] AS 
SELECT DISTINCT localname
FROM            dbo.plant
GO

-- ----------------------------
-- View structure for v_map_plant_grid
-- ----------------------------
DROP VIEW [dbo].[v_map_plant_grid]
GO
CREATE VIEW [dbo].[v_map_plant_grid] AS 
select distinct mpg.plantid,
STUFF((select ', ' + g.name
        from grid g 
        join map_plant_grid mpg2 on mpg2.gridid = g.id
        where mpg2.plantid = mpg.plantid   
        for xml path('')), 1, 2, '') grids
from map_plant_grid mpg
GO

-- ----------------------------
-- View structure for v_plants
-- ----------------------------
DROP VIEW [dbo].[v_plants]
GO
CREATE VIEW [dbo].[v_plants] AS 
SELECT        pl.id AS ID, pl.herbno AS Kod, fm.name AS Familya, gn.name AS Cins, sp.name AS Tür, pl.issynonym AS Sinonim, mpg.grids AS Kare, pl.localname AS [Türkçe İsim], pl.subsp AS [Alt Tür], pl.variety AS Varyete, 
                         pl.endemism AS Endemik, pl.typeexample AS [Tip Örneği], ct.name AS İl, ds.name AS İlçe, pl.localite AS Lokalite, hb.name AS Habitat, pl.minimum AS Minimum, pl.maximum AS Maksimum, pl.date AS Tarih, 
                         CAST(pl.latitude AS varchar) + ', ' + CAST(pl.longitude AS varchar) AS Koordinatlar, pl.collector AS Toplayıcı, pl.diagnose AS [Teşhis Eden], pl.explanation AS Açıklama
FROM            dbo.plant AS pl LEFT OUTER JOIN
                         dbo.synonym AS sy ON sy.id = CASE WHEN pl.issynonym = 'True' THEN pl.speciesid ELSE NULL END LEFT OUTER JOIN
                         dbo.species AS sp ON sp.id = CASE WHEN pl.issynonym = 'False' THEN pl.speciesid ELSE sy.speciesid END INNER JOIN
                         dbo.genus AS gn ON gn.id = sp.genusid INNER JOIN
                         dbo.family AS fm ON fm.id = gn.familyid INNER JOIN
                         dbo.major AS mj ON mj.id = fm.majorid INNER JOIN
                         dbo.habitat AS hb ON hb.id = pl.habitat LEFT OUTER JOIN
                         dbo.district AS ds ON ds.id = pl.districtid LEFT OUTER JOIN
                         dbo.city AS ct ON ct.id = ds.cityid LEFT OUTER JOIN
                         dbo.v_map_plant_grid AS mpg ON mpg.plantid = pl.id
GO

-- ----------------------------
-- View structure for v_subsp
-- ----------------------------
DROP VIEW [dbo].[v_subsp]
GO
CREATE VIEW [dbo].[v_subsp] AS 
SELECT DISTINCT subsp
FROM            dbo.plant
GO

-- ----------------------------
-- View structure for v_typeexample
-- ----------------------------
DROP VIEW [dbo].[v_typeexample]
GO
CREATE VIEW [dbo].[v_typeexample] AS 
SELECT DISTINCT typeexample
FROM            dbo.plant
GO

-- ----------------------------
-- View structure for v_user
-- ----------------------------
DROP VIEW [dbo].[v_user]
GO
CREATE VIEW [dbo].[v_user] AS 
SELECT        id AS ID, name AS [Kullanıcı Adı], date AS [Kayıt Tarihi], lastlogin AS [Son Giriş]
FROM            dbo.[user]
GO

-- ----------------------------
-- View structure for v_variety
-- ----------------------------
DROP VIEW [dbo].[v_variety]
GO
CREATE VIEW [dbo].[v_variety] AS 
SELECT DISTINCT variety
FROM            dbo.plant
GO

-- ----------------------------
-- Indexes structure for table city
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table city
-- ----------------------------
ALTER TABLE [dbo].[city] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table district
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table district
-- ----------------------------
ALTER TABLE [dbo].[district] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table family
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table family
-- ----------------------------
ALTER TABLE [dbo].[family] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table genus
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table genus
-- ----------------------------
ALTER TABLE [dbo].[genus] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table grid
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table grid
-- ----------------------------
ALTER TABLE [dbo].[grid] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table habitat
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table habitat
-- ----------------------------
ALTER TABLE [dbo].[habitat] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table log
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table log
-- ----------------------------
ALTER TABLE [dbo].[log] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table major
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table major
-- ----------------------------
ALTER TABLE [dbo].[major] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table map_plant_grid
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table map_plant_grid
-- ----------------------------
ALTER TABLE [dbo].[map_plant_grid] ADD PRIMARY KEY ([plantid], [gridid])
GO

-- ----------------------------
-- Indexes structure for table map_user_auth
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table map_user_auth
-- ----------------------------
ALTER TABLE [dbo].[map_user_auth] ADD PRIMARY KEY ([userid], [user_authsid])
GO

-- ----------------------------
-- Indexes structure for table neighborhood
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table neighborhood
-- ----------------------------
ALTER TABLE [dbo].[neighborhood] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table plant
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table plant
-- ----------------------------
ALTER TABLE [dbo].[plant] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table species
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table species
-- ----------------------------
ALTER TABLE [dbo].[species] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table speciesdetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table speciesdetails
-- ----------------------------
ALTER TABLE [dbo].[speciesdetails] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table synonym
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table synonym
-- ----------------------------
ALTER TABLE [dbo].[synonym] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table sysdiagrams
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table sysdiagrams
-- ----------------------------
ALTER TABLE [dbo].[sysdiagrams] ADD PRIMARY KEY ([diagram_id])
GO

-- ----------------------------
-- Uniques structure for table sysdiagrams
-- ----------------------------
ALTER TABLE [dbo].[sysdiagrams] ADD UNIQUE ([principal_id] ASC, [name] ASC)
GO

-- ----------------------------
-- Indexes structure for table user
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table user
-- ----------------------------
ALTER TABLE [dbo].[user] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table user_auths
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table user_auths
-- ----------------------------
ALTER TABLE [dbo].[user_auths] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[district]
-- ----------------------------
ALTER TABLE [dbo].[district] ADD FOREIGN KEY ([cityid]) REFERENCES [dbo].[city] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[family]
-- ----------------------------
ALTER TABLE [dbo].[family] ADD FOREIGN KEY ([majorid]) REFERENCES [dbo].[major] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[genus]
-- ----------------------------
ALTER TABLE [dbo].[genus] ADD FOREIGN KEY ([familyid]) REFERENCES [dbo].[family] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[log]
-- ----------------------------
ALTER TABLE [dbo].[log] ADD FOREIGN KEY ([userid]) REFERENCES [dbo].[user] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[map_plant_grid]
-- ----------------------------
ALTER TABLE [dbo].[map_plant_grid] ADD FOREIGN KEY ([gridid]) REFERENCES [dbo].[grid] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[map_plant_grid] ADD FOREIGN KEY ([plantid]) REFERENCES [dbo].[plant] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[map_user_auth]
-- ----------------------------
ALTER TABLE [dbo].[map_user_auth] ADD FOREIGN KEY ([user_authsid]) REFERENCES [dbo].[user_auths] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[map_user_auth] ADD FOREIGN KEY ([userid]) REFERENCES [dbo].[user] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[plant]
-- ----------------------------
ALTER TABLE [dbo].[plant] ADD FOREIGN KEY ([districtid]) REFERENCES [dbo].[district] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[species]
-- ----------------------------
ALTER TABLE [dbo].[species] ADD FOREIGN KEY ([genusid]) REFERENCES [dbo].[genus] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[speciesdetails]
-- ----------------------------
ALTER TABLE [dbo].[speciesdetails] ADD FOREIGN KEY ([speciesid]) REFERENCES [dbo].[species] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[synonym]
-- ----------------------------
ALTER TABLE [dbo].[synonym] ADD FOREIGN KEY ([speciesid]) REFERENCES [dbo].[species] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
