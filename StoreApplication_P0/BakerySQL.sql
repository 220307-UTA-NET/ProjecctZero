CREATE SCHEMA BakeryApp;
GO

--  Table of Store Locations
CREATE TABLE BakeryApp.StoreLocation(
    StoreName NVARCHAR(255) NOT NULL PRIMARY KEY
);
-- DROP TABLE BakeryApp.StoreLocation

INSERT INTO BakeryApp.StoreLocation (StoreName)
VALUES  
    ('Springfield_VA'),
    ('Washington_DC'),
    ('Charlottesville_VA');
-- 


--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


-- -- Table of Customers
-- CREATE TABLE BakeryApp.Customer(
--     CustomerID INT IDENTITY(1111,1) PRIMARY KEY,
--     Username NVARCHAR(255) NOT NULL UNIQUE,
--     userPassword NVARCHAR(255) NOT NULL,
--     FirstName NVARCHAR(255) NOT NULL,
--     LastName NVARCHAR(255) NOT NULL,
--     Email NVARCHAR(255) NOT NULL UNIQUE,
--     DefaultStore NVARCHAR(255) NOT NULL
--     -- AnswerToSecurityQuestion1 NVARCHAR(500) NOT NULL,
--     -- AnswerToSecurityQuestion2 NVARCHAR(500) NOT NULL
-- );

-- Table of Customers
CREATE TABLE BakeryApp.Customer(
    CustomerID INT IDENTITY(1111,1) NOT NULL,
    Username NVARCHAR(255) NOT NULL UNIQUE,
    userPassword NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    DefaultStore NVARCHAR(255) NOT NULL,
    PRIMARY KEY (CustomerID, DefaultStore)

    -- AnswerToSecurityQuestion1 NVARCHAR(500) NOT NULL,
    -- AnswerToSecurityQuestion2 NVARCHAR(500) NOT NULL
);


-- DROP TABLE BakeryApp.Customer;
SELECT * FROM BakeryApp.Customer;

INSERT INTO BakeryApp.Customer(Username,userPassword, FirstName, LastName, Email, DefaultStore)
VALUES 
('kelly0211', 'password', 'Kelly', 'Keng', 'kelly0211@gmail.com', 'Springfield, VA'),
('my_user', 'password123', 'Sally', 'Jo', 'sally_jo@email.com', 'CHarlottesville, VA'),
('customerUser', 'hacked321', 'John', 'Doe', 'JohnnyBoy@email.com', 'Washington, D.C.');


--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- -- Customer's Order History
-- CREATE TABLE BakeryApp.CustomerOrderHistory(    
--     OrderNumber INT PRIMARY KEY IDENTITY,
--     DatePlaced Date NOT NULL DEFAULT GETDATE(),    
--     TimeOrdered TIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
--     MyTime TIME NOT NULL DEFAULT CURRENT_TIMESTAMP AT TIME ZONE 'UTC' AT TIME ZONE 'Eastern Standard Time',
--     -- TimePlaced datetimeoffset NOT NULL DEFAULT GETDATE(),   
--     -- TimeSmall smalldatetime NOT NULL DEFAULT SYSDATETIME(),       
--     No_of_Items INT NOT NULL
-- );
-- Customer's Order History
CREATE TABLE BakeryApp.CustomerOrderHistory(    
    OrderNumber INT PRIMARY KEY IDENTITY,
    DatePlaced Date NOT NULL DEFAULT GETDATE(),    
    OrderTime TIME NOT NULL DEFAULT CURRENT_TIMESTAMP AT TIME ZONE 'UTC' AT TIME ZONE 'Eastern Standard Time',
    No_of_Items INT NOT NULL
);

-- Customer's Order History
CREATE TABLE BakeryApp.CustomerOrderHistory1(    
    OrderNumber INT NOT NULL
        FOREIGN KEY REFERENCES BakeryApp.StoreOrderLog(OrderNumber) ON DELETE CASCADE ON UPDATE CASCADE, 
    DatePlaced Date NOT NULL
        FOREIGN KEY REFERENCES BakeryApp.StoreOrderLog(DateOfOrder) ON DELETE CASCADE ON UPDATE CASCADE,      -- need to change 
    TimeOrdered TIME NOT NULL 
         FOREIGN KEY REFERENCES BakeryApp.StoreOrderLog(TimePlaced) ON DELETE CASCADE ON UPDATE CASCADE,
    No_of_Items INT NOT NULL,
    TotalCost SMALLMONEY NOT NULL
        FOREIGN KEY REFERENCES BakeryApp.StoreOrderLog(TotalCost) ON DELETE CASCADE ON UPDATE CASCADE 

    --  ITEMS!!!


    --  TIME NOT NULL DEFAULT CURRENT_TIMESTAMP AT TIME ZONE 'UTC' AT TIME ZONE 'Eastern Standard Time',
    -- TimePlaced datetimeoffset NOT NULL DEFAULT GETDATE(),    -- change above to foreign key
    -- TimeSmall smalldatetime NOT NULL DEFAULT SYSDATETIME(),     
    -- TimeOrdered TIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
);

