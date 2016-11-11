CREATE TABLE Customer
(
	CustomerId int PRIMARY KEY NOT NULL,
	FirstName string NOT NULL,
	LastName string NOT NULL,
	DateCreated datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S'))
)