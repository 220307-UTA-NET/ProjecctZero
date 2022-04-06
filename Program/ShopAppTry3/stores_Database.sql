CREATE SCHEMA Inventory;
GO
SELECT * FROM Names.Product;
SELECT * FROM Inventory.Item1;
SELECT * FROM Inventory.Item2;
SELECT * FROM Inventory.Item3;
SELECT * FROM Inventory.Item4;
SELECT * FROM Inventory.Item5;
SELECT * FROM Inventory.Item6;
SELECT * FROM Inventory.Item7;
SELECT * FROM Inventory.Item8;
SELECT * FROM Inventory.Item9;
SELECT * FROM Inventory.Item10;
SELECT * FROM Inventory.Item11;
DROP TABLE Inventory.Item1;
DROP TABLE Inventory.Item2;
DROP TABLE Inventory.Item3;
DROP TABLE Inventory.Item4;
DROP TABLE Inventory.Item5;
DROP TABLE Inventory.Item6;
DROP TABLE Inventory.Item7;
DROP TABLE Inventory.Item8;
DROP TABLE Inventory.Item9;
DROP TABLE Inventory.Item10;
DROP TABLE Inventory.Item11;
DROP TABLE Inventory.Item12;
DROP TABLE Inventory.Item13;
DROP TABLE Inventory.Item14;
DROP TABLE Inventory.Item15;
DROP TABLE Inventory.Item16;
DROP TABLE Inventory.Item17;
DROP TABLE Inventory.Item18;
DROP TABLE Inventory.Item19;
DROP TABLE Inventory.Item20;

CREATE TABLE Inventory.Item1(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY,
)
INSERT INTO Inventory.Item1 (Name, Quantity, Price) VALUES ('100 asstd Lug Nuts', 1585, 499.99);
INSERT INTO Inventory.Item1 (Name, Quantity, Price) VALUES ('100 asstd Lug Nuts', 5312, 499.99);
INSERT INTO Inventory.Item1 (Name, Quantity, Price) VALUES ('100 asstd Lug Nuts', 4367, 499.99);
INSERT INTO Inventory.Item1 (Name, Quantity, Price) VALUES ('100 asstd Lug Nuts', 6541, 499.99);
INSERT INTO Inventory.Item1 (Name, Quantity, Price) VALUES ('100 asstd Lug Nuts', 4011, 499.99);

CREATE TABLE Inventory.Item2(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item2 (Name, Quantity, Price) VALUES ('Garlic Bread in a Can', 5001, 12.49);
INSERT INTO Inventory.Item2 (Name, Quantity, Price) VALUES ('Garlic Bread in a Can', 3421, 12.49);
INSERT INTO Inventory.Item2 (Name, Quantity, Price) VALUES ('Garlic Bread in a Can', 6663, 12.49);
INSERT INTO Inventory.Item2 (Name, Quantity, Price) VALUES ('Garlic Bread in a Can', 4868, 12.49);
INSERT INTO Inventory.Item2 (Name, Quantity, Price) VALUES ('Garlic Bread in a Can', 4558, 12.49);

CREATE TABLE Inventory.Item3(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  5173, 4.79);
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  5830, 4.79);
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  3447, 4.79);
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  5132, 4.79);
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  5737, 4.79);



CREATE TABLE Inventory.Item4(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  563, 18.98);
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  496, 18.98);
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  357, 18.98);
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  517, 18.98);
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  387, 18.98);

CREATE TABLE Inventory.Item5(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Box of Quebec Air', 552, 17.30);
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Box of Quebec Air', 659, 17.30);
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Box of Quebec Air', 449, 17.30);
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Box of Quebec Air',  687, 17.30);
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Box of Quebec Air',  391, 17.30);

CREATE TABLE Inventory.Item6(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Roll of Flypaper',  15152, 1.19);
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Roll of Flypaper',  11862, 1.19);
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Roll of Flypaper',  7902, 1.19);
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Roll of Flypaper',  7740, 1.19);
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Roll of Flypaper', 11855, 1.19);

CREATE TABLE Inventory.Item7(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Sheet of Flypaper',  18231, 2.19);
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Sheet of Flypaper',  17498, 2.19);
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Sheet of Flypaper',  10721, 2.19);
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Sheet of Flypaper',  15475, 2.19);
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Sheet of Flypaper',  15520, 2.19);

CREATE TABLE Inventory.Item8(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  1191, 24.99);
INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  802, 24.99);
INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  1101, 24.99);
INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  941, 24.99);
INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  1046, 24.99);

