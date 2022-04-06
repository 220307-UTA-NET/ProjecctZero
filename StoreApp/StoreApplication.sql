CREATE SCHEMA StoreApplication;
GO


CREATE TABLE StoreApplication.Customer( 
    CustomerID INT IDENTITY NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(32)  NOT NULL,
    LastName NVARCHAR(32) NOT NULL,
    Address NVARCHAR(255) NOt Null
);


DROP TABLE StoreApplication.Customer

SELECt * 
FROM StoreApplication.Customer
INSERT INTO StoreApplication.Customer(FirstName,LastName, Address) 
VALUES('Hosna', 'Samimi', 'Address1') 


CREATE TABLE StoreApplication.Product( 
    ProductID INT  NOT NULL PRIMARY KEY,
    Price FLOAT NOT NULL,
    NumberOfItems INT NOT NULL,
    Name NVARCHAR(32)  NOT NULL   
);


SELECT * 
FROM StoreApplication.Product
INSERT INTO StoreApplication.Product(ProductID, Price, NumberOfItems,Name ) 
VALUES(1, 20, 3, 'name1') 

INSERT INTO StoreApplication.Product(ProductID, Price, NumberOfItems,Name)
VALUES(4,22.5, 4, 'name2'),(3,23.1, 30,'name3')



CREATE TABLE StoreApplication.Orders( 
    OrderID INT  NOT NULL PRIMARY KEY,
    CustomerID INT NOT NULL,
    OrderTime DATETIME NOT NULL
);

ALTER TABLE StoreApplication.Orders
    ADD CONSTRAINT FK__Customer__CustomerID FOREIGN KEY ( CustomerID )
    REFERENCES StoreApplication.Customer (CustomerID);

SELECT * 
FROM StoreApplication.Orders
INSERT INTO StoreApplication.Orders(OrderID,CustomerID, OrderTime) 
VALUES(1, 1, GETDATE());



CREATE TABLE StoreApplication.OrderProduct(
ID INT NOT NULL PRIMARY KEY,
OrderID INT NOT NULL,
ProductID INT NOT NULL,
Quantity INT NOT NULL
);


ALTER TABLE StoreApplication.OrderProduct
    ADD CONSTRAINT FK__Product__ProductID FOREIGN KEY ( ProductID )
    REFERENCES StoreApplication.Product (ProductID);
    
ALTER TABLE StoreApplication.OrderProduct
    ADD CONSTRAINT FK__Order__OrderID FOREIGN KEY ( OrderID )
    REFERENCES StoreApplication.Orders (OrderID);

SELECT * 
FROM StoreApplication.OrderProduct
INSERT INTO StoreApplication.OrderProduct(ID,OrderID, ProductID, Quantity) 
VALUES(1, 1, 1, 10);

INSERT INTO StoreApplication.OrderProduct(ID,OrderID, ProductID, Quantity)
VALUES(2,1,2,12)



