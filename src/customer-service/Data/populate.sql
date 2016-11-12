/*
Add some default departments
 */
INSERT INTO Department (Label) VALUES ('Apparel');
INSERT INTO Department (Label) VALUES ('Electronics');
INSERT INTO Department (Label) VALUES ('Toys & Games');
INSERT INTO Department (Label) VALUES ('Books');
INSERT INTO Department (Label) VALUES ('Home Furnishings');

/*
Add some default incident types
 */
INSERT INTO IncidentType (Label) VALUES ('Defective Product');
INSERT INTO IncidentType (Label) VALUES ('Product Not Delivered');
INSERT INTO IncidentType (Label) VALUES ('Unhappy With Product');
INSERT INTO IncidentType (Label) VALUES ('Request For Information');
INSERT INTO IncidentType (Label) VALUES ('Fraudulent Charge');
INSERT INTO IncidentType (Label) VALUES ('Shipping Info Update');

/*
Add some employees
*/ 
INSERT INTO Employee (FirstName,LastName,DepartmentId,Administrator) VALUES
	('Matt','Kraatz',1,0),
	('Anulfo','Ordaz',2,1),
	('Matt','Hamil',3,0),
	('Dayne','Wright',4,0),
	('Garrett','Vangilder',5,1);

/*
Add some customers
*/
INSERT INTO Customer (FirstName,LastName) VALUES
	('Steve','Brownlee'),
	('Tractor','Ryan'),
	('Joe','Shepherd'),
	('Scott','Humphries'),
	('John','Wark');

/*
Add some orders
*/
INSERT INTO "Order" ("Date",CustomerId) VALUES
	('20161005',1),
	('20161010',2),
	('20161015',3),
	('20161020',4),
	('20161025',5),
	('20161105',1),
	('20161110',2),
	('20161115',3),
	('20161120',4),
	('20161125',5);

/*
Add some labels
*/

INSERT INTO Label ("Description") VALUES
	('This order is refundable'),
	('This order is replaceable'),
	('Non-Transactional incident');

/*
Add some incident type labels
*/

INSERT INTO IncidentTypeLabel (IncidentTypeId,LabelId) VALUES
	(1,1),
	(1,2),
	(2,1),
	(2,2),
	(3,1),
	(4,3),
	(5,1),
	(6,3);

/*
Add some incidents
*/

INSERT INTO Incident (IncidentTypeId,OrderId,EmployeeId,Resolution,DateResolved) VALUES
	(1,1,1,'',NULL),
	(2,2,2,'',NULL),
	(3,3,3,'',NULL),
	(4,4,4,'Answered their question about the product','20161130'),
	(5,5,5,'Refunded the full amount back to their credit card','20161129');