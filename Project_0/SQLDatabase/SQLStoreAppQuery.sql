CREATE TABLE Customer
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    DefualtStore VARCHAR(255)
);

SELECT * FROM Customer;
INSERT into Customer(FirstName,LastName,DefualtStore)
VALUES ('Christos', 'De Los Santos', 'None');

DROP TABLE Customer;

CREATE TABLE Orders
(
    OrderId INT IDENTITY(1,1),
    Product VARCHAR(255),
    Quantity INT,
    OrderTime DATETIME,
    Customer VARCHAR(255),
    Store VARCHAR(255)
);
SELECT * FROM Orders;
INSERT into Orders(Product,Quantity,OrderTime,Customer,Store)
VALUES ('Phone', 2, 22-04-04, 'Diego','New York Store');
DROP TABLE Orders;

CREATE TABLE Stores
(
    Product VARCHAR(255),
    Inventory INT,
    QuantityOrdered INT,
    InStock VARCHAR(255),
    Store VARCHAR(255)
);
SELECT * FROM Stores;
INSERT into Stores(Product,Quantity,OrderTime,Customer,Store)
VALUES ('Phone', 2, 22-04-04, 'Diego','New York Store');
DROP TABLE Orders;