CREATE TABLE Inventory.Item9(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item9 (Name,  Quantity, Price) VALUES ('Standing Cashregister',  951, 1389.00);
INSERT INTO Inventory.Item9 (Name,  Quantity, Price) VALUES ('Standing Cashregister',  687, 1389.00);
INSERT INTO Inventory.Item9 (Name,  Quantity, Price) VALUES ('Standing Cashregister',  570, 1389.00);
INSERT INTO Inventory.Item9 (Name,  Quantity, Price) VALUES ('Standing Cashregister',  510, 1389.00);
INSERT INTO Inventory.Item9 (Name,  Quantity, Price) VALUES ('Standing Cashregister',  977, 1389.00);

CREATE TABLE Inventory.Item10(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item10 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  33357, 0.27);
INSERT INTO Inventory.Item10 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  28747, 0.27);
INSERT INTO Inventory.Item10 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  22397, 0.27);
INSERT INTO Inventory.Item10 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  36525, 0.27);
INSERT INTO Inventory.Item10 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  28320, 0.27);

CREATE TABLE Inventory.Item11(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item11 (Name,  Quantity, Price) VALUES ('Gross Boxes of 100 Paperclips',  409, 38.88);
INSERT INTO Inventory.Item11 (Name,  Quantity, Price) VALUES ('Gross Boxes of 100 Paperclips',  555, 38.88);
INSERT INTO Inventory.Item11 (Name,  Quantity, Price) VALUES ('Gross Boxes of 100 Paperclips',  487, 38.88);
INSERT INTO Inventory.Item11 (Name,  Quantity, Price) VALUES ('Gross Boxes of 100 Paperclips',  586, 38.88);
INSERT INTO Inventory.Item11 (Name,  Quantity, Price) VALUES ('Gross Boxes of 100 Paperclips',  579, 38.88);

CREATE TABLE Inventory.Item12(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item12 (Name,  Quantity, Price) VALUES ('Box of Mushies',  3034, 4.59);
INSERT INTO Inventory.Item12 (Name,  Quantity, Price) VALUES ('Box of Mushies',  5676, 4.59);
INSERT INTO Inventory.Item12 (Name,  Quantity, Price) VALUES ('Box of Mushies',  5677, 4.59);
INSERT INTO Inventory.Item12 (Name,  Quantity, Price) VALUES ('Box of Mushies',  5728, 4.59);
INSERT INTO Inventory.Item12 (Name,  Quantity, Price) VALUES ('Box of Mushies',  4900, 4.59);

CREATE TABLE Inventory.Item13(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item13 (Name,  Quantity, Price) VALUES ('25 lb Bag of Flour (Gluten-free)',  5311, 16.98);
INSERT INTO Inventory.Item13 (Name,  Quantity, Price) VALUES ('25 lb Bag of Flour (Gluten-free)',  4795, 16.98);
INSERT INTO Inventory.Item13 (Name,  Quantity, Price) VALUES ('25 lb Bag of Flour (Gluten-free)',  3390, 16.98);
INSERT INTO Inventory.Item13 (Name,  Quantity, Price) VALUES ('25 lb Bag of Flour (Gluten-free)',  4168, 16.98);
INSERT INTO Inventory.Item13 (Name,  Quantity, Price) VALUES ('25 lb Bag of Flour (Gluten-free)',  6644, 16.98);

CREATE TABLE Inventory.Item14(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item14 (Name,  Quantity, Price) VALUES ('1 lb of Veal (Cruelty-free)',  2491, 19.99);
INSERT INTO Inventory.Item14 (Name,  Quantity, Price) VALUES ('1 lb of Veal (Cruelty-free)',  3234, 19.99);
INSERT INTO Inventory.Item14 (Name,  Quantity, Price) VALUES ('1 lb of Veal (Cruelty-free)',  2191, 19.99);
INSERT INTO Inventory.Item14 (Name,  Quantity, Price) VALUES ('1 lb of Veal (Cruelty-free)',  1706, 19.99);
INSERT INTO Inventory.Item14 (Name,  Quantity, Price) VALUES ('1 lb of Veal (Cruelty-free)',  3052, 19.99);

CREATE TABLE Inventory.Item15(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item15 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Gloss)',  2472, 2.80);
INSERT INTO Inventory.Item15 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Gloss)',  2565, 2.80);
INSERT INTO Inventory.Item15 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Gloss)',  1996, 2.80);
INSERT INTO Inventory.Item15 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Gloss)',  2469, 2.80);
INSERT INTO Inventory.Item15 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Gloss)',  2405, 2.80);

CREATE TABLE Inventory.Item16(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item16 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  2949, 3.80);
INSERT INTO Inventory.Item16 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  2680, 3.80);
INSERT INTO Inventory.Item16 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  1516, 3.80);
INSERT INTO Inventory.Item16 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  2277, 3.80);
INSERT INTO Inventory.Item16 (Name, Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  2713, 3.80);

CREATE TABLE Inventory.Item17(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item17 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Matte)',  1669, 2.50);
INSERT INTO Inventory.Item17 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Matte)',  1840, 2.50);
INSERT INTO Inventory.Item17 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Matte)',  1894, 2.50);
INSERT INTO Inventory.Item17 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (Matte)',  1947, 2.50);
INSERT INTO Inventory.Item17 (Name, Quantity, Price) VALUES ('Single Steel Ingots (Matte)',  3653, 2.50);

