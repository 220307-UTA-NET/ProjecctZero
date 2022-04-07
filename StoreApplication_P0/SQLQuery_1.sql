
SELECT 'BakeryApp.Customer Table';
SELECT * FROM BakeryApp.Customer;

SELECT 'BakeryApp.CustomerOrderHistory Table';
SELECT * FROM BakeryApp.CustomerOrderHistory;

SELECT 'BakeryApp.Inventory Table';
SELECT * FROM BakeryApp.Inventory;





CREATE TABLE BakeryApp.StoreLocation(
    StoreID int IDENTITY PRIMARY KEY,
    StoreName NVARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE School.Student(
    Student_ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR (255) NOT NULL
);

CREATE TABLE School.CourseStudent(
    Course_ID NVARCHAR (31) NOT NULL
        FOREIGN KEY REFERENCES School.Course (Course_ID) ON DELETE CASCADE ON UPDATE CASCADE,
    Student_ID INT NOT NULL
        FOREIGN KEY REFERENCES School.Student (Student_ID) ON DELETE CASCADE ON UPDATE CASCADE
    PRIMARY KEY (Course_ID, Student_ID)
);


CREATE TABLE School.Teacher(
    Teacher_ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR (255) NOT NULL
    CHECK (LEN(Name) > 0)
);

CREATE TABLE School.Course ( -- Create a table named Course as part of the School schema
    Course_ID NVARCHAR (31) NOT NULL PRIMARY KEY, -- NOT NULL to enforce that the field must have a value
    Name NVARCHAR (255) NOT NULL,
    TeacherID INT NULL,             -- NULL allows this field to be null when the entry is addd to the table
    StartDate DATE NOT NULL DEFAULT GETDATE(), -- DEFAULT gives us a value if none was specified
    EndDate DATE NOT NULL,
    CHECK (EndDate > StartDate) -- ensures / enforces that the conditon stated must be met before the entry is added to the table
);


ALTER TABLE School.Course
    ADD CONSTRAINT FK__Course__TeacherID FOREIGN KEY ( TeacherID )
        REFERENCES School.Teacher (Teacher_ID);












-- SELECT * FROM BakeryApp.CustomerReceipt;



SELECT CURRENT_TIMESTAMP;
SELECT GETDATE();
SELECT SYSDATETIME() AS SysDateTime;

SELECT GETDATE()
AT TIME ZONE 'Eastern Standard Time';

SELECT CURRENT_TIMESTAMP AT TIME ZONE 'UTC' AT TIME ZONE 'Eastern Standard Time';








