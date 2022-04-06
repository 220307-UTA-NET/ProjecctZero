CREATE SCHEMA Names;
GO

CREATE TABLE Names.Stores(
    Name NVARCHAR (100),
    Store_ID INT,
    CHECK (LEN(Name) >0)
)

CREATE TABLE Names.Product(
    ProductName NVARCHAR (150),
    ProductNum INT,
    ProductMaker NVARCHAR (255),
    CHECK (LEN(ProductName) >0),
    CHECK (LEN(ProductMaker) >0)
)

SELECT * FROM Names.Product;
SELECT * FROM Names.Stores;

DROP TABLE Names.Product;
DROP TABLE Names.Stores;

INSERT INTO Names.Stores (Name, Store_ID) VALUES     ('147th St (New York)', 1);
INSERT INTO Names.Stores (Name, Store_ID) VALUES     ('Delancy St AKA Canal St (New York)', 2);
INSERT INTO Names.Stores (Name, Store_ID) VALUES     ('95th St (New York)', 3);
INSERT INTO Names.Stores (Name, Store_ID) VALUES     ('Cicero Ave (Chicago)', 4);

INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('100 asstd Lug Nuts',1,'Auburn Motor Car Company');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Garlic Bread in a Can',2,'B & R House of Toast');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Raw Toast Loaf',3,'B & R House of Toast');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Box of Canadian Air',4,'CCA');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Box of Quebec Air',5,'CCA');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Roll of Flypaper',6,'Einbinder Flypaper');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Sheet of Flypaper',7,'Einbinder Flypaper');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Battery Powered Battery Charger', 8,'Feld Electrical');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Standing Cashregister',9,'Feld Electrical');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Box of 100 Paperclips',10,'Great Lakes Paperclip Company'); -- 0.27 cents now
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Gross Boxes of 100 Paperclips',11,'Great Lakes Paperclip Company'); --38.88 now
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Box of Mushies',12,'Kretchford');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('25 lb Bag of Flour (Gluten-free)',13,'Kretchford');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('1 lb of Veal (Cruelty-free)',14,'Kretchford');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Single Steel Ingots (Gloss)',15,'Monongahela');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Single Steel Ingots (High Gloss)',16,'Monongahela');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Single Steel Ingots (Matte)',17,'Monongahela');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Chocolate Cookies with White Stuff In-Between',18,'Penuche');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Chocolate Wobblie',19,'Penuche');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Pallet of Fudge',20,'Penuche');

UPDATE Names.Product
SET
ProductName = ('1 lb of Veal (Cruelty-free)')
WHERE
ProductNum = 14;

--temp replace:
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('100 asstd Lug Nuts',1,'Auburn Motor Car Company');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Raw Toast Loaf',2,'B & R House of Toast');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Box of Canadian Air',3,'CCA');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Roll of Flypaper',4,'Einbinder Flypaper');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Battery Powered Battery Charger', 5,'Feld Electrical');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Box of 100 Paperclips',6,'Great Lakes Paperclip Company'); -- 0.27 cents now
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Box of Mushies',7,'Kretchford');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Single Steel Ingots (High Gloss)',8,'Monongahela');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Chocolate Cookies with White Stuff In-Between',9,'Penuche');
INSERT INTO Names.Product (ProductName, ProductNum, ProductMaker) VALUES     ('Chocolate Wobblie',10,'Penuche');


