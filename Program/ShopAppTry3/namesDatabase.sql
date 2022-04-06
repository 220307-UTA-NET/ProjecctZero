CREATE SCHEMA Names;
GO

CREATE TABLE Names.Stores(
    Name NVARCHAR (100) PRIMARY KEY IDENTITY,
    Store_ID INT,
    CHECK (LEN(Name) >0)
)

CREATE TABLE Names.Product(
    Name NVARCHAR (150) PRIMARY KEY IDENTITY,
    ProductName INT,
    ProductMaker NVARCHAR (255),
    CHECK (LEN(Name) >0)
)