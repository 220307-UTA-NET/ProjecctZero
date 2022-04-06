--CREATE SCHEMA Store; --schema maker
--GO;

--major tables, the first three have a single relation to the Orders table (who holds all the foreign keys)
CREATE TABLE Store.Customers (    
    [Customer ID] INT IDENTITY (100,1) NOT NULL PRIMARY KEY,
    [First Name] NVARCHAR (255) NOT NULL,
    [Last Name] NVARCHAR (255),
    [Home Store] INT NOT NULL DEFAULT 1
);
CREATE TABLE Store.Items(
    [Item ID] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [Item Name] NVARCHAR (255),
    [Item Description] NVARCHAR (255),
    [Price] DECIMAL (19,2) NOT NULL
);
CREATE TABLE Store.Location(
    [Location ID] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
    [Phone] VARCHAR (15),
    [Zip/Region Code] VARCHAR (255),
    [Item 1 Inv] INT NOT NULL DEFAULT 100 CHECK ([Item 1 Inv]>=0),
    [Item 2 Inv] INT NOT NULL DEFAULT 100 CHECK ([Item 2 Inv]>=0),
    [Item 3 Inv] INT NOT NULL DEFAULT 100 CHECK ([Item 3 Inv]>=0),
    [Item 4 Inv] INT NOT NULL DEFAULT 100 CHECK ([Item 4 Inv]>=0),
    [Item 5 Inv] INT NOT NULL DEFAULT 100 CHECK ([Item 5 Inv]>=0)
);
CREATE TABLE Store.Orders (
    [Order Line] INT IDENTITY (1,1) PRIMARY KEY,
    [Location ID] INT NOT NULL FOREIGN KEY REFERENCES Store.Location ([Location ID]),
    [Customer ID] INT NOT NULL FOREIGN KEY REFERENCES Store.Customers ([Customer ID]),
    [Order PLaced] DATETIME NOT NULL DEFAULT GETDATE(),
    [Item ID] INT NOT NULL FOREIGN KEY REFERENCES Store.Items ([Item ID]),
    [Quantity] INT NOT NULL,
    [Order ID] INT NOT NULL
);
--handy drop squad
DROP TABLE Store.Orders;
DROP TABLE Store.Items;
DROP TABLE Store.Customers;
DROP TABLE Store.Location;

--handy select alls
SELECT * FROM Store.Orders;
SELECT * FROM Store.Items;
SELECT * FROM Store.Customers;
SELECT * FROM Store.Location;

--table fillers
INSERT INTO Store.Location ([Phone], [Zip/Region Code])
    VALUES ('(651)555-1122', '55414'),
    ('(763)555-2022', '55418'),
    ('(212)555-1024', '13142'),
    ('(507)555-2048', '61616'),
    ('(612)555-4096', '90210');

INSERT INTO Store.Customers ([First Name],[Last Name], [Home Store])
    VALUES ('Alice', 'Jenson', 1),
    ('Isaac', 'Batman', 1),
    ('Aaron', 'Jetson', 2),
    ('Abner', 'Benson', 3),
    ('Jenny', 'Nelson', 5),
    ('Steve', 'Samson', 4)

INSERT INTO Store.Items ([Item Name], [Item Description], [Price])
    VALUES ('Master Sword', 'It''s dangerous out there, you better take this.', 2222.22),
    ('Honda Metropolitan 50cc', 'Where are you going? Hopefully not on any highways... unless you absolutely had to and thank goodness it was super late at night.', 1500.22),
    ('E-Bike', 'A reposessed bicycle with a power drill driving the front wheel (w/o remote toggle)', 1499.22),
    ('Wusthof Chef''s Knife', 'This thing is sharp, take good care to keep it that way.', 300.22),
    ('Dragon Slayer', 'A sword so big, you''d wonder "why is it so big? Who could even weild it?"', 1);

INSERT INTO Store.Orders([Location ID], [Customer ID], [Item ID], [Quantity], [Order ID])
    VALUES (1,100,1,8,1), (1,100,2,3,1), (3,101,3,3,2), (2,102, 4, 2, 3), (4,103,5,4,4), (5,104,1,6,5), (5,104,3,2,5), (1,104,3,1,6), (1,104,4,2,6);

