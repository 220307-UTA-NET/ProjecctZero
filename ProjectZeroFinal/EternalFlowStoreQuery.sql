CREATE SCHEMA EternalFlowStore; -- new filing cabinet
GO

-- TABLE 1
CREATE TABLE EternalFlowStore.Location (
    Location_ID INT PRIMARY KEY IDENTITY, -- creates a unique value that changes with every entry in the table
    Location NVARCHAR (255)  NULL,
    Country NVARCHAR (255) NULL,
    Address NVARCHAR (255) NULL,
    StateProvinceArea NVARCHAR (255) NULL, 
    PhoneNumber NVARCHAR (255) NULL,
    Email NVARCHAR (255) NULL,
);

-- DROP TABLE EternalFlowStore.Location; 
SELECT * FROM EternalFlowStore.Location;
DELETE FROM EternalFlowStore.Location WHERE Location_ID = 4

-- TABLE 2
CREATE TABLE EternalFlowStore.Inventory (
    Inventory_ID INT PRIMARY KEY IDENTITY, 
    Name NVARCHAR (255) NULL, -- name of items in inventory 
    Quantity INT NULL,
    Price NVARCHAR (255) NULL,
    InventoryDateIn DATE NULL DEFAULT GETDATE(),
    InventoryDateOut DATE NULL,
    CHECK (InventoryDateOut > InventoryDateIn) 
);

-- DROP TABLE EternalFlowStore.Inventory; -- used for good organization to delete easy 
SELECT * FROM EternalFlowStore.Inventory;
DELETE FROM EternalFlowStore.Inventory WHERE Inventory_ID = 1

-- TABLE 3
CREATE TABLE EternalFlowStore.Customers (
    Customer_ID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR (255) NULL, 
    LastName NVARCHAR (255) NULL,
    Address NVARCHAR (255) NULL,
    City NVARCHAR (255) NULL,
    StateProvinceArea NVARCHAR (255) NULL,
    Country NVARCHAR (255) NULL,
    PhoneNumber NVARCHAR (255) NULL,
    Email NVARCHAR (255) NULL,
);

-- DROP TABLE EternalFlowStore.Customers;
SELECT * FROM EternalFlowStore.Customers;

-- TABLE 4
CREATE TABLE EternalFlowStore.Orders (
    Order_ID INT PRIMARY KEY IDENTITY,
    DateOfOrder DATE NULL DEFAULT GETDATE(),
    TimeOfOrder TIME,
    CustomerName NVARCHAR (255) NULL,
    LocationOfOrder NVARCHAR (255) NULL, 
    ItemOrdered NVARCHAR (255)  NULL,
    NumberOfItemsOrdered INT NULL,
    OrderDescription NVARCHAR (255) NULL,
);

-- DROP TABLE EternalFlowStore.OrderHistory;
SELECT * FROM EternalFlowStore.OrderHistory;


/*******************************************************************************
   Create Foreign Keys
********************************************************************************/

-- link the table EternalFlowStore.Location to referenece EternalFlowStore.Customers through Location_ID with Customer_ID
ALTER TABLE EternalFlowStore.Location 
    ADD CONSTRAINT FK__Location__Location_ID FOREIGN KEY ( Location_ID )
        REFERENCES EternalFlowStore.Customers (Customer_ID) 

-- link the table EternalFlowStore.Location to referenece EternalFlowStore.Customers through CusotmerID with Customer_ID
--ALTER TABLE EternalFlowStore.Inventory  
    --ADD CONSTRAINT FK__Inventory__Inventory_ID FOREIGN KEY ( Inventory_ID )
        --REFERENCES EternalFlowStore.OrderHistory (Order_ID) 

-- link the table EternalFlowStore.Location to EternalFlowStore.OrderHistory through OrderID with Order_ID
ALTER TABLE EternalFlowStore.Location 
    ADD CONSTRAINT FK__Location__OrderID FOREIGN KEY ( OrderID )
        REFERENCES EternalFlowStore.OrderHistory (Order_ID) 

