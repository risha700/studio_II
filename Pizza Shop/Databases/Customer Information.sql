PRAGMA FOREIGN_KEYS = ON;

CREATE TABLE Customer 
(
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    Email TEXT NOT NULL,
    MobileNumber INTEGER NOT NULL,
    Password TEXT NOT NULL,
    DateOfBirth TEXT NOT NULL,
    Gender TEXT NOT NULL
);


.mode columns
.headers on

Select * From Customer;

.schema