-- DROP TABLE BakeryApp.CustomerOrderHistory;

INSERT INTO BakeryApp.CustomerOrderHistory(No_of_Items)
VALUES (2), (1), (4),(10);

SELECT * FROM BakeryApp.CustomerOrderHistory;


--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



-- -- Table for Desserts Inventory with # Sold
-- CREATE TABLE BakeryApp.FullInventory(
--     Item NVARCHAR(255) PRIMARY KEY,
--     Category NVARCHAR(255) NOT NULL,
--     Price SMALLMONEY NOT NULL,
--     Washington_DC_Stockpile INT NOT NULL,
--     NumberSold_Washington_DC INT DEFAULT 0,
--     Charlottesville_VA_Stockpile INT NOT NULL,
--     NumberSold_Charlottesville_VA INT DEFAULT 0,
--     Springfield_VA_Stockpile INT NOT NULL,
--     NumberSold_Springfield_VA INT DEFAULT 0
-- );    


-- Table for Desserts Inventory
CREATE TABLE BakeryApp.Inventory(
    Item NVARCHAR(255) PRIMARY KEY,
    Category NVARCHAR(255) NOT NULL,
    Price SMALLMONEY NOT NULL,
    Washington_DC_Stockpile INT NOT NULL,
    Charlottesville_VA_Stockpile INT NOT NULL,
    Springfield_VA_Stockpile INT NOT NULL,
);    

SELECT * FROM BakeryApp.FullInventory;
-- DROP TABLE BakeryApp.Inventory;

INSERT INTO BakeryApp.Inventory
    (Item, Category, Price, Washington_DC_Stockpile, Charlottesville_VA_Stockpile, Springfield_VA_Stockpile)
VALUES  
    ('Chocolate Cake', 'Cake', 40, 15, 15, 15),
    ('Strawberry Shortcake', 'Cake', 40, 15, 15, 15),
    ('Red Velvet', 'Cake', 30, 15, 15, 15),
    ('Boston Cream Pie', 'Cake', 50, 15, 15, 15),
    ('Tiramisu', 'Cake', 40, 15, 15, 15),
    
    ('Chocolate Chip', 'Cookies', 1.50, 35, 35, 35),
    ('Snickerdoodles', 'Cookies', 1.50, 35, 35, 35),
    ('Peanut Butter Blossoms', 'Cookies', 1.50, 35, 35, 35),
    ('Crinkle Cookies', 'Cookies', 1.50, 35, 35, 35),
    
    ('Apple Pie', 'Pie', 18.00, 10, 10, 10),
    ('Coconut Cream Pie', 'Pie', 25, 10, 10, 10),
    ('Chocolate Cream Pie', 'Pie', 20, 10, 10, 10),
    ('Blueberry Pie', 'Pie', 25, 10, 10, 10),
    
    ('Macarons (assorted)', 'French Pastries', 2.25, 40, 40, 40),
    ('Eclairs', 'French Pastries', 7.00, 20, 20, 20),
    ('Palmiers', 'French Pastries', 3.50, 30, 30, 30),
    ('Pot de creme', 'French Pastries', 7, 15, 15, 15),
    ('Croquembuche', 'French Pastries', 95, 5, 5, 5);    


SELECT Washington_DC_Stockpile
FROM BakeryApp.Inventory
WHERE Item = 'Chocolate Cake';

-- UPDATE BakeryApp.Inventory
-- SET Washington_DC_Stockpile = '@orderQuantity'
-- WHERE Item = @'selectedItem';


UPDATE BakeryApp.Inventory
SET Washington_DC_Stockpile = 3
WHERE Item = 'Chocolate Cake';



SELECT Item AS 'Cookies', Price, Washington_DC_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Cookies';

SELECT Item AS 'Pies', Price, Washington_DC_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Pie';

SELECT Item AS 'Cake', Price, Washington_DC_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Cake';

SELECT Item AS 'French Pastries', Price, Washington_DC_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'French Pastries';



SELECT Item AS 'Cookies', Price, Charlottesville_VA_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Cookies';

SELECT Item AS 'Pies', Price, Charlottesville_VA_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Pie';

SELECT Item AS 'Cake', Price, Charlottesville_VA_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Cake';

