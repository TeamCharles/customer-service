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
