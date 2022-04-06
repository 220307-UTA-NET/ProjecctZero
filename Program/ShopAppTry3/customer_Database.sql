CREATE SCHEMA Customers;
GO

CREATE TABLE Customers.Accounts(
    CustomerID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR (255),
    LastName NVARCHAR (255),
    Address1 NVARCHAR (255),
    Address2 NVARCHAR (255),
    City NVARCHAR (255),
    StateAbb NVARCHAR (2),
    Zip NVARCHAR (10)
)

SELECT * FROM Customers.Accounts;

SELECT COUNT(*) FROM Customers.Accounts;

DROP TABLE Customers.Accounts;

INSERT INTO Customers.Accounts (FirstName, LastName, Address1, Address2, City, StateAbb, Zip ) VALUES     ('JOHN', 'DOE', '123 FAKE ST', '', 'PLACEHOLDER', 'DC', '45678');
INSERT INTO Customers.Accounts (FirstName, LastName, Address1, Address2, City, StateAbb, Zip ) VALUES     ('BOB', 'SHMIT', '246 RANDOM AVE', 'APT 12', 'REAL CITY', 'DC', '45678');

UPDATE Customers.AccountS
SET
Address1 = ('924 TEST ST')
WHERE
CustomerID = 3;