SELECT Item AS 'French Pastries', Price, Washington_DC_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'French Pastries';



SELECT Item AS 'Cookies', Price, Springfield_VA_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Cookies';

SELECT Item AS 'Pie', Price, Springfield_VA_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Pie';

SELECT Item AS 'Cake', Price, Springfield_VA_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'Cake';

SELECT Item AS 'French Pastries', Price, Washington_DC_Stockpile AS 'Quantity Available'
FROM BakeryApp.Inventory
WHERE Category = 'French Pastries';


--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


CREATE TABLE BakeryApp.StoreOrderLog(
    Store_Locations NVARCHAR(255) NOT NULL,
    -- Store_Location NVARCHAR(255) FOREIGN KEY REFERENCES BakeryApp.Customer (DefaultStore) ON DELETE CASCADE ON UPDATE CASCADE,
    OrderNumber INT PRIMARY KEY IDENTITY,
    CustomerID INT NOT NULL ,
        -- FOREIGN KEY REFERENCES BakeryApp.Customer (CustomerID) ON DELETE CASCADE ON UPDATE CASCADE,
    DateOfOrder Date NOT NULL DEFAULT GETDATE(),
    TimePlaced TIME NOT NULL DEFAULT CURRENT_TIMESTAMP AT TIME ZONE 'UTC' AT TIME ZONE 'Eastern Standard Time',
    No_of_Items INT NOT NULL,
    TotalCost SMALLMONEY NOT NULL
);
SELECT * FROM BakeryApp.StoreOrderLog;
-- DROP TABLE BakeryApp.StoreOrderLog

INSERT INTO BakeryApp.StoreOrderLog(Store_Locations, CustomerID, No_of_Items, TotalCost)
VALUES 
    ('Store_Locations', CustomerID, No_of_Items, TotalCost),
    ('Store_Locations', CustomerID, No_of_Items, TotalCost),
    (Store_Locations, CustomerID, No_of_Items, TotalCost);

--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 







--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

-- -- Customer's Order Detail
-- CREATE TABLE BakeryApp.CustomerOrderDetails(
--     CustomerID 
--     OrderNumber 
--     Date_Placed 
--     Store_Location NVARCHAR(255) NOT NULL,
--     Item NVARCHAR(255) NOT NULL,
--     Quantity INT NOT NULL
-- );   

-- SELECT * FROM BakeryApp.CustomerOrderDetails;
-- -- DROP TABLE BakeryApp.CustomerOrderDetails;


-- Items in CustomerOrder


ALTER TABLE BakeryApp.Customer
    ADD CONSTRAINT FK__Customer__DefaultStore FOREIGN KEY (DefaultStore)
        REFERENCES BakeryApp.StoreOrderLog (Store_Location);






-- DROP TABLE BakeryApp.CustomerReceipt;

-- CREATE TABLE BakeryApp.CustomerReceipt(
--     Items 
-- );    


-- CREATE TABLE BakeryApp.WashingtonDC_Inventory(
--     ()

-- );    
-- DROP TABLE BakeryApp.WashingtonDC_Inventory;


-- CREATE TABLE BakeryApp.SpringfieldVA_Inventory
-- DROP TABLE BakeryApp.SpringfieldVA_Inventory;


-- CREATE TABLE BakeryApp.CharlottesvilleVA_Inventory
-- DROP TABLE BakeryApp.CharlottesvilleVA_Inventory;


----------------------------------------------------------------------
----------------------------------------------------------------------

DROP TABLE BakeryApp.Customer;

DROP TABLE BakeryApp.CustomerOrderHistory;

DROP TABLE BakeryApp.WashingtonDCInventory;




CREATE TABLE BakeryApp.Receipt(    
    OrderNumber INT PRIMARY KEY IDENTITY,
    DatePlaced Date NOT NULL DEFAULT GETDATE(),    
    OrderTime TIME NOT NULL DEFAULT CURRENT_TIMESTAMP AT TIME ZONE 'UTC' AT TIME ZONE 'Eastern Standard Time',
    BostonCreamPie INT,
    BostonCreamPiePrice SMALLMONEY,
    ChocolateCake INT,
    ChocolateCakePrice SMALLMONEY,
    RedVelvet INT,
    RedVelvetPrice SMALLMONEY,
    StrawberryShortcake INT,
    StrawberryShortcakePrice SMALLMONEY,
    Tiramisu INT,
    TiramisuPrice SMALLMONEY
);
SELECT *
FROM  BakeryApp.Receipt;
INSERT INTO BakeryApp.Receipt(No_of_Items)
VALUES (2), (1), (4),(10);