--inventory randomizers, then stabilizers
UPDATE Store.Location SET [Item 1 Inv] = (SELECT FLOOR(RAND()*(100-0+1))+0) WHERE [Location ID] = (SELECT FLOOR(RAND()*(5-1+1))+1);
UPDATE Store.Location SET [Item 2 Inv] = (SELECT FLOOR(RAND()*(100-0+1))+0) WHERE [Location ID] = (SELECT FLOOR(RAND()*(5-1+1))+1);
UPDATE Store.Location SET [Item 3 Inv] = (SELECT FLOOR(RAND()*(100-0+1))+0) WHERE [Location ID] = (SELECT FLOOR(RAND()*(5-1+1))+1);
UPDATE Store.Location SET [Item 4 Inv] = (SELECT FLOOR(RAND()*(100-0+1))+0) WHERE [Location ID] = (SELECT FLOOR(RAND()*(5-1+1))+1);
UPDATE Store.Location SET [Item 5 Inv] = (SELECT FLOOR(RAND()*(100-0+1))+0) WHERE [Location ID] = (SELECT FLOOR(RAND()*(5-1+1))+1);
UPDATE Store.Location SET [Item 1 Inv] = 50 WHERE [Location ID] = 1;
UPDATE Store.Location SET [Item 2 Inv] = 50 WHERE [Location ID] = 1;
UPDATE Store.Location SET [Item 3 Inv] = 50 WHERE [Location ID] = 1;
UPDATE Store.Location SET [Item 4 Inv] = 50 WHERE [Location ID] = 1;
UPDATE Store.Location SET [Item 5 Inv] = 50 WHERE [Location ID] = 1;
UPDATE Store.Location SET [Item 1 Inv] = 50 WHERE [Location ID] = 2;
UPDATE Store.Location SET [Item 2 Inv] = 50 WHERE [Location ID] = 2;
UPDATE Store.Location SET [Item 3 Inv] = 50 WHERE [Location ID] = 2;
UPDATE Store.Location SET [Item 4 Inv] = 50 WHERE [Location ID] = 2;
UPDATE Store.Location SET [Item 5 Inv] = 50 WHERE [Location ID] = 2;
UPDATE Store.Location SET [Item 1 Inv] = 50 WHERE [Location ID] = 3;
UPDATE Store.Location SET [Item 2 Inv] = 50 WHERE [Location ID] = 3;
UPDATE Store.Location SET [Item 3 Inv] = 50 WHERE [Location ID] = 3;
UPDATE Store.Location SET [Item 4 Inv] = 50 WHERE [Location ID] = 3;
UPDATE Store.Location SET [Item 5 Inv] = 50 WHERE [Location ID] = 3;
UPDATE Store.Location SET [Item 1 Inv] = 50 WHERE [Location ID] = 4;
UPDATE Store.Location SET [Item 2 Inv] = 50 WHERE [Location ID] = 4;
UPDATE Store.Location SET [Item 3 Inv] = 50 WHERE [Location ID] = 4;
UPDATE Store.Location SET [Item 4 Inv] = 50 WHERE [Location ID] = 4;
UPDATE Store.Location SET [Item 5 Inv] = 50 WHERE [Location ID] = 4;
UPDATE Store.Location SET [Item 1 Inv] = 50 WHERE [Location ID] = 5;
UPDATE Store.Location SET [Item 2 Inv] = 50 WHERE [Location ID] = 5;
UPDATE Store.Location SET [Item 3 Inv] = 50 WHERE [Location ID] = 5;
UPDATE Store.Location SET [Item 4 Inv] = 50 WHERE [Location ID] = 5;
UPDATE Store.Location SET [Item 5 Inv] = 50 WHERE [Location ID] = 5;


--I wouldn't worry about the nightmare that follows below. I went through a large db change to simplify things and some stuff... well it didn't make it.

--INSERT INTO Store.Orders ([Location ID], [Customer ID], [Item ID], [Quantity], [Order ID]) 
           -- VALUES (4, 104, 4, 9, 3);

--INSERT INTO Store.Orders ([Customer ID])
    --VALUES (100),(101),(102),(103),(104),(105),(100);

--INSERT INTO Store.Location SET [Item 1 Inv] = [Item 1 Inv] - (SELECT [Quantity] FROM Store.OrderContents WHERE [Location ID] IN 
--(SELECT [Location ID] FROM Store.Orders WHERE [Customer ID] IN (SELECT [Location ID] FROM Store.Location WHERE [Location ID] = 1)));

--INSERT INTO Store.Location SET [Item 1 Inv] = [Item 1 Inv] - (SELECT [Quantity] FROM Store.OrderContents oc JOIN Store.Orders os WHERE oc.[Order Number]=os.[Order Number] JOIN Store.Customers cu WHERE os.[Customer ID] = cu.[Customer ID] JOIN Location)
--INSERT INTO Store.OrderContents ([Order Number], [Item ID], [Quantity])
    --VALUES (10, 1, 10), (10, 2, 5)

--DELETE FROM Store.Customers WHERE [Customer ID] = 105
--Select * FROM Store.Customers WHERE [First Name] = 'Jeff' AND [Last Name] = 'Johnson'

--SELECT * FROM Store.Customers WHERE [First Name] = 'Isaac' AND [Last Name] = 'Batman';
--SELECT * FROM Store.Orders WHERE [Customer ID] = 100
--CREATE TABLE Store.Orders (
    --[Order Number] INT IDENTITY (10,1) NOT NULL PRIMARY KEY, 
    --[Customer ID] INT NOT NULL FOREIGN KEY REFERENCES Store.Customers ([Customer ID]),   
    --[Order PLaced] DATETIME NOT NULL DEFAULT GETDATE()
    --[Order Picked Up] DATETIME,
    --[Order Location ID] INT
--);

--CREATE TABLE Store.OrderContents(
    --[Order Iterant] INT IDENTITY (1,1) PRIMARY KEY,
    --[Order Number] INT NOT NULL FOREIGN KEY REFERENCES Store.Orders ([Order Number]),        
    --[Order Location ID] INT NOT NULL FOREIGN KEY REFERENCES Store.Location ([Location ID]),
    --[Item ID] INT NOT NULL FOREIGN KEY REFERENCES Store.Items ([Item ID]),
    --[Quantity] INT NOT NULL
    
--);


--GO
--SELECT * FROM Store.Orders so LEFT JOIN Store.Location sl ON so.[Location ID] = sl.[Location ID] 
--LEFT JOIN Store.Items si ON so.[Item ID] = si.[Item ID] LEFT JOIN Store.Customers sc ON so.[Customer ID] = sc.[Customer ID]
--WHERE so.[Location ID] = 1


--ALTER TABLE Store.Orders
--ADD CONSTRAINT FK_Location FOREIGN KEY ([Order Location ID]) REFERENCES Store.Location ([Location ID]);

--ALTER TABLE Store.Customers
--DROP CONSTRAINT FK_Home_Store

--DROP TABLE Store.OrderContents;
--SELECT * FROM Store.OrderContents;
--INSERT INTO Store.Customers ([First Name])
 --   VALUES ('Cher');