/*******************************************************************************
   Populate Table 1 
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

-- TABLE 1
-- Location
INSERT INTO EternalFlowStore.Location ( Location )
VALUES(
    'Los Angeles'),
    ('Seoul'),
    ('Singapore'),
    ('London'),
    ('Paris'),
    ('San Salvador')
;

-- Update Los Angeles Information
UPDATE EternalFlowStore.Location SET Country = 'USA' WHERE Location_ID = 1;
UPDATE EternalFlowStore.Location SET Address = '5723 Morgan Ave' WHERE Location_ID = 1;
UPDATE EternalFlowStore.Location SET StateProvinceArea = 'California' WHERE Location_ID = 1;
UPDATE EternalFlowStore.Location SET PhoneNumber = '(323) 638-2296' WHERE Location_ID = 1;
UPDATE EternalFlowStore.Location SET Email = 'EternalFlowLosAngeles@protonmail.com' WHERE Location_ID = 1;

-- Update Seoul Information
UPDATE EternalFlowStore.Location SET Country = 'Seoul' WHERE Location_ID = 2;
UPDATE EternalFlowStore.Location SET Address = '28-9, Jongam-dong' WHERE Location_ID = 2;
UPDATE EternalFlowStore.Location SET StateProvinceArea = 'Seoul' WHERE Location_ID = 2;
UPDATE EternalFlowStore.Location SET PhoneNumber = '+82-8-884-2359'WHERE Location_ID = 2;
UPDATE EternalFlowStore.Location SET Email = 'EternalFlowSeoul@protonmail.com' WHERE Location_ID = 2;

-- Update Singapore Information
UPDATE EternalFlowStore.Location SET Country = 'Singapore' WHERE Location_ID = 3; 
UPDATE EternalFlowStore.Location SET Address = '10 Anson Road #25-04A International Plaza' WHERE Location_ID = 3;
UPDATE EternalFlowStore.Location SET StateProvinceArea = 'Singapore' WHERE Location_ID = 3;
UPDATE EternalFlowStore.Location SET PhoneNumber = '65-6337-4278' WHERE Location_ID = 3;
UPDATE EternalFlowStore.Location SET Email = 'EternalFlowSingapore@protonmail.com' WHERE Location_ID = 3;

-- Update London Information
UPDATE EternalFlowStore.Location SET Country = 'United Kingdom' WHERE Location_ID = 4; 
UPDATE EternalFlowStore.Location SET Address = '71 Guild Street, London' WHERE Location_ID = 4;
UPDATE EternalFlowStore.Location SET StateProvinceArea = 'OX6 6ST' WHERE Location_ID = 4;
UPDATE EternalFlowStore.Location SET PhoneNumber = '078 2638 4970' WHERE Location_ID = 4;
UPDATE EternalFlowStore.Location SET Email = 'EternalFlowLondon@protonmail.com' WHERE Location_ID = 4;

-- Update Paris Information
UPDATE EternalFlowStore.Location SET Country = 'France' WHERE Location_ID = 5;
UPDATE EternalFlowStore.Location SET Address = '54 rue La Boétie' WHERE Location_ID = 5;
UPDATE EternalFlowStore.Location SET StateProvinceArea = 'Île-de-France' WHERE Location_ID = 5;
UPDATE EternalFlowStore.Location SET PhoneNumber = '01.66.20.20.01' WHERE Location_ID = 5;
UPDATE EternalFlowStore.Location SET Email = 'EternalFlowParis@protonmail.com' WHERE Location_ID = 5;

-- Update San Salvador  Information
UPDATE EternalFlowStore.Location SET Country = 'El Salvador' WHERE Location_ID = 6;
UPDATE EternalFlowStore.Location SET Address = 'Col Escalón 81 Av Sur No 206' WHERE Location_ID = 6;
UPDATE EternalFlowStore.Location SET StateProvinceArea = 'San Salvador' WHERE Location_ID = 6;
UPDATE EternalFlowStore.Location SET PhoneNumber = '(503) 22635123' WHERE Location_ID = 6;
UPDATE EternalFlowStore.Location SET Email = 'EternalFlowSanSalvador@protonmail.com' WHERE Location_ID = 6;

-------------------------------------------------------------------------------
/*******************************************************************************
   Populate Table 2
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

-- TABLE 2
INSERT INTO EternalFlowStore.Inventory ( Name )
VALUES(
    'EternalFlow NFT'), ('Bitcoin NFT'), ('Ethereum NFT'), ('Binance NFT'), ('Solana NFT'), ('Terra NFT'), ('XRP NFT'), ('Cardano NFT'), ('Avax NFT'), ('SafeMoon NFT'), 
    ('Dogecoin NFT'), ('Shiba Inu NFT'), ('Polkda NFT'), ('ChainLink NFT'), ('Tron NFT'),

    ('EternalFlow T-Shirt'), ('Bitcoin T-Shirt'), ('Ethereum T-Shirt'), ('Binance T-Shirt'), ('Solana T-Shirt'), ('Terra T-Shirt'), ('XRP T-Shirt'), ('Cardano T-Shirt'), ('Avax T-Shirt'), 
    ('SafeMoon T-Shirt'), ('Dogecoin T-Shirt'), ('Shiba Inu T-Shirt'), ('Polkda T-Shirt'), ('ChainLink T-Shirt'), ('Tron T-Shirt'),

    ('EternalFlow Hat'), ('Bitcoin Hat'), ('Ethereum Hat'), ('Binance Hat'), ('Solana Hat'), ('Terra Hat'), ('XRP Hat'), ('Cardano Hat'), ('Avax Hat'), ('SafeMoon Hat'), ('Dogecoin Hat'),
    ('Shiba Inu Hat'), ('Polkda Hat'), ('ChainLink Hat'), ('Tron Hat'),
    
    ('EternalFlow Coffee Mug'), ('Bitcoin Coffee Mug'), ('Ethereum Coffee Mug'), ('Binance Coffee Mug'), ('Solana Coffee Mug'), ('Terra Coffee Mug'), ('XRP Coffee Mug'), 
    ('Cardano Coffee Mug'), ('Avax Coffee Mug'),('SafeMoon Coffee Mug'), ('Dogecoin Coffee Mug'), ('Shiba Inu Coffee Mug'), ('Polkda Coffee Mug'), ('ChainLink Coffee Mug'), ('Tron Coffe Mug')

-- Update Quantity NFTs
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 1;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 2;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 3;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 4;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 5;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 6;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 7;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 8;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 8;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 9;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 10;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 11;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 12;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 13;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 14;
UPDATE EternalFlowStore.Inventory SET Quantity = '50' WHERE Inventory_ID = 15;

-- Update Quantity T-Shirts
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 16;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 17;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 18;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 19;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 20;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 21;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 22;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 23;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 24;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 25;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 24;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 26;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 27;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 28;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 29;
UPDATE EternalFlowStore.Inventory SET Quantity = '100' WHERE Inventory_ID = 30;

-- Update Quantity T-Shirts
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 31;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 32;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 33;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 34;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 35;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 36;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 37;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 38;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 39;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 40;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 41;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 42;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 43;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 44;
UPDATE EternalFlowStore.Inventory SET Quantity = '25' WHERE Inventory_ID = 45;

-- Update Quantity Coffe Mug
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 46;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 45;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 47;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 48;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 49;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 50;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 51;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 52;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 53;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 54;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 55;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 56;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 57;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 58;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 59;
UPDATE EternalFlowStore.Inventory SET Quantity = '30' WHERE Inventory_ID = 60;

------------------------------------------------------------------------------
-- Update Price NFTs
UPDATE EternalFlowStore.Inventory SET Price = '$5000' WHERE Inventory_ID = 1;
UPDATE EternalFlowStore.Inventory SET Price = '$10000' WHERE Inventory_ID = 2;
UPDATE EternalFlowStore.Inventory SET Price = '$1000' WHERE Inventory_ID = 3;
UPDATE EternalFlowStore.Inventory SET Price = '$75' WHERE Inventory_ID = 4;
UPDATE EternalFlowStore.Inventory SET Price = '$50' WHERE Inventory_ID = 5;
UPDATE EternalFlowStore.Inventory SET Price = '$50' WHERE Inventory_ID = 6;
UPDATE EternalFlowStore.Inventory SET Price = '$50' WHERE Inventory_ID = 7;
UPDATE EternalFlowStore.Inventory SET Price = '$150' WHERE Inventory_ID = 8;
UPDATE EternalFlowStore.Inventory SET Price = '$600' WHERE Inventory_ID = 8;
UPDATE EternalFlowStore.Inventory SET Price = '$850' WHERE Inventory_ID = 9;
UPDATE EternalFlowStore.Inventory SET Price = '$750' WHERE Inventory_ID = 10;
UPDATE EternalFlowStore.Inventory SET Price = '$50' WHERE Inventory_ID = 11;
UPDATE EternalFlowStore.Inventory SET Price = '$900' WHERE Inventory_ID = 12;
UPDATE EternalFlowStore.Inventory SET Price = '$450' WHERE Inventory_ID = 13;
UPDATE EternalFlowStore.Inventory SET Price = '$350' WHERE Inventory_ID = 14;
UPDATE EternalFlowStore.Inventory SET Price = '$300' WHERE Inventory_ID = 15;

-- Update Price T-Shirts
UPDATE EternalFlowStore.Inventory SET Price = '$30' WHERE Inventory_ID = 16;
UPDATE EternalFlowStore.Inventory SET Price = '$30' WHERE Inventory_ID = 17;
UPDATE EternalFlowStore.Inventory SET Price = '$30' WHERE Inventory_ID = 18;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 19;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 20;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 21;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 22;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 23;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 24;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 25;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 24;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 26;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 27;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 28;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 29;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 30;

-- Update Price Hats
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 31;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 32;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 33;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 34;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 35;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 36;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 37;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 38;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 39;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 40;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 41;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 42;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 43;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 44;
UPDATE EternalFlowStore.Inventory SET Price = '$25' WHERE Inventory_ID = 45;

-- Update Price Coffee Mugs
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 46;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 45;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 47;
UPDATE EternalFlowStore.Inventory SET Price = '$20' WHERE Inventory_ID = 48;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 49;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 50;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 51;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 52;
UPDATE EternalFlowStore.Inventory SET Price = '$15' WHERE Inventory_ID = 53;
UPDATE EternalFlowStore.Inventory SET Price = '$10' WHERE Inventory_ID = 54;
UPDATE EternalFlowStore.Inventory SET Price = '$10' WHERE Inventory_ID = 55;
UPDATE EternalFlowStore.Inventory SET Price = '$5'  WHERE Inventory_ID = 56;
UPDATE EternalFlowStore.Inventory SET Price = '$5'  WHERE Inventory_ID = 57;
UPDATE EternalFlowStore.Inventory SET Price = '$5'  WHERE Inventory_ID = 58;
UPDATE EternalFlowStore.Inventory SET Price = '$5'  WHERE Inventory_ID = 59;
UPDATE EternalFlowStore.Inventory SET Price = '$5'  WHERE Inventory_ID = 60;

--------------------------------------------------------------------------------
/*******************************************************************************
   Populate Table 3
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

-- TABLE 3
-- First Names
INSERT INTO EternalFlowStore.Customers (FirstName)
VALUES(
     'Alayah'), ('Calvin'), ('Axel'), ('Ruth'), ('Adalyn'), ('Zuri'), ('Maria'), ('Teagan'), ('Vivian'), ('Mario'),
     ('Ryan'),  ('Sun'),  ('Ca'),  ('Da'),  ('Jin'),  ('Mae'),  ('Cah'),  ('Kah'),  ('Wi'),  ('Bak'), 
     ('Fatin'), ('Nigel'), ('Vernie'), ('Erica'), ('Tyler'), ('Winston'), ('Elaina'), ('Randy'), ('Vicky'), ('Garrer'), 
     ('Freddie'),('Lane'), ('Shirley'), ('Melvin'), ('Leo'), ('Molly'), ('Webster'), ('Elenor'), ('Shirley'), ('Osmond'), 
     ('Aurore'), ('Jean'), ('Alexis'), ('Malo'), ('Ninon'), ('Victoria'), ('César'), ('Michel'), ('Chloé'), ('Ulysse'), 
     ('Pastora'), ('Juanito'), ('Sence'), ('Régulo'), ('Eugènio'), ('Juanita'), ('Geraldo'), ('Zenaida'), ('Odalis'), ('Mateo')

UPDATE EternalFlowStore.Customers SET FirstName = 'Sun' WHERE Customer_ID = 13;

--Updates
-- LastNames
UPDATE EternalFlowStore.Customers SET LastName = 'Thompson' WHERE Customer_ID = 1;
UPDATE EternalFlowStore.Customers SET LastName = 'Richardson' WHERE Customer_ID = 2;
UPDATE EternalFlowStore.Customers SET LastName = 'Reed' WHERE Customer_ID = 3;
UPDATE EternalFlowStore.Customers SET LastName = 'James' WHERE Customer_ID = 4;
UPDATE EternalFlowStore.Customers SET LastName = 'Reyes' WHERE Customer_ID = 5;
UPDATE EternalFlowStore.Customers SET LastName = 'Cooper' WHERE Customer_ID = 6;
UPDATE EternalFlowStore.Customers SET LastName = 'Gross' WHERE Customer_ID = 7;
UPDATE EternalFlowStore.Customers SET LastName = 'Foster' WHERE Customer_ID = 8;
UPDATE EternalFlowStore.Customers SET LastName = 'Perez' WHERE Customer_ID = 9;
UPDATE EternalFlowStore.Customers SET LastName = 'Johnston' WHERE Customer_ID = 10;

UPDATE EternalFlowStore.Customers SET LastName = 'Lee' WHERE Customer_ID = 11;
UPDATE EternalFlowStore.Customers SET LastName = 'Seul' WHERE Customer_ID = 12;
UPDATE EternalFlowStore.Customers SET LastName = 'Won-Shik' WHERE Customer_ID = 13;
UPDATE EternalFlowStore.Customers SET LastName = 'Tae' WHERE Customer_ID = 14;
UPDATE EternalFlowStore.Customers SET LastName = 'Hyun-Ae' WHERE Customer_ID = 15;
UPDATE EternalFlowStore.Customers SET LastName = 'Eun-Ryung' WHERE Customer_ID = 16;
UPDATE EternalFlowStore.Customers SET LastName = 'Kwang-Sun' WHERE Customer_ID = 17;
UPDATE EternalFlowStore.Customers SET LastName = 'He-Ran' WHERE Customer_ID = 18;
UPDATE EternalFlowStore.Customers SET LastName = 'Hyun' WHERE Customer_ID = 19;
UPDATE EternalFlowStore.Customers SET LastName = 'Korian' WHERE Customer_ID = 20;

UPDATE EternalFlowStore.Customers SET LastName = 'Changmin' WHERE Customer_ID = 21;
UPDATE EternalFlowStore.Customers SET LastName = 'Chen' WHERE Customer_ID = 22;
UPDATE EternalFlowStore.Customers SET LastName = 'Chia' WHERE Customer_ID = 23;
UPDATE EternalFlowStore.Customers SET LastName = 'Tran' WHERE Customer_ID = 24;
UPDATE EternalFlowStore.Customers SET LastName = 'Guo' WHERE Customer_ID = 25;
UPDATE EternalFlowStore.Customers SET LastName = 'Foo' WHERE Customer_ID = 26;
UPDATE EternalFlowStore.Customers SET LastName = 'Leng' WHERE Customer_ID = 27;
UPDATE EternalFlowStore.Customers SET LastName = 'Fang' WHERE Customer_ID = 28;
UPDATE EternalFlowStore.Customers SET LastName = 'Koh' WHERE Customer_ID = 29;
UPDATE EternalFlowStore.Customers SET LastName = 'Lin' WHERE Customer_ID = 30;

UPDATE EternalFlowStore.Customers SET LastName = 'Harvey' WHERE Customer_ID = 31;
UPDATE EternalFlowStore.Customers SET LastName = 'Cross' WHERE Customer_ID = 32;
UPDATE EternalFlowStore.Customers SET LastName = 'Bacchus' WHERE Customer_ID = 33;
UPDATE EternalFlowStore.Customers SET LastName = 'Lyons' WHERE Customer_ID = 34;
UPDATE EternalFlowStore.Customers SET LastName = 'Mason' WHERE Customer_ID = 35;
UPDATE EternalFlowStore.Customers SET LastName = 'Beck' WHERE Customer_ID = 36;
UPDATE EternalFlowStore.Customers SET LastName = 'Langstaff' WHERE Customer_ID = 37;
UPDATE EternalFlowStore.Customers SET LastName = 'Ford' WHERE Customer_ID = 38;
UPDATE EternalFlowStore.Customers SET LastName = 'Ruell' WHERE Customer_ID = 39;
UPDATE EternalFlowStore.Customers SET LastName = 'OSchultz' WHERE Customer_ID = 40;

UPDATE EternalFlowStore.Customers SET LastName = 'Lefevre' WHERE Customer_ID = 41;
UPDATE EternalFlowStore.Customers SET LastName = 'Boé' WHERE Customer_ID = 42;
UPDATE EternalFlowStore.Customers SET LastName = 'Meyer' WHERE Customer_ID = 43;
UPDATE EternalFlowStore.Customers SET LastName = 'Bonnet' WHERE Customer_ID = 44;
UPDATE EternalFlowStore.Customers SET LastName = 'Dufour' WHERE Customer_ID = 45;
UPDATE EternalFlowStore.Customers SET LastName = 'Leroux' WHERE Customer_ID = 46;
UPDATE EternalFlowStore.Customers SET LastName = 'Dupont' WHERE Customer_ID = 47;
UPDATE EternalFlowStore.Customers SET LastName = 'Pierre' WHERE Customer_ID = 48;
UPDATE EternalFlowStore.Customers SET LastName = 'Rousseau'WHERE Customer_ID = 49;
UPDATE EternalFlowStore.Customers SET LastName = 'Dupuich' WHERE Customer_ID = 50;

UPDATE EternalFlowStore.Customers SET LastName = 'Calvillo'  WHERE Customer_ID = 51;
UPDATE EternalFlowStore.Customers SET LastName = 'Leyva' WHERE Customer_ID = 52;
UPDATE EternalFlowStore.Customers SET LastName = 'Bahena' WHERE Customer_ID = 53;
UPDATE EternalFlowStore.Customers SET LastName = 'Olivas' WHERE Customer_ID = 54;
UPDATE EternalFlowStore.Customers SET LastName = 'Llanos' WHERE Customer_ID = 55;
UPDATE EternalFlowStore.Customers SET LastName = 'Fernando' WHERE Customer_ID = 56;
UPDATE EternalFlowStore.Customers SET LastName = 'Pascual'  WHERE Customer_ID = 57;
UPDATE EternalFlowStore.Customers SET LastName = 'Lino' WHERE Customer_ID = 58;
UPDATE EternalFlowStore.Customers SET LastName = 'Cadiz' WHERE Customer_ID = 59;
UPDATE EternalFlowStore.Customers SET LastName = 'Canas'  WHERE Customer_ID = 60;

SELECT * FROM EternalFlowStore.Customers;
-- Address
UPDATE EternalFlowStore.Customers SET Address = '1675 Parkway Street' WHERE Customer_ID = 1;
UPDATE EternalFlowStore.Customers SET Address = '4414 Denver Avenue'  WHERE Customer_ID = 2;
UPDATE EternalFlowStore.Customers SET Address = '1149 Canis Heights Drive' WHERE Customer_ID = 3;
UPDATE EternalFlowStore.Customers SET Address = '3859 Patterson Road' WHERE Customer_ID = 4;
UPDATE EternalFlowStore.Customers SET Address = '1623 Bailey Drive' WHERE Customer_ID = 5;
UPDATE EternalFlowStore.Customers SET Address = '1795 Rosewood Court' WHERE Customer_ID = 6;
UPDATE EternalFlowStore.Customers SET Address = '3463 Weekley Street' WHERE Customer_ID = 7;
UPDATE EternalFlowStore.Customers SET Address = '776 Kennedy Court' WHERE Customer_ID = 8;
UPDATE EternalFlowStore.Customers SET Address = '4754 Ryder Avenue' WHERE Customer_ID = 9;
UPDATE EternalFlowStore.Customers SET Address = '4407 Overlook Drive' WHERE Customer_ID = 10;

UPDATE EternalFlowStore.Customers SET Address = '23-11, Ganam-myeon' WHERE Customer_ID = 11;
UPDATE EternalFlowStore.Customers SET Address = '23-2, Hapumri, Sanbuk-myeon' WHERE Customer_ID = 12;
UPDATE EternalFlowStore.Customers SET Address = '1153-9, Donghangri, Yokji-myeon' WHERE Customer_ID = 13;
UPDATE EternalFlowStore.Customers SET Address = '284-3, Orimri, Haui-myeon' WHERE Customer_ID = 14;
UPDATE EternalFlowStore.Customers SET Address = '167-10, Yatap-dong' WHERE Customer_ID = 15;
UPDATE EternalFlowStore.Customers SET Address = '30-7, Iwon-myeon' WHERE Customer_ID = 16;
UPDATE EternalFlowStore.Customers SET Address = '559-11, Eunhaeng-dong' WHERE Customer_ID = 17;
UPDATE EternalFlowStore.Customers SET Address = '307-1, Geunhwabeullubirapateu' WHERE Customer_ID = 18;
UPDATE EternalFlowStore.Customers SET Address = '303-5, Sujinmaeurumiinoseubirapateu' WHERE Customer_ID = 19;
UPDATE EternalFlowStore.Customers SET Address = '259-9, Bujeon 1(il)-dong,jin-gu' WHERE Customer_ID = 20;

UPDATE EternalFlowStore.Customers SET Address = '2304 Bedok Reservoir Road Bedok Industrial Park'  WHERE Customer_ID = 21;
UPDATE EternalFlowStore.Customers SET Address = 'Tampines Street 93, Tampines' WHERE Customer_ID = 22;
UPDATE EternalFlowStore.Customers SET Address = '5057 Ang Mo Kio Industrial Park' WHERE Customer_ID = 23;
UPDATE EternalFlowStore.Customers SET Address = '3025 Ubi Road 1' WHERE Customer_ID = 24;
UPDATE EternalFlowStore.Customers SET Address = '154 WEST COAST ROAD' WHERE Customer_ID = 25;
UPDATE EternalFlowStore.Customers SET Address = '151 Choa Chu Kang Way' WHERE Customer_ID = 26;
UPDATE EternalFlowStore.Customers SET Address = '16 Jalan Kilang Timor' WHERE Customer_ID = 27;
UPDATE EternalFlowStore.Customers SET Address = '200 Jalan Sultan' WHERE Customer_ID = 28;
UPDATE EternalFlowStore.Customers SET Address = '71 Ayer Rajah Crescent' WHERE Customer_ID = 29;
UPDATE EternalFlowStore.Customers SET Address = 'HDB Ang Mo Kio 609 Ang Mo Kio Avenue 4' WHERE Customer_ID = 30;

UPDATE EternalFlowStore.Customers SET Address = '12 Fox Estates Cooperchester' WHERE Customer_ID = 31;
UPDATE EternalFlowStore.Customers SET Address = '914 Pauline Motorway Alicebury' WHERE Customer_ID = 32;
UPDATE EternalFlowStore.Customers SET Address = '954 Elizabeth Ramp Rosschester' WHERE Customer_ID = 33;
UPDATE EternalFlowStore.Customers SET Address = '54 White Lane Lindsayport' WHERE Customer_ID = 34;
UPDATE EternalFlowStore.Customers SET Address = 'Flat 74 Gavin Extension Neilborough ' WHERE Customer_ID = 35;
UPDATE EternalFlowStore.Customers SET Address = 'Flat 83s Holly Curve Michaelbury' WHERE Customer_ID = 36;
UPDATE EternalFlowStore.Customers SET Address = '713 Joseph Islands Lake Patricia' WHERE Customer_ID = 37;
UPDATE EternalFlowStore.Customers SET Address = '6 Neil Throughway West Alfiehaven' WHERE Customer_ID = 38;
UPDATE EternalFlowStore.Customers SET Address = '18 Victoria Road' WHERE Customer_ID = 39;
UPDATE EternalFlowStore.Customers SET Address = '6 Rhosddu Rd' WHERE Customer_ID = 40;

UPDATE EternalFlowStore.Customers SET Address = '41 rue Gustave Eiffel' WHERE Customer_ID = 41;
UPDATE EternalFlowStore.Customers SET Address = '70 rue du Paillle en queue' WHERE Customer_ID = 42;
UPDATE EternalFlowStore.Customers SET Address = '4 rue Jean Vilar' WHERE Customer_ID = 43;
UPDATE EternalFlowStore.Customers SET Address = '2 rue de Penthièvre' WHERE Customer_ID = 44;
UPDATE EternalFlowStore.Customers SET Address = '65 boulevard de la Liberation' WHERE Customer_ID = 45;
UPDATE EternalFlowStore.Customers SET Address = '41 Rue Roussy' WHERE Customer_ID = 46;
UPDATE EternalFlowStore.Customers SET Address = '36 Chemin Du Lavarin Sud' WHERE Customer_ID = 47;
UPDATE EternalFlowStore.Customers SET Address = '56 rue du Président Roosevelt' WHERE Customer_ID = 48;
UPDATE EternalFlowStore.Customers SET Address = '81 Rue Hubert de Lisle' WHERE Customer_ID = 49;
UPDATE EternalFlowStore.Customers SET Address = '82 avenue Jean Portalis' WHERE Customer_ID = 50;

UPDATE EternalFlowStore.Customers SET Address = 'Bo La Merced Cl Dr Federico Penado' WHERE Customer_ID = 51;
UPDATE EternalFlowStore.Customers SET Address = '57 Av N Cond Miramonte Edf' WHERE Customer_ID = 52;
UPDATE EternalFlowStore.Customers SET Address = 'Bo El Centro Av Ppal, San Ignacio' WHERE Customer_ID = 53;
UPDATE EternalFlowStore.Customers SET Address = '5 Cl Pte Y 10 Av Sur' WHERE Customer_ID = 54;
UPDATE EternalFlowStore.Customers SET Address = 'Blvd Hugo Rafael Chávez Rpto San Bartolo' WHERE Customer_ID = 55;
UPDATE EternalFlowStore.Customers SET Address = 'Bo Sta Bárbara 6 Av Sur' WHERE Customer_ID = 56;
UPDATE EternalFlowStore.Customers SET Address = '12 Av Nte No 1-9' WHERE Customer_ID = 57;
UPDATE EternalFlowStore.Customers SET Address = 'Bo La Parroquia 4 Cl Ote No 5, Usulutan' WHERE Customer_ID = 58;
UPDATE EternalFlowStore.Customers SET Address = 'Blvd San Bartolo Rpto San Bartolo ' WHERE Customer_ID = 59;
UPDATE EternalFlowStore.Customers SET Address = 'Carrt a San Salvador Km 63 1/2 Colonia' WHERE Customer_ID = 60;

-- City
UPDATE EternalFlowStore.Customers SET City = 'Los Angeles' WHERE Customer_ID = 1;
UPDATE EternalFlowStore.Customers SET City = 'Los Angeles' WHERE Customer_ID = 2;
UPDATE EternalFlowStore.Customers SET City = 'Los Angeles' WHERE Customer_ID = 3;
UPDATE EternalFlowStore.Customers SET City = 'Bronx' WHERE Customer_ID = 4;
UPDATE EternalFlowStore.Customers SET City = 'Cedar Rapids' WHERE Customer_ID = 5;
UPDATE EternalFlowStore.Customers SET City = 'Owatonna' WHERE Customer_ID = 6;
UPDATE EternalFlowStore.Customers SET City = 'San Antonio' WHERE Customer_ID = 7;
UPDATE EternalFlowStore.Customers SET City = 'Bedford' WHERE Customer_ID = 8;
UPDATE EternalFlowStore.Customers SET City = 'Seattle' WHERE Customer_ID = 9;
UPDATE EternalFlowStore.Customers SET City = 'San Jose' WHERE Customer_ID = 10;


UPDATE EternalFlowStore.Customers SET City = 'Goheung-gun' WHERE Customer_ID = 11;
UPDATE EternalFlowStore.Customers SET City = 'Paju-si'  WHERE Customer_ID = 12;
UPDATE EternalFlowStore.Customers SET City = 'Masan-si'  WHERE Customer_ID = 13;
UPDATE EternalFlowStore.Customers SET City = 'Suseong-gu' WHERE Customer_ID = 14;
UPDATE EternalFlowStore.Customers SET City = 'Jung-gu' WHERE Customer_ID = 15;
UPDATE EternalFlowStore.Customers SET City = 'Yeongdeungpo-gu' WHERE Customer_ID = 16;
UPDATE EternalFlowStore.Customers SET City = 'Nam-gu' WHERE Customer_ID = 17;
UPDATE EternalFlowStore.Customers SET City = 'Yeonje-gu' WHERE Customer_ID = 18;
UPDATE EternalFlowStore.Customers SET City = 'Yeongcheon-si' WHERE Customer_ID = 19;
UPDATE EternalFlowStore.Customers SET City = 'Yeongdeungpo-gu' WHERE Customer_ID = 20;


UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 21;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 22;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 23;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 24;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 25;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 26;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 27;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 28;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 29;
UPDATE EternalFlowStore.Customers SET City = 'Singapore' WHERE Customer_ID = 30;
      
UPDATE EternalFlowStore.Customers SET City = 'Wolferlow' WHERE Customer_ID = 31;
UPDATE EternalFlowStore.Customers SET City = 'Chalk' WHERE Customer_ID = 32;
UPDATE EternalFlowStore.Customers SET City = 'Kettins' WHERE Customer_ID = 33;
UPDATE EternalFlowStore.Customers SET City = 'Fourlanes End' WHERE Customer_ID = 34;
UPDATE EternalFlowStore.Customers SET City = 'Caggan' WHERE Customer_ID = 35;
UPDATE EternalFlowStore.Customers SET City = 'Low Habberley' WHERE Customer_ID = 36;
UPDATE EternalFlowStore.Customers SET City = 'Egmanton' WHERE Customer_ID = 37;
UPDATE EternalFlowStore.Customers SET City = 'Whitefield' WHERE Customer_ID = 38;
UPDATE EternalFlowStore.Customers SET City = 'Mundford' WHERE Customer_ID = 39;
UPDATE EternalFlowStore.Customers SET City = 'Doccombe' WHERE Customer_ID = 40;

UPDATE EternalFlowStore.Customers SET City = 'Montigny-lÈs-metz' WHERE Customer_ID = 41;
UPDATE EternalFlowStore.Customers SET City = 'Marseille' WHERE Customer_ID = 42;
UPDATE EternalFlowStore.Customers SET City = 'NÎmes' WHERE Customer_ID = 43;
UPDATE EternalFlowStore.Customers SET City = 'Lyon' WHERE Customer_ID = 44;
UPDATE EternalFlowStore.Customers SET City = 'Lorient' WHERE Customer_ID = 45;
UPDATE EternalFlowStore.Customers SET City = 'Saint-louis' WHERE Customer_ID = 46;
UPDATE EternalFlowStore.Customers SET City = 'Dunkerque' WHERE Customer_ID = 47;
UPDATE EternalFlowStore.Customers SET City = 'Marseille' WHERE Customer_ID = 48;
UPDATE EternalFlowStore.Customers SET City = 'Antony' WHERE Customer_ID = 49;
UPDATE EternalFlowStore.Customers SET City = 'Chelles' WHERE Customer_ID = 50; 

UPDATE EternalFlowStore.Customers SET City = 'San Salvador' WHERE Customer_ID = 51;
UPDATE EternalFlowStore.Customers SET City = 'Santa Ana' WHERE Customer_ID = 52;
UPDATE EternalFlowStore.Customers SET City = 'La Libertad' WHERE Customer_ID = 53;
UPDATE EternalFlowStore.Customers SET City = 'San Salvador' WHERE Customer_ID = 54;
UPDATE EternalFlowStore.Customers SET City = 'Chalatenango' WHERE Customer_ID = 55;
UPDATE EternalFlowStore.Customers SET City = 'Ahuachapán' WHERE Customer_ID = 56;
UPDATE EternalFlowStore.Customers SET City = 'San Rafael Cedros' WHERE Customer_ID = 57;
UPDATE EternalFlowStore.Customers SET City = 'San Miguel' WHERE Customer_ID = 58;
UPDATE EternalFlowStore.Customers SET City = 'San Salvador' WHERE Customer_ID = 59;
UPDATE EternalFlowStore.Customers SET City = 'Santa Ana' WHERE Customer_ID = 60;

-- StateProvinceArea
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'California' WHERE Customer_ID = 1;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'California' WHERE Customer_ID = 2;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'California' WHERE Customer_ID = 3;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'New York' WHERE Customer_ID = 4;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Iowa' WHERE Customer_ID = 5;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Minnesota' WHERE Customer_ID = 6;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Texas' WHERE Customer_ID = 7;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Massachusetts' WHERE Customer_ID = 8;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Washington' WHERE Customer_ID = 9;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'California' WHERE Customer_ID = 10;

UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Jeollanam-do' WHERE Customer_ID = 11;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Gyeongsangnam-do' WHERE Customer_ID = 12;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Daegu' WHERE Customer_ID = 13;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Ulsan' WHERE Customer_ID = 14;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Seoul' WHERE Customer_ID = 15;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Busan' WHERE Customer_ID = 16;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Busan' WHERE Customer_ID = 17;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Gyeongsangbuk-do' WHERE Customer_ID = 18;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Seoul' WHERE Customer_ID = 19;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Seoul' WHERE Customer_ID = 20;

UPDATE EternalFlowStore.Customers SET StateProvinceArea = '219492' WHERE Customer_ID = 21;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '139951' WHERE Customer_ID = 22;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '627804' WHERE Customer_ID = 23;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '079903' WHERE Customer_ID = 24;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '387515' WHERE Customer_ID = 25;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '099254' WHERE Customer_ID = 26;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '049705' WHERE Customer_ID = 27;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '436922' WHERE Customer_ID = 28;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '150145' WHERE Customer_ID = 29;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = '079025' WHERE Customer_ID = 30;

UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'WR15 8NH' WHERE Customer_ID = 31;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'DA12 6XG' WHERE Customer_ID = 32;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'PH13 0BG' WHERE Customer_ID = 33;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'CW11 9AP' WHERE Customer_ID = 34;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'PH22 3NU' WHERE Customer_ID = 35;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'DY11 1AX' WHERE Customer_ID = 36;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'NG22 5YS' WHERE Customer_ID = 37;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'AB51 1GZ' WHERE Customer_ID = 38;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'IP26 1WU' WHERE Customer_ID = 39;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'TQ13 9BR' WHERE Customer_ID = 40;

UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Lorraine' WHERE Customer_ID = 41;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Provence-Alpes-Côte dAzur' WHERE Customer_ID = 42;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Languedoc-Roussillon' WHERE Customer_ID = 43;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Rhône-Alpes' WHERE Customer_ID = 44;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Bretagne' WHERE Customer_ID = 45;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Alsace' WHERE Customer_ID = 46;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Nord-Pas-de-Calais' WHERE Customer_ID = 47;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Provence-Alpes-Côte dAzur' WHERE Customer_ID = 48;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Île-de-France' WHERE Customer_ID = 49;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Île-de-France' WHERE Customer_ID = 50;

UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'San Salvador' WHERE Customer_ID = 51;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Santa Ana' WHERE Customer_ID = 52;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'La Libertad' WHERE Customer_ID = 53;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'San Salvador' WHERE Customer_ID = 54;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Chalatenango' WHERE Customer_ID = 55;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Ahuachapán' WHERE Customer_ID = 56;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Cuscatlán' WHERE Customer_ID = 57;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'San Miguel' WHERE Customer_ID = 58;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'San Salvador' WHERE Customer_ID = 59;
UPDATE EternalFlowStore.Customers SET StateProvinceArea = 'Santa Ana' WHERE Customer_ID = 60;
     
-- Country
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 1;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 2;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 3;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 4;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 5;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 6;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 7;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 8;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 9;
UPDATE EternalFlowStore.Customers SET Country = 'USA' WHERE Customer_ID = 10;

UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 11;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 12;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 13;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 14;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 15;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 16;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 17;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 18;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 19;
UPDATE EternalFlowStore.Customers SET Country = 'South Korea' WHERE Customer_ID = 20;

UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 21;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 22;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 23;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 24;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 25;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 26;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 27;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 28;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 29;
UPDATE EternalFlowStore.Customers SET Country = 'Singapore' WHERE Customer_ID = 30;

UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 31;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 32;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 33;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 34;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 35;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 36;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 37;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 38;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 39;
UPDATE EternalFlowStore.Customers SET Country = 'United Kingdom' WHERE Customer_ID = 40;

UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 41;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 42;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 43;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 44;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 45;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 46;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 47;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 48;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 49;
UPDATE EternalFlowStore.Customers SET Country = 'France' WHERE Customer_ID = 50;

UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 51;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 52;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 53;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 54;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 55;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 56;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 57;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 58;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 59;
UPDATE EternalFlowStore.Customers SET Country = 'El Salvador' WHERE Customer_ID = 60;

-- Phone Number
UPDATE EternalFlowStore.Customers SET PhoneNumber = '951-324-1926' WHERE Customer_ID = 1;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '818-523-5155' WHERE Customer_ID = 2;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '310-210-1829' WHERE Customer_ID = 3;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '347-833-3288' WHERE Customer_ID = 4;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '507-413-2113' WHERE Customer_ID = 5;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '210-613-5992' WHERE Customer_ID = 5;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '351-201-7926' WHERE Customer_ID = 6;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '206-532-0210' WHERE Customer_ID = 7;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '408-690-3022' WHERE Customer_ID = 8;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '408-966-6280' WHERE Customer_ID = 9;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '206-803-0265' WHERE Customer_ID = 10;

UPDATE EternalFlowStore.Customers SET PhoneNumber = '02-4489-1004' WHERE Customer_ID = 11;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '1583-8732'   WHERE Customer_ID = 12;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '59.177.219.136' WHERE Customer_ID = 12;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '055-6374-3694'  WHERE Customer_ID = 13;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '1676-6335'   WHERE Customer_ID = 14;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '043-8158-2101' WHERE Customer_ID = 15;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '054-7914-8944' WHERE Customer_ID = 16;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '070-7199-4267'  WHERE Customer_ID = 17;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '061-1403-7089'  WHERE Customer_ID = 18;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '043-6162-5841' WHERE Customer_ID = 19;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '82-7-076-7079' WHERE Customer_ID = 20;

UPDATE EternalFlowStore.Customers SET PhoneNumber = '6883 2678'  WHERE Customer_ID = 21;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '65 6281 3169'  WHERE Customer_ID = 22;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '65 8406 5518'  WHERE Customer_ID = 23;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '65 6734 8479'  WHERE Customer_ID = 24;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '6516 0746'  WHERE Customer_ID = 25;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '65 9162 0687' WHERE Customer_ID = 26;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '6351 4475'  WHERE Customer_ID = 27;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '65 8330 6705'  WHERE Customer_ID = 28;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '65 6824 5049' WHERE Customer_ID = 29;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '65 9508 7152'  WHERE Customer_ID = 30;


UPDATE EternalFlowStore.Customers SET PhoneNumber = '+44(0)4123 636390' WHERE Customer_ID = 31;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '(03397) 12221'  WHERE Customer_ID = 32;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '02249 94960' WHERE Customer_ID = 33;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '0307 7672038'  WHERE Customer_ID = 34;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '0289066709'  WHERE Customer_ID = 35;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+44(0)8925415190'   WHERE Customer_ID = 36;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '0793126557'  WHERE Customer_ID = 37;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '0389507553'   WHERE Customer_ID = 38;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '0389507553'  WHERE Customer_ID = 39;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+44(0)7706 257880' WHERE Customer_ID = 40;

UPDATE EternalFlowStore.Customers SET PhoneNumber = '+33 (0)8 14 87 71 54'  WHERE Customer_ID = 41;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '08 93 69 98 09' WHERE Customer_ID = 42;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+33 1 89 74 03 10'  WHERE Customer_ID = 43;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '0235697520'  WHERE Customer_ID = 44;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+33 (0)6 06 36 40 41'  WHERE Customer_ID = 45;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+33 2 96 16 05 89' WHERE Customer_ID = 46;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '01 92 97 85 33'  WHERE Customer_ID = 47;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '0469041394'  WHERE Customer_ID = 48;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '0669041485'   WHERE Customer_ID = 49;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+33 (0)2 50 59 32 89'   WHERE Customer_ID = 50;

UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 26080765'  WHERE Customer_ID = 51;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 23724721' WHERE Customer_ID = 52;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 22808354'  WHERE Customer_ID = 53;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 23725756'  WHERE Customer_ID = 54;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 22808354' WHERE Customer_ID = 55;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 24502565' WHERE Customer_ID = 56;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 22601919'  WHERE Customer_ID = 57;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 23344277'  WHERE Customer_ID = 58;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 22576565'  WHERE Customer_ID = 59;
UPDATE EternalFlowStore.Customers SET PhoneNumber = '+503 22550490'  WHERE Customer_ID = 60;
    
-- Email 
UPDATE EternalFlowStore.Customers SET Email = 'grice@yahoo.com' WHERE Customer_ID = 1;
UPDATE EternalFlowStore.Customers SET Email = 'kihn.ramiro@price.com' WHERE Customer_ID = 2;
UPDATE EternalFlowStore.Customers SET Email = 'trantow.jakayla@hotmail.com' WHERE Customer_ID = 3;
UPDATE EternalFlowStore.Customers SET Email = 'birdie.bechtelar@hegmann.biz' WHERE Customer_ID = 4;
UPDATE EternalFlowStore.Customers SET Email = 'murray.estel@tromp.com' WHERE Customer_ID = 5;
UPDATE EternalFlowStore.Customers SET Email = 'serena78@yahoo.com' WHERE Customer_ID = 6;
UPDATE EternalFlowStore.Customers SET Email = 'durward76@gmail.com' WHERE Customer_ID = 7;
UPDATE EternalFlowStore.Customers SET Email = 'stark.trenton@gmail.com' WHERE Customer_ID = 8;
UPDATE EternalFlowStore.Customers SET Email = 'al.turner@hotmail.com' WHERE Customer_ID = 9;
UPDATE EternalFlowStore.Customers SET Email = 'osatterfield@gmail.com' WHERE Customer_ID = 10;

UPDATE EternalFlowStore.Customers SET Email = 'junyoung.yu@yahoo.com' WHERE Customer_ID = 11;
UPDATE EternalFlowStore.Customers SET Email = 'echoi@gwon.kr' WHERE Customer_ID = 12;
UPDATE EternalFlowStore.Customers SET Email = 'fgwak@yang.biz' WHERE Customer_ID = 13;
UPDATE EternalFlowStore.Customers SET Email = 'sheo@park.net' WHERE Customer_ID = 14;
UPDATE EternalFlowStore.Customers SET Email = 'youngjin.ryu@hotmail.com' WHERE Customer_ID = 15;
UPDATE EternalFlowStore.Customers SET Email = 'hong.sanghun@gwak.biz' WHERE Customer_ID = 16;
UPDATE EternalFlowStore.Customers SET Email = 'eunyoung.song@shin.net' WHERE Customer_ID = 17;
UPDATE EternalFlowStore.Customers SET Email = 'taehee.go@hotmail.com' WHERE Customer_ID = 18;
UPDATE EternalFlowStore.Customers SET Email = 'sanghun95@son.kr' WHERE Customer_ID = 19;
UPDATE EternalFlowStore.Customers SET Email = 'qjo@gmail.com' WHERE Customer_ID = 20;

UPDATE EternalFlowStore.Customers SET Email = 'kubum49@gmail.com' WHERE Customer_ID = 21;
UPDATE EternalFlowStore.Customers SET Email = 'celine13@hotmail.com' WHERE Customer_ID = 22;
UPDATE EternalFlowStore.Customers SET Email = 'izaiah89@yahoo.com' WHERE Customer_ID = 23;
UPDATE EternalFlowStore.Customers SET Email = 'kathlyn.cummerata@hotmail.com'  WHERE Customer_ID = 24;
UPDATE EternalFlowStore.Customers SET Email = 'rgottlieb@mccullough.com' WHERE Customer_ID = 25;
UPDATE EternalFlowStore.Customers SET Email = 'dorthy90@hotmail.com' WHERE Customer_ID = 26;
UPDATE EternalFlowStore.Customers SET Email = 'xbogisich@reilly.com' WHERE Customer_ID = 27;
UPDATE EternalFlowStore.Customers SET Email = 'eliseo.zulauf@yahoo.com' WHERE Customer_ID = 28;
UPDATE EternalFlowStore.Customers SET Email = 'reid32@berge.com' WHERE Customer_ID = 29;
UPDATE EternalFlowStore.Customers SET Email =  'lesch.orion@gmail.com' WHERE Customer_ID = 30;

UPDATE EternalFlowStore.Customers SET Email = 'wunsch.theron@hotmail.com' WHERE Customer_ID = 31;
UPDATE EternalFlowStore.Customers SET Email = 'thomas.poppy@yahoo.com' WHERE Customer_ID = 32;
UPDATE EternalFlowStore.Customers SET Email = 'carlie.walker@hotmail.com' WHERE Customer_ID = 33;
UPDATE EternalFlowStore.Customers SET Email = 'lisa51@richards.org'  WHERE Customer_ID = 34;
UPDATE EternalFlowStore.Customers SET Email = 'arthur.simpson@gmail.co.uk' WHERE Customer_ID = 35;
UPDATE EternalFlowStore.Customers SET Email = 'gcook@anderson.net' WHERE Customer_ID = 36;
UPDATE EternalFlowStore.Customers SET Email = 'kieran07@gmail.com' WHERE Customer_ID = 37;
UPDATE EternalFlowStore.Customers SET Email = 'reid.ben@gmail.com' WHERE Customer_ID = 38;
UPDATE EternalFlowStore.Customers SET Email = 'lloyd.emma@griffiths.com' WHERE Customer_ID = 39;
UPDATE EternalFlowStore.Customers SET Email = 'anderson.keeley@davies.co.uk' WHERE Customer_ID = 40;

UPDATE EternalFlowStore.Customers SET Email = 'francois.leon@yahoo.com' WHERE Customer_ID = 41;
UPDATE EternalFlowStore.Customers SET Email = 'charlotte.denis@morel.com' WHERE Customer_ID = 42;
UPDATE EternalFlowStore.Customers SET Email = 'eugene78@maurice.org'  WHERE Customer_ID = 43;
UPDATE EternalFlowStore.Customers SET Email = 'meyer.susanne@charles.fr'  WHERE Customer_ID = 44;
UPDATE EternalFlowStore.Customers SET Email = 'dorothee.levy@lacombe.org' WHERE Customer_ID = 45;
UPDATE EternalFlowStore.Customers SET Email = 'arnaude21@bouygtel.fr' WHERE Customer_ID = 46;
UPDATE EternalFlowStore.Customers SET Email = 'marguerite67@bouygtel.fr' WHERE Customer_ID = 47;
UPDATE EternalFlowStore.Customers SET Email = 'poirier.philippe@legall.com' WHERE Customer_ID = 48;
UPDATE EternalFlowStore.Customers SET Email = 'denis92@yahoo.fr'  WHERE Customer_ID = 49;
UPDATE EternalFlowStore.Customers SET Email = 'francois33@club-internet.fr'  WHERE Customer_ID = 50;

UPDATE EternalFlowStore.Customers SET Email = 'guardo14@lupito.el'  WHERE Customer_ID = 51;
UPDATE EternalFlowStore.Customers SET Email = 'rramos@davila.net.br'  WHERE Customer_ID = 52;
UPDATE EternalFlowStore.Customers SET Email = 'ibonilha@quintana.net.el'  WHERE Customer_ID = 53;
UPDATE EternalFlowStore.Customers SET Email = 'fabiana.saraiva@yahoo.com'  WHERE Customer_ID = 54;
UPDATE EternalFlowStore.Customers SET Email = 'santacruz.noeli@faro.com.el'  WHERE Customer_ID = 55;
UPDATE EternalFlowStore.Customers SET Email = 'christopher.estrada@uol.com.el' WHERE Customer_ID = 56;
UPDATE EternalFlowStore.Customers SET Email = 'fernando.ramires@yahoo.com'  WHERE Customer_ID = 57;
UPDATE EternalFlowStore.Customers SET Email = 'emilia11@soares.net'  WHERE Customer_ID = 58;
UPDATE EternalFlowStore.Customers SET Email = 'deoliveira.elizabeth@yahoo.com'  WHERE Customer_ID = 59;
UPDATE EternalFlowStore.Customers SET Email = 'isabella65@hotmail.com'  WHERE Customer_ID = 60;
-------------------------------------------------------------------------------
/*******************************************************************************
   Populate Table 4
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

--TABLE 4
INSERT INTO EternalFlowStore.OrderHistory ( Name )
VALUES(
    'EternalFlow T-Shirt'
);

SELECT * FROM EternalFlowStore.OrderHistory;



