CREATE TABLE Produce (
    Cost float,
    PID int NOT NULL AUTO_INCREMENT,
    ItemName varchar(255) UNIQUE,
    Vendor varchar(255),
    Type varchar(255),
    PRIMARY KEY(PID)
);

insert into Produce (Cost, ItemName, Vendor, Type) values (1.2, "Potatoes", "Great Value", "Potato");