CREATE TABLE Inventory.Item18(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item18 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  5723, 3.98);
INSERT INTO Inventory.Item18 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  3768, 3.98);
INSERT INTO Inventory.Item18 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  3997, 3.98);
INSERT INTO Inventory.Item18 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  5184, 3.98);
INSERT INTO Inventory.Item18 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  5772, 3.98);

CREATE TABLE Inventory.Item19(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item19 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  3970, 14.99);
INSERT INTO Inventory.Item19 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  5593, 14.99);
INSERT INTO Inventory.Item19 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  3264, 14.99);
INSERT INTO Inventory.Item19 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  3980, 14.99);
INSERT INTO Inventory.Item19 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  4763, 14.99);

CREATE TABLE Inventory.Item20(
    Name NVARCHAR (100) NOT NULL,
    Store_ID INT PRIMARY KEY IDENTITY,
    CHECK (LEN(Name) >0),
    Quantity INT,
    Price SMALLMONEY
)
INSERT INTO Inventory.Item20 (Name, Quantity, Price) VALUES ('Pallet of Fudge',  108, 12635.30); -- 15.99
INSERT INTO Inventory.Item20 (Name, Quantity, Price) VALUES ('Pallet of Fudge',  148, 12635.30);
INSERT INTO Inventory.Item20 (Name, Quantity, Price) VALUES ('Pallet of Fudge',  123, 12635.30);
INSERT INTO Inventory.Item20 (Name, Quantity, Price) VALUES ('Pallet of Fudge', 163, 12635.30);
INSERT INTO Inventory.Item20 (Name, Quantity, Price) VALUES ('Pallet of Fudge',  71, 12635.30);


--temp replace:
INSERT INTO Inventory.Item2 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  5173, 4.79);
INSERT INTO Inventory.Item2 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  5830, 4.79);
INSERT INTO Inventory.Item2 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  3447, 4.79);
INSERT INTO Inventory.Item2 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  5132, 4.79);
INSERT INTO Inventory.Item2 (Name,  Quantity, Price) VALUES ('Raw Toast Loaf',  5737, 4.79);

INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  563, 18.98);
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  496, 18.98);
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  357, 18.98);
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  517, 18.98);
INSERT INTO Inventory.Item3 (Name,  Quantity, Price) VALUES ('Box of Canadian Air',  387, 18.98);

INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Roll of Flypaper',  15152, 1.19);
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Roll of Flypaper',  11862, 1.19);
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Roll of Flypaper',  7902, 1.19);
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Roll of Flypaper',  7740, 1.19);
INSERT INTO Inventory.Item4 (Name,  Quantity, Price) VALUES ('Roll of Flypaper', 11855, 1.19);

INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  1191, 24.99);
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  802, 24.99);
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  1101, 24.99);
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  941, 24.99);
INSERT INTO Inventory.Item5 (Name,  Quantity, Price) VALUES ('Battery Powered Battery Charger',  1046, 24.99);

INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  33357, 0.27);
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  28747, 0.27);
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  22397, 0.27);
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  36525, 0.27);
INSERT INTO Inventory.Item6 (Name,  Quantity, Price) VALUES ('Box of 100 Paperclip',  28320, 0.27);

INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Box of Mushies',  3034, 4.59);
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Box of Mushies',  5676, 4.59);
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Box of Mushies',  5677, 4.59);
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Box of Mushies',  5728, 4.59);
INSERT INTO Inventory.Item7 (Name,  Quantity, Price) VALUES ('Box of Mushies',  4900, 4.59);

INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  2949, 3.80);
INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  2680, 3.80);
INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  1516, 3.80);
INSERT INTO Inventory.Item8 (Name,  Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  2277, 3.80);
INSERT INTO Inventory.Item8 (Name, Quantity, Price) VALUES ('Single Steel Ingots (High Gloss)',  2713, 3.80);

INSERT INTO Inventory.Item9 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  5723, 3.98);
INSERT INTO Inventory.Item9 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  3768, 3.98);
INSERT INTO Inventory.Item9 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  3997, 3.98);
INSERT INTO Inventory.Item9 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  5184, 3.98);
INSERT INTO Inventory.Item9 (Name, Quantity, Price) VALUES ('Chocolate Cookies with White Stuff In-Between',  5772, 3.98);

INSERT INTO Inventory.Item10 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  3970, 14.99);
INSERT INTO Inventory.Item10 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  5593, 14.99);
INSERT INTO Inventory.Item10 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  3264, 14.99);
INSERT INTO Inventory.Item10 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  3980, 14.99);
INSERT INTO Inventory.Item10 (Name, Quantity, Price) VALUES ('Chocolate Wobblie',  4763, 14.99);